using Bogus;
using MyRecipeBook.Communication.Request;

namespace CommonTestUtilities.Request;

public class RequestRegisterUserJsonBuild
{
    public static RequestRegisterUserJson build()
    {
        return new Faker<RequestRegisterUserJson>()
            .RuleFor(request => request.Name, f => f.Person.FirstName)
            .RuleFor(request => request.Email, (f, user) => f.Internet.Email(user.Name))
            .RuleFor(request => request.Password, f => f.Internet.Password());
    }


}