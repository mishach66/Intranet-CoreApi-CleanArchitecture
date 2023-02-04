using Core.Application.Interfaces.Repositories;
using MediatR;

namespace Core.Application.Features.Commands
{
    public class DeleteCityCommand : IRequest<string>
    {
        public Guid Id { get; private set; }
        public DeleteCityCommand(Guid id)
        {
            this.Id = id;
        }
    }

    public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, String>
    {
        private readonly ICityRepository _iCityRepository;
        private readonly IMediator _mediator;

        public DeleteCityHandler(ICityRepository iCityRepository, IMediator mediator)
        {
            _iCityRepository = iCityRepository;
            _mediator = mediator;
        }

        public async Task<string> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _iCityRepository.DeleteAsync(request.Id);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "City has been deleted!";
        }
    }
}
