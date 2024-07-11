using _1.IntroWebApi.Data;

namespace _1.IntroWebApi.Services
{
    public class FoodExpiryService : IFoodExpiryService
    {
        private readonly IFoodStoreService _foodStoreService;

        public FoodExpiryService(IFoodStoreService foodStoreService)
        {
            _foodStoreService = foodStoreService;
        }

        public void AddExpirationDateTime(int foodId)
        {
            var foundFood = _foodStoreService.FoodList
                .FirstOrDefault(f => f.Id.Equals(foodId));
            foundFood.ExpirationDateTime = DateTime.Now.AddDays(50);
        }
    }

    public interface IFoodExpiryService
    {
        public void AddExpirationDateTime(int foodId);
    }
}
