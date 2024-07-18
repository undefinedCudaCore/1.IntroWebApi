namespace _1.IntroWebApi.Models.Dto
{
    public class GetFoodDto(Food food)
    {
        public string Name { get; set; } = food.Name;
        public string Country { get; set; } = food.Country;
        public double Weight { get; set; } = food.Weight;
        public DateTime ExpirationDateTime { get; set; } = food.ExpirationDateTime;
    }
}
