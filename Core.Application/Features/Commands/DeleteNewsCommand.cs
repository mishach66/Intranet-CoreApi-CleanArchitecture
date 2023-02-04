using Core.Application.Interfaces.Repositories;
using MediatR;

namespace Core.Application.Features.Commands
{
    public class DeleteNewsCommand : IRequest<string>
    {
        public Guid Id { get; private set; }
        public DeleteNewsCommand(Guid id)
        {
            this.Id = id;
        }
    }

    public class DeleteNewsHandler : IRequestHandler<DeleteNewsCommand, String>
    {
        private readonly INewsRepository _iNewsRepository;
        private readonly IMediator _mediator;

        public DeleteNewsHandler(INewsRepository iNewsRepository, IMediator mediator)
        {
            _iNewsRepository = iNewsRepository;
            _mediator = mediator;
        }

        public async Task<string> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _iNewsRepository.DeleteAsync(request.Id);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "News has been deleted!";
        }
    }
}
