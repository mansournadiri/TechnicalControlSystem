namespace Application.Persistence.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        int SaveChanges();
        Task SaveChangesAsync();
        void RollBack();
    }
}
