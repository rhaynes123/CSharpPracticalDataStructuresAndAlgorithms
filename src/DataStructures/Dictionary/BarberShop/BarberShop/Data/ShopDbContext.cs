using System;
using BarberShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class ShopDbContext: DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options): base(options)
        {
        }
        public DbSet<Service> Services { get; set; } = default!;
    }
}

