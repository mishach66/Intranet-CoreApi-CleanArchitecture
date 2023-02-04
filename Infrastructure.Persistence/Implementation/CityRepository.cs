using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Implementation.Basic;

namespace Infrastructure.Persistence.Implementation
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }
    }
}
