using MyRecipeBook.Communication.Request;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisterUserJson Exercute(RequestRegisterUserJson request)
    {
        Validate(request);

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
