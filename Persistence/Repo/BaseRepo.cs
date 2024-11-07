using Microsoft.EntityFrameworkCore;
using Application.Persistence.Interface;
using System.Linq.Expressions;
using Persistence.Context;
using static Dapper.SqlMapper;
using Microsoft.IdentityModel.Tokens;

namespace Persistence.Repo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected DbSet<T> _dbSet;
        public BaseRepo(ApplicationDBContext context)
        {
            _dbSet = context.Set<T>();
        }
        public int MaxKey(Expression<Func<T, int>> Key_Predicate)
        {
            if (_dbSet.IsNullOrEmpty()) return 1;
            int? Key = _dbSet.Max(Key_Predicate);
            return Key + 1 ?? 1;
        }
        public long MaxKey(Expression<Func<T, long>> Key_Predicate)
        {
            if (_dbSet.IsNullOrEmpty()) return 1;
            long? Key = _dbSet.Max(Key_Predicate);
            return Key + 1 ?? 1;
        }
        public T GetById(int id) => _dbSet.Find(id);
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public T Find(Expression<Func<T, bool>> criteria) => _dbSet.SingleOrDefault(criteria);
        public T FindInclude(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending, string[] includes = null)
        {
            IQueryable<T> query = _dbSet.Where(criteria);

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.FirstOrDefault();
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }
        public T FindNoTraking(Expression<Func<T, bool>> criteria) => _dbSet.AsNoTracking().SingleOrDefault(criteria);
        public T FindNoTraking(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy = null) => _dbSet.Where(criteria).OrderBy(orderBy).AsNoTracking().FirstOrDefault();
        public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.SingleOrDefault(criteria);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria) => _dbSet.Where(criteria).ToList();
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).ToList();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take)
        {
            return _dbSet.Where(criteria).Skip(skip).Take(take).ToList();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbSet.Where(criteria);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria) => await _dbSet.Where(criteria).ToListAsync();
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).ToListAsync();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            return await _dbSet.Where(criteria).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbSet.Where(criteria);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }
        public IEnumerable<T> FindAllInclude(string[] includes = null)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.ToList();
        }
        public IEnumerable<T> FindAllInclude(Expression<Func<T, object>> orderBy, int skip, int take, string[] includes = null)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.OrderByDescending(orderBy).Skip(skip).Take(take).ToList();
        }
        public IEnumerable<T> FindAllInclude(int skip, int take, string[] includes = null)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Skip(skip).Take(take).ToList();
        }
        public virtual IQueryable<T> GetAllNolist()
        {
            return _dbSet.AsNoTracking();
        }
        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            return entities;
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }
        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            return entities;
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }
        public void AttachRange(IEnumerable<T> entities)
        {
            _dbSet.AttachRange(entities);
        }
        public int Count()
        {
            return _dbSet.Count();
        }
        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _dbSet.Count(criteria);
        }
        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _dbSet.CountAsync(criteria);
        }
        public bool isExist(Expression<Func<T, bool>> criteria)
        {
            return _dbSet.AsNoTracking().Any(criteria);
        }
        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().AnyAsync(predicate);
        }
        public IQueryable<T> GetTableAsTracking()
        {
            return _dbSet.AsQueryable();
        }
        public IQueryable<T> GetTableNoTracking()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }
    }
}
