using Core.Application.Interfaces.Repositories.Basic;
using Core.Domain.Models;

namespace Core.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<Employee> GetByIdWithBranchAsync(object id);
        Task<IEnumerable<Employee>> GetAllWithBranchAsync();
    }
}
