using AppCore.Entity;
using AppData.Context;
using Microsoft.EntityFrameworkCore;

namespace AppData.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet.AsQueryable().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
