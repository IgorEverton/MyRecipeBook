using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories;

public class UserRepository: IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly MyRecipeBookDbContext _dbContext;

    public UserRepository(MyRecipeBookDbContext dbContext)
    {
        _dbContext = dbContext; 
    }

    public async Task AddUser(User user)
    {
        await _dbContext.Users.AddAsync(user); 
        _dbContext.SaveChanges();
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.IsActive);

    }
}
