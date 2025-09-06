using MyBookOfRecipes.Domain.Repositories.UserRepository;
using MyBookOfRecipes.Domain.UnitOfWork;
using MyBookOfRecipes.Infrastructure.Data;
using MyBookOfRecipes.Infrastructure.Repositories.UserRepository;
using System.Data;

namespace MyBookOfRecipes.Infrastructure.UnitOfWork
{
    public class UnitOfWork(MyBookOfRecipesDbContext context) : IUnitOfWork
    {
        public IUserWriteRepository UsersWrite { get;} = new UserWriteRepository(context);
        public async Task<bool> CommitAsyc() => await context.SaveChangesAsync() > 0;
        public void RollBack() => context.Dispose();
    }
}
