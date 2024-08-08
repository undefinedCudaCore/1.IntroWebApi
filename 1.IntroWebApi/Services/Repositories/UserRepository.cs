using _1.IntroWebApi.Database;
using _1.IntroWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace _1.IntroWebApi.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodDbContext _dbContext;

        public UserRepository(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUserAsync(User user)
        {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }

    public interface IUserRepository
    {
        public Task AddUserAsync(User user);
        public Task<IList<User>> GetUsersAsync();
        public Task<User?> GetUserByIdAsync(Guid id);
    }
}
