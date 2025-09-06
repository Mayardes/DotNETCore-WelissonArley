using MyBookOfRecipes.Domain.Entities.Base;
using MyBookOfRecipes.Domain.Repositories.Base;
using MyBookOfRecipes.Infrastructure.Data;

namespace MyBookOfRecipes.Infrastructure.Repositories.Base
{
    public class BaseWriteRepository<T>(MyBookOfRecipesDbContext context, CancellationToken cancellationToken) : IBaseWriteRepository<T> where T : EntityBase
    {
        protected readonly MyBookOfRecipesDbContext _context = context;
        public async Task CreateAsync(T entity) => await _context.Set<T>().AddAsync(entity, cancellationToken);
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id, cancellationToken);
            if(entity is not null)
            { 
                entity.Status = Domain.Enums.StatusEntityEnum.Disbled;
                _context.Update(entity);
            }
        }
        public virtual Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
