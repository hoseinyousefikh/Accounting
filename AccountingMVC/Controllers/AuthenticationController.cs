using AccountingMVC.Models;
using App.Domain.Core.Accounting.Contract.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace AccountingMVC.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly IUserAppService _userAppService;

        public AuthenticationController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userAppService.LoginAsync(model.Username, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "نام کاربری یا رمز عبور اشتباه است.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userAppService.RegisterUserAsync(model.Username, model.Password, model.FirstName, model.LastName, model.Email);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
    }

}
