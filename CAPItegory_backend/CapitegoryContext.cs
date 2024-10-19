using Microsoft.EntityFrameworkCore;
using CAPItegory_backend.Models;

namespace CAPItegory_backend;

public partial class CapitegoryContext : DbContext
{
    public CapitegoryContext()
    {
    }

    public CapitegoryContext(DbContextOptions<CapitegoryContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<Category> Category { get; set; } = default!;
}