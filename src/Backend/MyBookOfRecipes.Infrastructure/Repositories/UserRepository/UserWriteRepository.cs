using MyBookOfRecipes.Domain.Entities;
using MyBookOfRecipes.Domain.Repositories.UserRepository;
using MyBookOfRecipes.Infrastructure.Data;
using MyBookOfRecipes.Infrastructure.Repositories.Base;

namespace MyBookOfRecipes.Infrastructure.Repositories.UserRepository
{
    public class UserWriteRepository(MyBookOfRecipesDbContext context, CancellationToken cancellationToken = default) : BaseWriteRepository<User>(context, cancellationToken), IUserWriteRepository
    { }
}
