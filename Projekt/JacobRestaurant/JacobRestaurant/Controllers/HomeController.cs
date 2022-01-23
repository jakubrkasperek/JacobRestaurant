using Microsoft.AspNetCore.Mvc;

namespace JacobRestaurant.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
