using CAPItegory_backend.Models;

namespace CAPItegory_backend.Rows
{
    public class CategorySearchRow
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public DateTime? CreationDate { get; set; }

        public bool IsRoot { get; set; }
    }
}
