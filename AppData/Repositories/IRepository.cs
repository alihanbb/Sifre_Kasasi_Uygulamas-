using AppCore.Entity;

namespace AppData.Repositories
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
