using System;
using DebtForgivenessRegistration.Features.Customers.Models;
using Microsoft.EntityFrameworkCore;

namespace DebtForgivenessRegistration.Data;

public class RegistrarDbContext: DbContext
{
    public RegistrarDbContext(DbContextOptions<RegistrarDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Customer> Customers { get; set; } = default!;
}

