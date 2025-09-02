using Microsoft.EntityFrameworkCore;
using MyBookOfRecipes.Domain.Entities.Base;
using MyBookOfRecipes.Domain.Pagination;
using MyBookOfRecipes.Domain.Repositories.Base;
using MyBookOfRecipes.Infrastructure.Data;

namespace MyBookOfRecipes.Infrastructure.Repositories.Base
{
    public class BaseRepository<T>(MyBookOfRecipesDbContext context, CancellationToken cancellationToken) : IBaseRepository<T> where T : EntityBase
    {
        public async Task CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if(entity is not null)
            { 
                entity.Status = Domain.Enums.StatusEntityEnum.Disbled;
                context.Update(entity);
            }
        }

        public async Task<IEnumerable<T>> GetAsync(Paged request)
        {
            return await context.Set<T>().Where(x => x.Status == Domain.Enums.StatusEntityEnum.Enabled)
                .Skip((request.Page -1) * request.Size)
                .Take(request.Size)
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
