using Core.Application.DTO;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public sealed record class GetAllBranchesQuery : IRequest<IEnumerable<Branch>>;

    public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, IEnumerable<Branch>>
    {
        private readonly IBranchRepository _branchRepository;
        public GetAllBranchesQueryHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<IEnumerable<Branch>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var res = await _branchRepository.GetAllAsync();

            return res;
        }
    }
}
