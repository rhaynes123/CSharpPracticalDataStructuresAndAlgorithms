using System;
using Microsoft.EntityFrameworkCore;
using Movies.Features.Models;

namespace Movies.Data
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; } = default!;
    }
}

