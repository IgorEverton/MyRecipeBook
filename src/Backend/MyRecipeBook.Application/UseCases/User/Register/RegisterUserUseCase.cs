using MyRecipeBook.Application.Service.AutoMapper;
using MyRecipeBook.Application.Service.Cryptography;
using MyRecipeBook.Communication.Request;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    public async Task<ResponseRegisterUserJson> Exercute(RequestRegisterUserJson request)
    {
        var criptografiaDeSenha = new PasswordEncripter();

        var autoMapper = new AutoMapper.MapperConfiguration(opt =>
        {
            opt.AddProfile(new AutoMapping());
        }).CreateMapper();

        Validate(request);

        var user = autoMapper.Map<Domain.Entities.User>(request);

        user.Password = criptografiaDeSenha.Encrypt(request.Password);

        await _writeOnlyRepository.AddUser(user);

        return new ResponseRegisterUserJson
        {
            Name = request.Name
        };
    }
    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var erroMensagens = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationExceptios(erroMensagens);
        }
    }
}
