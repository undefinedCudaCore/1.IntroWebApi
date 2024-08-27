using _1.IntroWebApi.Dto;
using IntroWepApi.Domain.Models;

namespace _1.IntroWebApi.Services
{
    public class FoodMapper : IFoodMapper
    {
        public GetFoodDto Bind(Food food)
        {
            return new GetFoodDto(food);
        }

        public Food Bind(GetFoodDto food)
        {
            return new Food(0, food.Name, food.Country, food.Weight);
        }
    }

    public interface IFoodMapper
    {
        public GetFoodDto Bind(Food food);
        public Food Bind(GetFoodDto food);
    }
}
