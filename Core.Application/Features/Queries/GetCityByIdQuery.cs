using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public class GetCityByIdQuery : IRequest<City>
    {
        public Guid Id { get; private set; }

        public GetCityByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }

    public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, City>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMediator _mediator;

        public GetCityByIdHandler(IMediator mediator, ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            _mediator = mediator;
        }

        public async Task<City> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _cityRepository.GetByIdAsync(request.Id);
            return res;
        }
    }
}
