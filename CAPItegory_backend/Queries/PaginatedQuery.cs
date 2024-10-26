namespace CAPItegory_backend.Queries
{
    public class PaginatedQuery
    {
        private const int MaxPageSize = 100;

        private const int DefaultPageSize = 10;

        private int _pageSize = DefaultPageSize;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get { return _pageSize; } set { _pageSize = value > MaxPageSize ? MaxPageSize : value; } }
    }
}
