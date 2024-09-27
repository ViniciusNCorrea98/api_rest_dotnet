using Microsoft.EntityFrameworkCore;
using API_REST_DOTNET.Entities;

namespace API_REST_DOTNET.Data{

    public class DataContext : DbContext{

        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<SuperHero> SuperHeroes {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SuperHero>().HasData(
                new SuperHero { Id = 1, FirstName = "Clark", LastName = "Brady", Place = "New York"},
                new SuperHero { Id = 2, FirstName = "John", LastName = "Travolta", Place = "Sacramento"}
            )
        }
    }
}