using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;

namespace Core.Application.Features.Commands
{
    public class EditCityCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public class EditCityHandler : IRequestHandler<EditCityCommand, Guid>
    {
        private readonly ICityRepository _iCityRepository;
        private readonly IMediator _mediator;

        public EditCityHandler(ICityRepository iCityRepository, IMediator mediator)
        {
            _iCityRepository = iCityRepository;
            _mediator = mediator;
        }
        
        public async Task<Guid> Handle(EditCityCommand request, CancellationToken cancellationToken)
        {
            var cityentity = AppMapper.Mapper.Map<City>(request);

            if (cityentity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _iCityRepository.UpdateAsync(cityentity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }
            return cityentity.Id;
        }
    }
}
