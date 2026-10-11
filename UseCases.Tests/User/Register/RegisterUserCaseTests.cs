using CommonTestUtilities.Repositories;
using CommonTestUtilities.Request;
using CommonTestUtilities.Security;
using MyRecipeBook.Application.UseCases.User.Register;
using Shouldly;

namespace UseCases.Tests.User.Register;

public class RegisterUserCaseTests
{
    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuild.build();

        var useCase = CreateUseCase();

        var result = await useCase.Execute(request);

        result.ShouldNotBeNull();
        result.Token.ShouldNotBeNull();
        result.Name.ShouldBe(request.Name);


    }

    private RegisterUserUseCase CreateUseCase()
    {
        var unitOfWork = IUnitOfWorkBuilder.build();
        var userWriteOnlyRepository = IUserWriteOnlyRepositoryBuilder.build();
        var userReadOnlyRepository = new IUserReadOnlyRepositoryBuilder().Build();
        var passwordHasher = new IPasswordHasherBuilder().Build();

        return new RegisterUserUseCase(userReadOnlyRepository, userWriteOnlyRepository, passwordHasher, unitOfWork);
    }
}
