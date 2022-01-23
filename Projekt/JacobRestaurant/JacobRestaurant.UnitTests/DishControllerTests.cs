using JacobRestaurant.Controllers;
using JacobRestaurant.Models;
using JacobRestaurant.UnitTests.Mocks;
using JacobRestaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JacobRestaurant.UnitTests
{
    public class DishControllerTests
    {
        [Fact]
        public void List_ReturnsAViewResult_WithAllDishes()
        {
            //arrange
            var mockDishRepository = RepositoryMocks.GetDishRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var dishManagmentController = new DishController(mockDishRepository.Object, mockCategoryRepository.Object);

            //act
            var result = dishManagmentController.List();

            //assert
            var viewResult = Assert.IsType<Task<ViewResult>>(result);
            var dishes = Assert.IsAssignableFrom<DishListViewModel>(viewResult.Result.ViewData.Model);
            Assert.Equal(11, dishes.Dishes.Count());
        }
        

        [Fact]
        public void DishDetails_ReturnsAViewResult_WithDishDetails()
        {
            //arrange
            var mockDishRepository = RepositoryMocks.GetDishRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var dishManagmentController = new DishController(mockDishRepository.Object, mockCategoryRepository.Object);

            //act
            var result = dishManagmentController.Details(1);

            //assert
            var viewResult = Assert.IsType<Task<ViewResult>>(result);
            Assert.NotNull(viewResult.Result.Model);
        }

        
        [Fact]
        public async Task CreateDish_POST_SuccessfulyCreateDish_AndRedirectToAction()
        {
            //arrange
            var mockDishRepository = RepositoryMocks.GetDishRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            mockDishRepository.Setup(repo => repo.Add(It.IsAny<Dish>())).Verifiable();

            var dishManagmentController = new DishController(mockDishRepository.Object, mockCategoryRepository.Object);

            Dish dishToCreate = new Dish
            {
                DishId = 12,
                Name = "New Dish",
                CategoryId = 2,
                Description = "New Description",
                Price = 40.99M,
                ImageUrl = "https://cdn.pixabay.com/photo/2016/09/13/18/38/silverware-1667988_960_720.png",
            };

            UpdateDishViewModel editDishToCreateViewModel = new UpdateDishViewModel { Dish = dishToCreate, Categories = await mockCategoryRepository.Object.ListAll() };

            //act
            var result = dishManagmentController.Create(editDishToCreateViewModel);

            //assert
            var redirect = Assert.IsType<Task<RedirectToActionResult>>(result);
            Assert.Equal("List", redirect.Result.ActionName);

            mockDishRepository.Verify();
        }
        

        [Fact]
        public async Task EditDish_POST_SuccessfulyUpdateDish_AndRedirectToAction()
        {
            //arrange
            var mockDishRepository = RepositoryMocks.GetDishRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            mockDishRepository.Setup(repo => repo.Update(It.IsAny<Dish>())).Verifiable();

            var dishManagmentController = new DishController(mockDishRepository.Object, mockCategoryRepository.Object);

            Dish dishToEdit = new Dish
            {
                DishId = 12,
                Name = "Edited Dish",
                CategoryId = 2,
                Description = "Edited Description",
                Price = 99.99M,
                ImageUrl = "https://cdn.pixabay.com/photo/2016/09/13/18/38/silverware-1667988_960_720.png",
            };

            UpdateDishViewModel dishToEditViewModel = new UpdateDishViewModel { Dish = dishToEdit, Categories =  await mockCategoryRepository.Object.ListAll() };

            //act
            var result = dishManagmentController.Update(dishToEditViewModel);

            //assert
            var redirect = Assert.IsType<Task<RedirectToActionResult>>(result);
            Assert.Equal("List", redirect.Result.ActionName);
            mockDishRepository.Verify();
        }

        [Fact]
        public void DeleteDish_POST_SuccessfulyDeleteDish_AndRedirectToList()
        {
            //arrange
            var mockDishRepository = RepositoryMocks.GetDishRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            mockDishRepository.Setup(repo => repo.Delete(It.IsAny<int>())).Verifiable();

            var dishManagmentController = new DishController(mockDishRepository.Object, mockCategoryRepository.Object);

            //act
            var result = dishManagmentController.Delete(1);

            //assert
            var redirect = Assert.IsType<Task<RedirectToActionResult>>(result);
            Assert.Equal("List", redirect.Result.ActionName);

            mockDishRepository.Verify();
        }

    }
}
