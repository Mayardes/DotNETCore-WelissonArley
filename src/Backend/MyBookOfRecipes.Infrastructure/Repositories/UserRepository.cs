using MyBookOfRecipes.Domain.Entities;
using MyBookOfRecipes.Domain.Repositories;
using MyBookOfRecipes.Infrastructure.Data;
using MyBookOfRecipes.Infrastructure.Repositories.Base;

namespace MyBookOfRecipes.Infrastructure.Repositories
{
    public class UserRepository(MyBookOfRecipesDbContext context, CancellationToken cancellationToken) : BaseRepository<User>(context, cancellationToken), IUserRepository
    { }
}
