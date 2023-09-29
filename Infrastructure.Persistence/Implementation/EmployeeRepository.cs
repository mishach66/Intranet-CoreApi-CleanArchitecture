using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Implementation.Basic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Implementation
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        protected readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllWithBranchAsync()
        {
            return await _context.Employees.Include(e => e.Branch).ToListAsync();
        }

        public async Task<Employee> GetByIdWithBranchAsync(object id)
        {
            return await _context.Employees.Where(e => e.Id == (Guid)id).Include(e => e.Branch).FirstOrDefaultAsync();
        }
    }
}
