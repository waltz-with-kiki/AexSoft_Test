using AexSoft_Test.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoft_Test.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<TVShow> TVShows { get; set; }

        public DbSet<ActorMovie> ActorsMovies { get; set; }
        public DbSet<ActorTVShow> ActorsTVShows { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActorTVShow>()
                .HasKey(a => new { a.ActorId, a.TVShowId });
            modelBuilder.Entity<ActorMovie>()
                .HasKey(a => new { a.ActorId, a.MovieId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=app.db");
            }
        }
    }
}
