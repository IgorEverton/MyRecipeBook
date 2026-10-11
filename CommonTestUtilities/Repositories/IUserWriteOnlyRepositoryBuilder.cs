using Moq;
using MyRecipeBook.Domain.Repositories.User;

namespace CommonTestUtilities.Repositories;

public class IUserWriteOnlyRepositoryBuilder
{
    public static IUserWriteOnlyRepository build()
    {
        var mock = new Mock<IUserWriteOnlyRepository>();
        return mock.Object;
    }
}
