using System;
using Microsoft.EntityFrameworkCore;
using Movies.Features.Movies.Models;

namespace Movies.Data
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(movie => movie.ID);
                entity.Property(movie => movie.Title);
                entity.Property(movie => movie.ReleaseDate);
                entity.Property(movie => movie.Genre).HasConversion<int>();
                entity.Property(movie => movie.Price);
                
            });
        }
    }
}

