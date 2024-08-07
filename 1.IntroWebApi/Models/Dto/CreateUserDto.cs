namespace _1.IntroWebApi.Models.Dto
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
    }
}
