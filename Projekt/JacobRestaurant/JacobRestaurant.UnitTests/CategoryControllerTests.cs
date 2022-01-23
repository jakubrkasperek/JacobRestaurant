using JacobRestaurant.Controllers;
using JacobRestaurant.Models;
using JacobRestaurant.UnitTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JacobRestaurant.UnitTests
{
    public class CategoryControllerTests
    {
        [Fact]
        public void List_ReturnsAViewResult_WithAllCategories()
        {
            //arrange
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var categoryManagmentController = new CategoryController(mockCategoryRepository.Object);

            //act
            var result = categoryManagmentController.List();

            //assert
            var viewResult = Assert.IsType<Task<ViewResult>>(result);
            var categories = Assert.IsAssignableFrom<List<Category>>(viewResult.Result.Model);
            Assert.Equal(3, categories.Count());
        }

        [Fact]
        public void CategoryDetails_ReturnsAViewResult_WithCategoryDetails()
        {
            //arrange
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var categoryManagmentController = new CategoryController(mockCategoryRepository.Object);

            //act
            var result = categoryManagmentController.Details(1);

            //assert
            var viewResult = Assert.IsType<Task<ViewResult>>(result);
            Assert.NotNull(viewResult.Result.Model);
        }

        [Fact]
        public void CreateCategory_POST_SuccessfulyCreateCategory_AndRedirectToAction()
        {
            //arrange
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            mockCategoryRepository.Setup(repo => repo.Add(It.IsAny<Category>())).Verifiable();

            var categoryManagmentController = new CategoryController(mockCategoryRepository.Object);

            var categoryToCreateName = "New Category";
            Category categoryToCreate = new Category { CategoryId = 20, Name = categoryToCreateName };

            //act
            var result = categoryManagmentController.Create(categoryToCreate);

            //assert
            var redirect = Assert.IsType<Task<RedirectToActionResult>>(result);
            Assert.Equal("List", redirect.Result.ActionName);
            mockCategoryRepository.Verify();
        }


        [Fact]
        public void DeleteCategory_POST_SuccessfulyDeleteCategory_AndRedirectToList()
        {
            //arrange
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            mockCategoryRepository.Setup(repo => repo.Delete(It.IsAny<int>())).Verifiable();

            var categoryManagmentController = new CategoryController(mockCategoryRepository.Object);

            //act
            var result = categoryManagmentController.Delete(1);

            //assert
            var redirect = Assert.IsType<Task<RedirectToActionResult>>(result);
            Assert.Equal("List", redirect.Result.ActionName);

            mockCategoryRepository.Verify();
        }

    }
}
