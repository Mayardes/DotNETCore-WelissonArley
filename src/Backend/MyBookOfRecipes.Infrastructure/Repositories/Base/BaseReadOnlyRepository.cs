using Dapper;
using MyBookOfRecipes.Domain.Entities.Base;
using MyBookOfRecipes.Domain.Pagination;
using MyBookOfRecipes.Domain.Repositories.Base;
using System.Data;

namespace MyBookOfRecipes.Infrastructure.Repositories.Base
{
    public class BaseReadOnlyRepository<T>(IDbConnection dbConnection) : IBaseReadOnlyRepository<T> where T : EntityBase
    {
        protected readonly IDbConnection _dbConnection = dbConnection;

        public async Task<IEnumerable<T>> GetAsync(Paged request)
        {
            var sql = "SELECT Name, Email, Password FROM [tbl.User] ORDER BY Name LIMIT @PageSize OFFSET @Offset;";
            var parameters = new
            {
                Offset = (request.Page - 1) * request.Size,
                PageSize = request.Size
            };
            return await _dbConnection.QueryAsync<T>(sql, parameters);
        }
        public async Task<T?> GetByIdAsync(Guid id)
        {
            var sql = "SELECT Id, Nome, Email, CreatedAt, UpdatedAt, Status, Password FROM [Users] Where Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id});
        }
    }
}
