using MyBookOfRecipes.Domain.Repositories.Base;

namespace MyBookOfRecipes.Domain.Repositories.UserRepository
{
    public interface IUserReadOnlyRepository : IBaseReadOnlyRepository<Entities.User>
    {
        Task<bool> IsExistActiveUserWithEmail(string email);
    }
}
