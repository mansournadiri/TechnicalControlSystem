using Application.Persistence.Interface;
using Persistence.Context;

namespace Persistence.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDBContext _context;
        private bool _disposed = false;
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Commit()
        {
            _context.Database.CommitTransaction();
        }
        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
