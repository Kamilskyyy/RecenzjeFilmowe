using RecenzjeFilmowe.Server.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RecenzjeFilmowe.Server.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Film> Filmy { get; set; }
        public DbSet<Recenzja> Recenzje { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasKey(film => film.Id);

            modelBuilder.Entity<Recenzja>()
                .HasKey(recenzja => recenzja.Id);

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Recenzje)
                .WithOne(r => r.Film)
                .HasForeignKey(r => r.FilmId);

            base.OnModelCreating(modelBuilder);
        }

    }
}

