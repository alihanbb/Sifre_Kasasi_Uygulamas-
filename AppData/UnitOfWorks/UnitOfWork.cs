using AppData.Context;

namespace AppData.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
