using _1.IntroWebApi.Controllers;
using _1.IntroWebApi.Data;
using _1.IntroWebApi.Models;
using _1.IntroWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace IntroWebApi.Test
{
    public class FoodControllerTest
    {
        [Theory, FoodData]
        public void GetFoodById_ReturnsOkProduct_Success(Food food)
        {
            //Arrange
            var foodStoreServiceMock = new Mock<IFoodStoreService>();
            var foodExpiryServiceMock = new Mock<IFoodExpiryService>();
            var foodMapperMock = new Mock<IFoodMapper>();

            //sut - Subject Under Test
            var sut = new FoodController(foodStoreServiceMock.Object, foodExpiryServiceMock.Object, foodMapperMock.Object);


            List<Food> list = new List<Food>();
            list.Add(food);

            //setup mock
            foodStoreServiceMock.Setup(x => x.FoodList).Returns(list);

            //Act
            var response = sut.GetFoodById(food.Id);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var returnValue = Assert.IsType<Food>(okResult.Value);
            Assert.Equal(food, returnValue);
        }

        [Fact]
        public void GetFoodById_NotFound_Failed()
        {
            //Arrange
            var foodStoreServiceMock = new Mock<IFoodStoreService>();
            var foodExpiryServiceMock = new Mock<IFoodExpiryService>();
            var foodMapperMock = new Mock<IFoodMapper>();

            //sut - Subject Under Test
            var sut = new FoodController(foodStoreServiceMock.Object, foodExpiryServiceMock.Object, foodMapperMock.Object);

            //setup mock
            foodStoreServiceMock.Setup(x => x.FoodList).Returns(new List<Food>());

            //Act
            var response = sut.GetFoodById(1);

            //Assert
            var okResult = Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public void GetAllFood_Calls_AddExpirationDateTime_Success()
        {
            //Arrange
            var foodStoreServiceMock = new Mock<IFoodStoreService>();
            var foodExpiryServiceMock = new Mock<IFoodExpiryService>();
            var foodMapperMock = new Mock<IFoodMapper>();

            //sut - Subject Under Test
            var sut = new FoodController(foodStoreServiceMock.Object, foodExpiryServiceMock.Object, foodMapperMock.Object);

            //setup mock
            foodExpiryServiceMock.Setup(x => x.AddExpirationDateTime(It.IsAny<int>())).Verifiable();
            foodStoreServiceMock.Setup(x => x.FoodList).Returns(new List<Food>());

            //Act
            var response = sut.GetAllFood();

            //Assert
            foodExpiryServiceMock.Verify(service => service.AddExpirationDateTime(It.IsAny<int>()), Times.Once);
        }
    }
}