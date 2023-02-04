using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public sealed record class GetAllCitiesQuery : IRequest<IEnumerable<City>>;

    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, IEnumerable<City>>
    {
        private readonly ICityRepository _cityRepository;
        public GetAllCitiesQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var res = await _cityRepository.GetAllAsync();
            return res;
        }
    }
}
