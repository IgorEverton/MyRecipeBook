namespace MyRecipeBook.Domain.Repositories.User
{
    public interface IUserWriteOnlyRepository
    {
       Task AddUser(Entities.User user);
    }
}
