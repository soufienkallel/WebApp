using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebApplication1.Models
{
    public class AppkicationContext :DbContext
    {
        public AppkicationContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Film> Films { get; set; }

        public DbSet<Producer> Producers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteFilm> FavoriteFilms { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserEmail)
                .IsUnique();
        }



    }
}
