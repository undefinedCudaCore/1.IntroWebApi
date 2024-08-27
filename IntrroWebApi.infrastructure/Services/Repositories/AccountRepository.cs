using IntroWebApi.Infrastructure.Database;
using IntroWepApi.Domain.Models;

namespace IntroWebApi.Infrastructure.Services.Repositories
{
    public interface IAccountRepository
    {
        void Add(Account account);
        Account Get(string username);
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly FoodDbContext _dbContext;

        public AccountRepository(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }
        public Account Get(string username)
        {
            return _dbContext.Accounts.FirstOrDefault(x => x.Username == username);
        }
    }
}