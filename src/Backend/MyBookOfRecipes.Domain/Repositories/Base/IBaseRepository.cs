using MyBookOfRecipes.Domain.Entities.Base;
using MyBookOfRecipes.Domain.Pagination;

namespace MyBookOfRecipes.Domain.Repositories.Base
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAsync(Paged request);
        Task<T?>GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
