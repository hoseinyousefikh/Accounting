using AccountingMVC.Models;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.AppServices.payment;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.Contract.Services.payment;
using App.Domain.Core.Accounting.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AccountingMVC.Controllers
{
    public class CriticismController : Controller
    {

        private readonly ICriticismAppService _criticismAppService;
        private readonly ISubCategoryCostAppService _subCategoryCostAppService;
        private readonly ICategoryCostAppService _categoryCostAppService;


        public CriticismController(ICriticismAppService criticismAppService, ISubCategoryCostAppService subCategoryCostAppService, ICategoryCostAppService categoryCostAppService)
        {
            _criticismAppService = criticismAppService;
            _subCategoryCostAppService = subCategoryCostAppService;
            _categoryCostAppService = categoryCostAppService;
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdString, out var userId))
            {
                return BadRequest("Invalid user ID.");
            }

            var categoryCosts = await _categoryCostAppService.GetCategoryCostByUserIdAsync(1);

            var viewModel = new CriticismViewModel
            {
                CategoryCosts = categoryCosts
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubcategories(int categoryId)
        {
            var subcategories = await _subCategoryCostAppService.GetSubCatCostByCategoryIdAsync(categoryId);
            return Json(subcategories);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriticismViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var criticismRequest = new CriticismRequestDto
            {
                Date = viewModel.Date,
                Time = viewModel.Time,
                Amount = viewModel.Amount,
                Description = viewModel.Description,
                SubcategoryCostId = viewModel.SubcategoryCostId,
                SubcategoryIncomeId = viewModel.SubcategoryIncomeId,
                MemderId = viewModel.MemderId,
                EventId = viewModel.EventId,
                ProjectId = viewModel.ProjectId,
                UserId = viewModel.UserId,
                FromAccountId = viewModel.FromAccountId,
                Xxpenses = viewModel.Xxpenses
            };

            await _criticismAppService.AddCriticismAsync(criticismRequest);

            TempData["SuccessMessage"] = "Criticism added successfully.";
            return RedirectToAction("Index", "Home");
        }
    }
}
