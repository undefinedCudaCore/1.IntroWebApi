using _1.IntroWebApi.Models.Dto;

namespace _1.IntroWebApi.Data
{
    public static class FoodStore
    {
        public static List<Food> FoodList { get; set; } = new List<Food>()
        {
            new Food(1, "Orange", "Spain", 7.5),
            new Food(2, "Apple", "Spain", 12),
            new Food(3, "Banana", "Africa", 4.75),
            new Food(4, "Margarita pizza", "Italy", 0.5),
            new Food(5, "German Sausages", "Germany", 8),
            new Food(6, "Potatoes", "Lithunia", 10),
        };

    }


    public class FoodStoreService : IFoodStoreService
    {

        public FoodStoreService()
        {
            _serviceInstanceId = Guid.NewGuid();
        }

        private Guid _serviceInstanceId;
        public Guid ServiceInstanceId { get { return _serviceInstanceId; } }

        public List<Food> FoodList { get; set; } = new List<Food>()
        {
            new Food(1, "Orange", "Spain", 7.5),
            new Food(2, "Apple", "Spain", 12),
            new Food(3, "Banana", "Africa", 4.75),
            new Food(4, "Margarita pizza", "Italy", 0.5),
            new Food(5, "German Sausages", "Germany", 8),
            new Food(6, "Potatoes", "Lithunia", 10),
        };
    }

    public interface IFoodStoreService
    {
        public List<Food> FoodList { get; set; }
    }
}
