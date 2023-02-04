using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Implementation.Basic;

namespace Infrastructure.Persistence.Implementation
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context)
        {
        }
    }
}
