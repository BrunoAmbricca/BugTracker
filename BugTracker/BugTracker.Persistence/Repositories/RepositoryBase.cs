using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain.Common;
using BugTracker.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BugTracker.Persistence.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : Entity
    {
        protected readonly BugTrackerDbContext _context;

        public RepositoryBase(BugTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        //public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        //                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
        //                                       string includeString = null, 
        //                                       bool disableTracking = true)
        //{
        //    IQueryable<T> query = _context.Set<T>();

        //    if (disableTracking) query = query.AsNoTracking();

        //    if(!string.IsNullOrEmpty(includeString)) query = query.Include(includeString);

        //    if(predicate != null) query = query.Where(predicate);

        //    if (orderBy != null) return await orderBy(query).ToListAsync();

        //    return await query.ToListAsync();
        //}

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
                                               List<Expression<Func<T, object>>> includes = null, 
                                               bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
