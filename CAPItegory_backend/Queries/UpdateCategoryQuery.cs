namespace CAPItegory_backend.Query
{
    public class UpdateCategoryQuery
    {

        public string? Name { get; set; }

        public Guid? Parent { get; set; } = Guid.Empty;

    }
}
