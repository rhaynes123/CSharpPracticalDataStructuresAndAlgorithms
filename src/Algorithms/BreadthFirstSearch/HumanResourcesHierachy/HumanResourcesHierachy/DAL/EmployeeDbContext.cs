using System;
using HumanResourcesHierachy.Features.Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesHierachy.DAL
{
    #region Helpful Links
    // https://blog.jetbrains.com/dotnet/2021/02/24/entity-framework-core-5-pitfalls-to-avoid-and-ideas-to-try/
    // https://www.thereformedprogrammer.net/updating-many-to-many-relationships-in-ef-core-5-and-above/
    // https://www.fearofoblivion.com/dont-let-ef-call-the-shots
    // https://habr.com/en/post/516596/
    // https://learnsql.com/blog/query-parent-child-tree/
    #endregion
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<EmployeeRole> EmployeeRoles { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>( emp =>
            {
                emp.HasKey(e => e.Id);
                emp.Property(e => e.FirstName);
                emp.Property(e => e.LastName);
                emp.Property(e => e.ManagerId);
                emp.Property(e => e.CreatedDateTime);
                emp.Property(e => e.DateOfBirth);
                emp.Property(e => e.EmployeeNumber);
                emp.HasMany(e => e.EmployeeRoles);
                emp.HasOne(e => e.Manager)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.ManagerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<EmployeeRole>(empRole =>
            {
                empRole.HasKey(r =>r.Id);
                empRole.Property(r => r.CreatedDateTime);
                empRole.Property(r => r.DeactivatedDateTime);
                empRole.Property(r => r.Role);
                empRole.HasOne(r => r.Employee)
                .WithMany(e => e.EmployeeRoles);
            });

        }
    }
}

