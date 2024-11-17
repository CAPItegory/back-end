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
        modelBuilder.Entity<Category>().HasMany(c => c.Children).WithOne(c => c.Parent).HasForeignKey(c => c.ParentId);

        var techId = Guid.NewGuid();
        var progId = Guid.NewGuid();
        var langId = Guid.NewGuid();
        var frameworkId = Guid.NewGuid();
        var dbId = Guid.NewGuid();
        var sqlId = Guid.NewGuid();
        var noSqlId = Guid.NewGuid();
        var devOpsId = Guid.NewGuid();
        var ciCdId = Guid.NewGuid();
        var artId = Guid.NewGuid();
        var musicId = Guid.NewGuid();
        var sportsId = Guid.NewGuid();
        var literatureId = Guid.NewGuid();
        var historyId = Guid.NewGuid();
        var scienceId = Guid.NewGuid();
        var physicsId = Guid.NewGuid();
        var chemistryId = Guid.NewGuid();
        var biologyId = Guid.NewGuid();

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = techId, Name = "Technology", CreationDate = DateTime.Now },
            new Category { Id = progId, Name = "Programming", ParentId = techId, CreationDate = DateTime.Now },
            new Category { Id = langId, Name = "Languages", ParentId = progId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "C#", ParentId = langId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "JavaScript", ParentId = langId, CreationDate = DateTime.Now },
            new Category { Id = frameworkId, Name = "Frameworks", ParentId = progId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = ".NET", ParentId = frameworkId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Node.js", ParentId = frameworkId, CreationDate = DateTime.Now },
            new Category { Id = dbId, Name = "Databases", ParentId = techId, CreationDate = DateTime.Now },
            new Category { Id = sqlId, Name = "SQL", ParentId = dbId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "MySQL", ParentId = sqlId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "PostgreSQL", ParentId = sqlId, CreationDate = DateTime.Now },
            new Category { Id = noSqlId, Name = "NoSQL", ParentId = dbId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "MongoDB", ParentId = noSqlId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Cassandra", ParentId = noSqlId, CreationDate = DateTime.Now },
            new Category { Id = devOpsId, Name = "DevOps", ParentId = techId, CreationDate = DateTime.Now },
            new Category { Id = ciCdId, Name = "CI/CD", ParentId = devOpsId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Jenkins", ParentId = ciCdId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "GitLab CI", ParentId = ciCdId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Docker", ParentId = devOpsId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Kubernetes", ParentId = devOpsId, CreationDate = DateTime.Now },
            new Category { Id = artId, Name = "Art", CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Painting", ParentId = artId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Sculpture", ParentId = artId, CreationDate = DateTime.Now },
            new Category { Id = musicId, Name = "Music", CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Classical", ParentId = musicId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Rock", ParentId = musicId, CreationDate = DateTime.Now },
            new Category { Id = sportsId, Name = "Sports", CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Football", ParentId = sportsId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Basketball", ParentId = sportsId, CreationDate = DateTime.Now },
            new Category { Id = literatureId, Name = "Literature", CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Fiction", ParentId = literatureId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Non-Fiction", ParentId = literatureId, CreationDate = DateTime.Now },
            new Category { Id = historyId, Name = "History", CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Ancient", ParentId = historyId, CreationDate = DateTime.Now },
            new Category { Id = Guid.NewGuid(), Name = "Modern", ParentId = historyId, CreationDate = DateTime.Now },
            new Category { Id = scienceId, Name = "Science", CreationDate = DateTime.Now },
            new Category { Id = physicsId, Name = "Physics", ParentId = scienceId, CreationDate = DateTime.Now },
            new Category { Id = chemistryId, Name = "Chemistry", ParentId = scienceId, CreationDate = DateTime.Now },
            new Category { Id = biologyId, Name = "Biology", ParentId = scienceId, CreationDate = DateTime.Now }
        );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Category> Category { get; set; } = default!;
}