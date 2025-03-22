using AccountingMVC.Models;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AccountingMVC.Controllers
{
    public class FundsController : Controller
    {
        private readonly IFundsAppService _fundsAppService;

        public FundsController(IFundsAppService fundsAppService)
        {
            _fundsAppService = fundsAppService;
        }

        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            int userId = int.Parse(userIdClaim.Value);
            var funds = await _fundsAppService.GetFundsByUserIdAsync(userId);

            var model = funds.Select(f => new FundsViewModel
            {
                Id = f.Id,
                Name = f.Name,
                IsPublic = f.IsPublic,
                PersonConditions = f.PersonConditions
            }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FundsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            int userId = int.Parse(userIdClaim.Value);

            var fund = new Funds
            {
                Name = model.Name,
                IsPublic = model.IsPublic,
                PersonConditions = model.PersonConditions, 
                UserId = userId
            };

            await _fundsAppService.AddFundsAsync(fund);
            return RedirectToAction(nameof(Index));
        }
    }
}
