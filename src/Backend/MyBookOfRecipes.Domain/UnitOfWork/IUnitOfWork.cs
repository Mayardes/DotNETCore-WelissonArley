using MyBookOfRecipes.Domain.Repositories.UserRepository;

namespace MyBookOfRecipes.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserWriteRepository UsersWrite { get;}
        Task<bool>CommitAsyc();
        void RollBack();
    }
}
