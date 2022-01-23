using JacobRestaurant.Repositories;
using JacobRestaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JacobRestaurant.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishRepository _dishRepository;
        private readonly ICategoryRepository _categoryRepository;
        public DishController(IDishRepository dishRepository, ICategoryRepository categoryRepository)
        {
            _dishRepository = dishRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ViewResult> List()
        {
            DishListViewModel dishListViewModel = new DishListViewModel();
            dishListViewModel.Dishes = await _dishRepository.ListAll();

            return View(dishListViewModel);
        }

        public async Task<ViewResult> Details(int id)
        {
            return View(await _dishRepository.GetById(id));
        }

        public async Task<ViewResult> Create()
        {
            UpdateDishViewModel updateDishViewModel = new UpdateDishViewModel();
            updateDishViewModel.Categories = await _categoryRepository.ListAll();
            return View(updateDishViewModel);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Create(UpdateDishViewModel updateDishViewModel)
        {
            if (ModelState.IsValid)
            {
                await _dishRepository.Add(updateDishViewModel.Dish);
                return RedirectToAction("List");
            }
            else
                return RedirectToAction("Create");
            
        }

        public async Task<ViewResult> Update(int id)
        {
            var dish = await _dishRepository.GetById(id);
            UpdateDishViewModel updateDishViewModel = new UpdateDishViewModel();
            updateDishViewModel.Categories = await _categoryRepository.ListAll();
            updateDishViewModel.Dish = dish;
            return View(updateDishViewModel);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Update(UpdateDishViewModel updateDishViewModel)
        {
            if (ModelState.IsValid)
            {
                await _dishRepository.Update(updateDishViewModel.Dish);
                return RedirectToAction("List");
            }
            else
                return RedirectToAction("Update", updateDishViewModel.Dish.DishId);
        }

        public async Task<RedirectToActionResult> Delete(int id)
        {
            await _dishRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}
