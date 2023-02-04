using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public sealed record GetAllVacanciesQuery : IRequest<IEnumerable<Vacancy>>;

    public class GetAllVacancyQueryHandler : IRequestHandler<GetAllVacanciesQuery, IEnumerable<Vacancy>>
    {
        private readonly IVacancyRepository _vacancyRepository;
        public GetAllVacancyQueryHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<IEnumerable<Vacancy>> Handle(GetAllVacanciesQuery request, CancellationToken cancellationToken)
        {
            return await _vacancyRepository.GetAllAsync();
        }
    }
}
