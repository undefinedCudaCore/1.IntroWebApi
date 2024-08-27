using IntroWebApi.Infrastructure.Database.Configurations;
using IntroWepApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroWebApi.Infrastructure.Database
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
