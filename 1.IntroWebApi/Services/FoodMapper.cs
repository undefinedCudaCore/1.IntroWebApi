using _1.IntroWebApi.Models;
using _1.IntroWebApi.Models.Dto;

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
