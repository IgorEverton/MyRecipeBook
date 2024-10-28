using MyRecipeBook.Communication.Request;
using MyRecipeBook.Communication.Response;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisterUserJson Exercute(RequestRegisterUserJson request)
    {
        return new ResponseRegisterUserJson
        {
            Name = request.Name
        };

    }
}
