

namespace AppData.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
       
    }
}
