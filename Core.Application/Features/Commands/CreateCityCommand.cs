using Core.Application.DTO;
using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;

namespace Core.Application.Features.Commands
{
    public class CreateCityCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
    }

    public class CreateCityHandler : IRequestHandler<CreateCityCommand, Guid>
    {
        private readonly ICityRepository _iCityRepository;
        private readonly IMediator _mediator;

        public CreateCityHandler(ICityRepository iCityRepository, IMediator mediator)
        {
            _iCityRepository = iCityRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var cityentity = AppMapper.Mapper.Map<City>(request);

            if (cityentity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            await _iCityRepository.InsertAsync(cityentity);
            return cityentity.Id;
        }
    }
}
