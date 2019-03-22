using AspNetCoreDemo.RazorComponents.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspNetCoreDemo.RazorComponents.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext()
        {

        }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().Property(e => e.Cast)
                .HasConversion(v => string.Join(",", v),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Movie>().Property(e => e.Genres)
               .HasConversion(v => string.Join(",", v),
               v => v.Split(",", StringSplitOptions.RemoveEmptyEntries));
        }
    }

}
