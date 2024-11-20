using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;

namespace MyRecipeBook.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {

        }

        //private static void AddDbContext_MySqlServer(IServiceCollection services)
        //{
        //    var connectionString = "";
        //    var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));

        //    services.AddDbContext<MyRecipeBookDbContext>(dbContextOptions =>
        //    {
        //        dbContextOptions.UseMySql(connectionString, serverVersion);
        //    });
        //}

        //private static void AddDbContext_SqlServer(IServiceCollection services) 
        //{
        //    var connectionString = "";

        //    services.AddDbContext<MyRecipeBookDbContext>(dbContextOptions =>
        //    {
        //        dbContextOptions.UserSqlServer(connectionString);
        //    });
        //}

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
