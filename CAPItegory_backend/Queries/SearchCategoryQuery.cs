namespace CAPItegory_backend.Queries
{
    public class SearchCategoryQuery : PaginatedQuery
    {
        public bool? IsRoot { get; set; }
        public DateTime? BeforeDate { get; set; }
        public DateTime? AfterDate { get; set; } 
        public Guid? ParentId { get; set; }
        public bool? OrderByName { get; set; }
        public bool? OrderByCreationDate { get; set; }
        public bool? OrderByNumberOfChild { get; set; }
    }
}
