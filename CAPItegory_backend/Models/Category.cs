namespace CAPItegory_backend.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Category? Parent { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
