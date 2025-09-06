using MyBookOfRecipes.Domain.Entities;
using MyBookOfRecipes.Domain.Repositories.UserRepository;
using MyBookOfRecipes.Infrastructure.Repositories.Base;
using System.Data;

namespace MyBookOfRecipes.Infrastructure.Repositories.UserRepository
{
    public class UserReadOnlyRepository(IDbConnection dbConnection) : BaseReadOnlyRepository<User>(dbConnection), IUserReadOnlyRepository
    {
        public async Task<bool> IsExistActiveUserWithEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
