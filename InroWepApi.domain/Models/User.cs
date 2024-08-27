namespace IntroWepApi.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? City { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
    }
}


