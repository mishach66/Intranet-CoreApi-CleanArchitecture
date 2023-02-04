using Core.Application.Interfaces.Repositories.Basic;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Implementation.Basic
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AppDbContext _context;
        public DbSet<T> table = null;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetRangeAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task InsertAsync(T obj)
        {
            await table.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
        public async Task InsertRangeAsync(IEnumerable<T> obj)
        {
            await table.AddRangeAsync(obj);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T obj)
        {
            //table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }
}
