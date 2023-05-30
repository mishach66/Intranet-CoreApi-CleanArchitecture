using System;
using Core.Domain.Models;

namespace Core.Application.Pagination
{
    internal class PagedResponse : Branch
    {
        List<Branch> List = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(List<Branch> branchList, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;

            foreach (var item in branchList)
            {
                List.Add(item);
            }
        }

        public List<Branch> BranchPagedList()
        {
            //return Paged List;
            return List.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
