using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.UseCases.User.Register;

namespace MyRecipeBook.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }

    //private static void AddPasswordEncrypter(IServiceCollection services)
    //{
    //    services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
    //}
}
