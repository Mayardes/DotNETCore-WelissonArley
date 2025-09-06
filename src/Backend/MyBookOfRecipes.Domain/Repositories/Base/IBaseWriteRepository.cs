using MyBookOfRecipes.Domain.Entities.Base;

namespace MyBookOfRecipes.Domain.Repositories.Base
{
    public interface IBaseWriteRepository<T> where T : EntityBase
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
