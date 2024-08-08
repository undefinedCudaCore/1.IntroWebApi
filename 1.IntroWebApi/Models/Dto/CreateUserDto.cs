using _1.IntroWebApi.Atributes;

namespace _1.IntroWebApi.Models.Dto
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        [MaxFileSize(15 * 1024 * 1024)] //15MB
        [AllowedExtrention([".jpeg", ".jpg", ".png"])]
        public IFormFile Image { get; set; }
    }
}
