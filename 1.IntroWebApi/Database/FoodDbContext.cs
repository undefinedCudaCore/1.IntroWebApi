using _1.IntroWebApi.Database.Configurations;
using _1.IntroWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace _1.IntroWebApi.Database
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
