using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Implementation.Basic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Implementation
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        protected readonly AppDbContext _context;
        public BranchRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Branch>> GetBranchesSortedAsync()
        {
            var sortedBranches =  await _context.Branches.OrderBy(b => b.FullAddress).ToListAsync();

            var capitalCityBranches = sortedBranches.Where(b => b.FullAddress.StartsWith("თბილისი")).ToList();
            sortedBranches.RemoveAll(b => b.FullAddress.StartsWith("თბილისი"));
            var allBranches = capitalCityBranches.Concat(sortedBranches).ToList();
            
            return allBranches;
        }
    }
}
