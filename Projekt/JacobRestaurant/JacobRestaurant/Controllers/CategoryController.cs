using JacobRestaurant.Models;
using JacobRestaurant.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JacobRestaurant.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ViewResult> List()
        { 
            return View(await _categoryRepository.ListAll());
        }

        public async Task<ViewResult> Details(int id)
        {
            return View(await _categoryRepository.GetById(id));
        }

        public async Task<ViewResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.Add(category);
                return RedirectToAction("List");
            }
            else
                return RedirectToAction("Create");
        }
        public async Task<RedirectToActionResult> Delete(int id)
        {
            await _categoryRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}
