using _1._IntroWebApi.Models;
using _1._IntroWebApi.Services.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace _1._IntroWebApi.Services
{
    public interface IAccountService
    {
        void Register(string username, string password);
        bool Login(string username, string password);
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Register(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            Account account = new Account
            {
                Username = username,
                Password = passwordHash,
                Salt = passwordSalt
            };
            _accountRepository.Add(account);

        }
        public bool Login(string username, string password)
        {
            var acc = _accountRepository.Get(username);

            if (acc == null)
            {
                return false;
            }

            if (VerifyPasswordHash(password, acc.Password, acc.Salt))
            {
                return true;
            }

            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hash.SequenceEqual(passwordHash);

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}