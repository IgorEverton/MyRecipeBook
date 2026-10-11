using Moq;
using MyRecipeBook.Domain.Repositories;

namespace CommonTestUtilities.Repositories;

public class IUnitOfWorkBuilder
{
    public static IUnitOfWork build()
    {
        var mock = new Mock<IUnitOfWork>();
        return mock.Object;
    }

}
