namespace CAPItegory_backend.Rows
{
    public class SearchRow
    {

        public IEnumerable<CategoryRow> Categories { get; set; } = [];

        public int TotalPages { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

    }
}
