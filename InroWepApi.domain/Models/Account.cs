namespace IntroWepApi.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
    }
}