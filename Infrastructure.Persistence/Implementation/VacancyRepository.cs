using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Implementation.Basic;

namespace Infrastructure.Persistence.Implementation
{
    public class VacancyRepository : RepositoryBase<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
