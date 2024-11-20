using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.Service.AutoMapper;
using MyRecipeBook.Application.Service.Cryptography;
using MyRecipeBook.Application.UseCases.User.Register;

namespace MyRecipeBook.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
            AddPasswordEncrypter(services);
        }

        private static void AddAutoMapper(IServiceCollection services) 
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(opt =>
            {
                opt.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddPasswordEncrypter(IServiceCollection services)
        {
            services.AddScoped(option => new PasswordEncripter());
        }
    }
}
