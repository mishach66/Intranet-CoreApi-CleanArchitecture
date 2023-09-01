using Core.Application.DTO;
using Core.Application.Interfaces.Repositories;
using Core.Application.Pagination;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public class BranchesWithTotalCount
    {
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }

    public sealed record class GetAllBranchesQuery : IRequest<BranchesWithTotalCount>
    {
        internal PaginationFilter _filter;
        public GetAllBranchesQuery()
        {

        }
        public GetAllBranchesQuery(PaginationFilter filter)
        {
            _filter = filter;
        }
    }

    public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, BranchesWithTotalCount>
    {
        private readonly IBranchRepository _branchRepository;
        public GetAllBranchesQueryHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        //public async Task<IEnumerable<Branch>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        //{
        //    //var allBranch = (List<Branch>) await _branchRepository.GetAllAsync();
        //    var allBranch = (List<Branch>)await _branchRepository.GetBranchesSortedAsync();

        //    var validFilter = new PaginationFilter(request._filter.PageNumber, request._filter.PageSize);

        //    var PgResponse = new PagedResponse(allBranch, validFilter.PageNumber, validFilter.PageSize).BranchPagedList();

        //    var res = PgResponse;

        //    return res;
        //}

        public async Task<BranchesWithTotalCount> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var allBranch = await _branchRepository.GetBranchesSortedAsync();
            int count = allBranch.Count;

            var validFilter = new PaginationFilter(request._filter.PageNumber, request._filter.PageSize);

            //var PgResponse = new PagedResponse(allBranch, validFilter.PageNumber, validFilter.PageSize).BranchPagedList();
            var PgResponse = new PagedResponseGeneric<Branch>(allBranch, validFilter.PageNumber, validFilter.PageSize).PagedList();

            var res = PgResponse;

            BranchesWithTotalCount bwtc = new ();
            bwtc.Count = count;
            bwtc.PageSize = request._filter.PageSize;
            bwtc.PageNumber = request._filter.PageNumber;
            bwtc.Branches = res;

            return bwtc;
        }
    }
}
