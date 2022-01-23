using JacobRestaurant.Models.Auth;
using JacobRestaurant.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JacobRestaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            var user = await _userManager.FindByNameAsync(loginViewModel.Email);
            if(user != null)
            {
                var isLoggedIn = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if(isLoggedIn.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                    return View(loginViewModel);
            }
            else
                return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var user = new AppUser()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };

            var isCreated = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (isCreated.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Register");
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
