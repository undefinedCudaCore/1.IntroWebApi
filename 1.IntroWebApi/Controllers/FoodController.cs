using _1.IntroWebApi.Data;
using _1.IntroWebApi.Models.Dto;
using _1.IntroWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace _1.IntroWebApi.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodStoreService _foodStoreService;
        private readonly IFoodExpiryService _foodExpiryService;

        //Dependency Invertion IoC are design patterns
        //Dependency Invertion principle says that we should depend on abstractions (In this scenario we use interfaces)
        //Fort dependency injection we have to fulfill adding necesary parameters for WebApplication.Services to inject coresponding implementations
        public FoodController(IFoodStoreService foodStoreService, IFoodExpiryService foodExpiryService)
        {
            _foodStoreService = foodStoreService;
            _foodExpiryService = foodExpiryService;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Food>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Food>> GetAllFood()
        {
            _foodExpiryService.AddExpirationDateTime(5);
            return Ok(_foodStoreService.FoodList);
        }

        [HttpGet("{id:int}", Name = "GetFood")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Food))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Food?> GetFoodById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var foodProducts = _foodStoreService.FoodList
                .FirstOrDefault(fp => fp.Id == id);

            if (foodProducts == null)
            {
                return NotFound();
            }

            return Ok(foodProducts);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Food))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Food> CreateFood(Food food)
        {
            if (food == null)
            {
                return BadRequest();
            }

            if (food.Id > 0)
            {
                return BadRequest();
            }

            //int getLastFoodId = FoodStore.FoodList.Max(fp => fp.Id);
            int getLastFoodId = _foodStoreService.FoodList.Last().Id;

            food.Id = getLastFoodId + 1;

            _foodStoreService.FoodList.Add(food);

            return CreatedAtRoute("GetFood", new { id = food.Id }, food);
        }

        [HttpDelete("{id:int}", Name = "DeleteFood")]
        public IActionResult DeleteFoodById(int id)
        {
            var foodToDelete = _foodStoreService.FoodList.FirstOrDefault(fp => fp.Id == id);

            _foodStoreService.FoodList.Remove(foodToDelete);

            if (foodToDelete == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateFood")]
        public void UpdateFood(Food food, int id)
        {
            var foodToUpdate = _foodStoreService.FoodList.FirstOrDefault(fp => fp.Id == id);

            foodToUpdate.Name = food.Name;
            foodToUpdate.Weight = food.Weight;
            foodToUpdate.Country = food.Country;
        }
    }
}
