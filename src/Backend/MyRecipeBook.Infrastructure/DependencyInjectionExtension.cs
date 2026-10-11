using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using MyRecipeBook.Infrastructure.Security.PasswordHashing;
using System.Reflection;

namespace MyRecipeBook.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services, configuration);
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

    public static void AddRepositories(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
        services.AddDbContext<MyRecipeBookDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DbConnectionString")!;
            options.UseMySQL(connectionString);
        });

        services.AddFluentMigratorCore().ConfigureRunner(config =>
        {
            var connectionString = configuration.GetConnectionString("DbConnectionString")!;
            config
            .AddMySql5()
            .WithGlobalConnectionString(connectionString)
            .ScanIn(Assembly.Load("MyRecipeBook.Infrastructure"))
            .For.All();
        });
    }
}
