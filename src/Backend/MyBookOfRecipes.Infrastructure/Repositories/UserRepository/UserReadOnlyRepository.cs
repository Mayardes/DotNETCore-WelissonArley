using Dapper;
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
            string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM [tbl.User] WHERE Email = @Email) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS EMAILEXISTS;";

            var parameters = new
            {
                Email = email
            };

            return await dbConnection.QueryFirstOrDefaultAsync<bool>(query, parameters);
        }
    }
}
