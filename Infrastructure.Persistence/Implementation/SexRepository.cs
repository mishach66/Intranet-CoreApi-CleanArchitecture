using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Implementation.Basic;

namespace Infrastructure.Persistence.Implementation
{
    public class SexRepository : RepositoryBase<Sex>, ISexRepository
    {
        public SexRepository(AppDbContext context) : base(context)
        {
        }
    }
}
