using Core.Application.Interfaces.Repositories;

namespace Core.Application.Features.Commands
{
    public class DeleteBranchCommand : IRequest<string>
    {
        public Guid Id { get; private set; }
        public DeleteBranchCommand(Guid id)
        {
            this.Id = id;
        }
    }

    public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, String>
    {
        private readonly IBranchRepository _iBranchRepository;
        private readonly IMediator _mediator;

        public DeleteBranchHandler(IBranchRepository iBranchRepository, IMediator mediator)
        {
            _iBranchRepository = iBranchRepository;
            _mediator = mediator;
        }

        public async Task<string> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _iBranchRepository.DeleteAsync(request.Id);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Branch has been deleted!";
        }
    }
}
