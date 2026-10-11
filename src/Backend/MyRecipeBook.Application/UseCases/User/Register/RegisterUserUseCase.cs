using FluentValidation.Results;
using Mapster;
using MyRecipeBook.Communication.Request;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserUseCase(
        IUserReadOnlyRepository readOnlyRepository, 
        IUserWriteOnlyRepository writeOnlyRepository, 
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork
        )
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {

        ValidateAndThrowOnFailures(request);

        var user = request.Adapt<Domain.Entities.User>();

        user.Password = _passwordHasher.HashPassword(request.Password);

        await _writeOnlyRepository.AddUser(user);
        
        await _unitOfWork.Commit();

        return new ResponseRegisterUserJson
        {
            Name = user.Name,
        };
    }
    private void ValidateAndThrowOnFailures(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        var emailAlreadyExists = _readOnlyRepository.ExistActiveUserWithEmail(request.Email).Result;
        if (emailAlreadyExists)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceMessagensException.EMAIL_INVALID));
        }

        if (result.IsValid == false)
        {
            var erroMensagens = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationExceptios(erroMensagens);
        }
    }
}
