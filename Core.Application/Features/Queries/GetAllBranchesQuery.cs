using Core.Application.DTO;
using Core.Application.Interfaces.Repositories;
using Core.Application.Pagination;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public sealed record class GetAllBranchesQuery : IRequest<IEnumerable<Branch>>
    {
        public PaginationFilter _filter;
        public GetAllBranchesQuery()
        {

        }
        public GetAllBranchesQuery(PaginationFilter filter)
        {
            _filter = filter;
        }
    }

    public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, IEnumerable<Branch>>
    {
        private readonly IBranchRepository _branchRepository;
        public GetAllBranchesQueryHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<IEnumerable<Branch>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            //var allBranch = (List<Branch>) await _branchRepository.GetAllAsync();
            var allBranch = (List<Branch>)await _branchRepository.GetBranchesSortedAsync();

            var validFilter = new PaginationFilter(request._filter.PageNumber, request._filter.PageSize);

            var PgResponse = new PagedResponse(allBranch, validFilter.PageNumber, validFilter.PageSize).BranchPagedList();

            var res = PgResponse;

            return res;
        }
    }
}
