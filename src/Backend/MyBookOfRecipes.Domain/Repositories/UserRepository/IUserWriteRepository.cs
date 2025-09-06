using MyBookOfRecipes.Domain.Repositories.Base;

namespace MyBookOfRecipes.Domain.Repositories.UserRepository
{
    public interface IUserWriteRepository : IBaseWriteRepository<Entities.User>
    { }
}
