using CourseRegistration.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; } = default!;
    public DbSet<UserCourse> UserCourses { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Course>( entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name);
            entity.Property(c =>c.Deactivated);
            entity.Property(c => c.Created).IsRequired().HasDefaultValue(DateTime.UtcNow);
        });

        builder.Entity<UserCourse>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.UserId).IsRequired();
            entity.Property(c =>c.CourseId).IsRequired();
            entity.Property(c => c.Deactivated);
            entity.Property(c => c.Created).IsRequired().HasDefaultValue(DateTime.UtcNow);
        });
    }
}

