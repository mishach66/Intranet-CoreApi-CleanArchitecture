using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories.Basic
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetRangeAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T obj);
        Task InsertRangeAsync(IEnumerable<T> obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(object id);
    }
}
