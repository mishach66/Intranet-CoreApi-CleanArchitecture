using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public class GetBranchByIdQuery : IRequest<Branch>
    {
        public Guid Id { get; private set; }

        public GetBranchByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }

    public class GetBranchByIdHandler : IRequestHandler<GetBranchByIdQuery, Branch>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMediator _mediator;

        public GetBranchByIdHandler(IMediator mediator, IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
            _mediator = mediator;
        }

        public async Task<Branch> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _branchRepository.GetByIdAsync(request.Id);
            return res;
        }
    }
}
