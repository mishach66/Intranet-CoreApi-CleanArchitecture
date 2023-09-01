namespace Core.Application.Pagination
{
    internal class PagedResponseGeneric<T> where T : class
    {
        readonly List<T> list = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponseGeneric(List<T> list, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;

            foreach (var item in list)
            {
                this.list.Add(item);
            }
        }

        public List<T> PagedList()
        {
            //return Paged List;
            return list.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
