using System.Linq.Expressions;

namespace Application.Persistence.Interface
{
    public interface IBaseRepo<T> where T : class
    {
        int MaxKey(Expression<Func<T, int>> Key_Predicate);
        long MaxKey(Expression<Func<T, long>> Key_Predicate);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        T FindInclude(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending, string[] includes = null);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        T FindNoTraking(Expression<Func<T, bool>> criteria);
        T FindNoTraking(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        IEnumerable<T> FindAllInclude(string[] includes = null);
        IEnumerable<T> FindAllInclude(int skip, int take, string[] includes = null);
        IEnumerable<T> FindAllInclude(Expression<Func<T, object>> orderBy, int skip, int take, string[] includes = null);
        IQueryable<T> GetAllNolist();
        T Add(T entity);
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Attach(T entity);
        void AttachRange(IEnumerable<T> entities);
        int Count();
        int Count(Expression<Func<T, bool>> criteria);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> criteria);
        bool isExist(Expression<Func<T, bool>> criteria);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();       
    }
    public static class OrderBy
    {
        public const string Ascending = "ASC";
        public const string Descending = "DESC";
    }
}
