using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;

namespace Core.Application.Features.Commands
{
    public class CreateBranchCommand : IRequest<Guid>
    {
        public string Address { get; set; }
        public string FullAddress { get; set; }
        public Guid CityId { get; set; }
    }

    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, Guid>
    {
        private readonly IBranchRepository _iBranchRepository;
        private readonly IMediator _mediator;

        public CreateBranchHandler(IBranchRepository iBranchRepository, IMediator mediator)
        {
            _iBranchRepository = iBranchRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branchentity = AppMapper.Mapper.Map<Branch>(request);

            if (branchentity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            await _iBranchRepository.InsertAsync(branchentity);
            return branchentity.Id;
        }
    }
}
