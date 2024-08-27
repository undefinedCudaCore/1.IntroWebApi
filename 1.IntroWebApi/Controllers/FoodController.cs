using _1.IntroWebApi.ActionFilters;
using _1.IntroWebApi.Data;
using _1.IntroWebApi.Services;
using IntroWepApi.Domain.Models;
using IntroWepApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace _1._IntroWebApi.Controllers
{
    [Route("api/food")]
    [ApiController]
    //[IpAddress]
    //[Authorize]
    public class FoodController : ControllerBase
    {
        private readonly IFoodStoreService _foodStoreService;
        private readonly IFoodExpiryService _foodExpiryService;
        private readonly IFoodMapper _foodMapper;
        private readonly IBusinessLogicService _businessLogicService;

        // Dependency Inversion/IoC are design patterns

        // Dependency inversion principle says that we should depend on abstractions (In this scenario we use interfaces)
        // For dependency injection we have to fulfill adding necesarry parameters for WebApplication.Services to inject coresponding implementations

        // 1. Add Paramter to constructor
        // 2. Create readonly field
        // 3. Assign readonly field with provided argument
        // 4. Register your service in Program.cs builder.Services
        // 5. Test
        public FoodController(IFoodStoreService foodStoreService, IFoodExpiryService foodExpiryService, IFoodMapper foodMapper, IBusinessLogicService businessLogicService)
        {
            _foodStoreService = foodStoreService;
            _foodExpiryService = foodExpiryService;
            _foodMapper = foodMapper;
            _businessLogicService = businessLogicService;
        }

        [ApiKeyAuth]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Food>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Food>> GetAllFood()
        {
            _foodExpiryService.AddExpirationDateTime(5);
            _businessLogicService.LogBusinessDeliver();

            var response = _foodStoreService.FoodList
                .Select(_foodMapper.Bind)
                .ToList();

            return Ok(response);
        }

        [HttpGet("{id:int}", Name = "GetFood")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Food))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Food?> GetFoodById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var foodProduct = _foodStoreService.FoodList
                .FirstOrDefault(fp => fp.Id == id);

            if (foodProduct == null)
            {
                return NotFound();
            }

            return Ok(foodProduct);
        }

        [HttpPost]
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

            int lastFoodId = _foodStoreService.FoodList // .Max(fp => fp.Id);
                .OrderByDescending(fp => fp.Id)
                .First().Id;

            food.Id = lastFoodId + 1;

            _foodStoreService.FoodList.Add(food);

            return CreatedAtRoute("GetFood", new { id = food.Id }, food);
        }

        [HttpDelete("{id:int}", Name = "DeleteFood")]
        public IActionResult DeleteFood(int id)
        {
            var foodToDelete = _foodStoreService.FoodList
                .FirstOrDefault(f => f.Id == id);

            if (foodToDelete == null)
            {
                return NotFound();
            }

            _foodStoreService.FoodList.Remove(foodToDelete);

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateFood")]
        public void UpdateFood(int id, Food food)
        {
            var foodToUpdate = _foodStoreService.FoodList
                .FirstOrDefault(f => f.Id == id);

            foodToUpdate.Name = food.Name;
            foodToUpdate.Weight = food.Weight;
            foodToUpdate.Country = food.Country;
        }
    }
}