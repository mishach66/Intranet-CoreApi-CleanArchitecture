using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public class GetVacancyByIdQuery : IRequest<Vacancy>
    {
        public Guid Id { get; private set; }

        public GetVacancyByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }

    public class GetVacancyByIdHandler : IRequestHandler<GetVacancyByIdQuery, Vacancy>
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMediator _mediator;

        public GetVacancyByIdHandler(IMediator mediator, IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
            _mediator = mediator;
        }

        public async Task<Vacancy> Handle(GetVacancyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _vacancyRepository.GetByIdAsync(request.Id);
        }
    }
}
