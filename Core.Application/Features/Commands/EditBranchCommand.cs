using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;

namespace Core.Application.Features.Commands
{
    public class EditBranchCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string FullAddress { get; set; }
        public Guid CityId { get; set; }
    }

    public class EditBranchHandler : IRequestHandler<EditBranchCommand, Guid>
    {
        private readonly IBranchRepository _iBranchRepository;
        private readonly IMediator _mediator;

        public EditBranchHandler(IBranchRepository iBranchRepository, IMediator mediator)
        {
            _iBranchRepository = iBranchRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(EditBranchCommand request, CancellationToken cancellationToken)
        {
            var branchentity = AppMapper.Mapper.Map<Branch>(request);

            if (branchentity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _iBranchRepository.UpdateAsync(branchentity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }
            return branchentity.Id;
        }
    }
}
