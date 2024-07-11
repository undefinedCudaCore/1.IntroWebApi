namespace _1.IntroWebApi.Models.Dto
{
    public class Food
    {
        public Food(int id, string name, string country, double weight)
        {
            Id = id;
            Name = name;
            Country = country;
            Weight = weight;
            CreationDateTime = DateTime.Now;
            ExpirationDateTime = DateTime.Now.AddDays(30);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double Weight { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ExpirationDateTime { get; set; }
    }
}
