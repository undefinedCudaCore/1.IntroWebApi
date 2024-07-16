using _1.IntroWebApi.Models;
using _1.IntroWebApi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _1.IntroWebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return users;
        }

        [HttpPost]
        public async Task CreateUser([FromBody] User request)
        {
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Email))
            {
                throw new ArgumentException("TEST");
            }

            request.Id = Guid.NewGuid();

            await _userRepository.AddUserAsync(request);
        }
    }
}
