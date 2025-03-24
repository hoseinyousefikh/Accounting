using AccountingMVC.Models;
using App.Domain.AppServices.Accounting.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.AppServices.Budgetings;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Budgetings;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AccountingMVC.Controllers
{
    public class BudgetingController : Controller
    {
        private readonly IBudgetingAppService _budgetingAppService;
        private readonly ICategoryIncomeAppService _categoryIncomeAppService;
        private readonly ISubcategoryIncomeAppService _subcategoryIncomeAppService;
        private readonly ISubCategoryCostAppService _subCategoryCostAppService;
        private readonly ICategoryCostAppService _categoryCostAppService;
        public BudgetingController(IBudgetingAppService budgetingAppService, ICategoryIncomeAppService categoryIncomeAppService, ISubcategoryIncomeAppService subcategoryIncomeAppService, ISubCategoryCostAppService subCategoryCostAppService, ICategoryCostAppService categoryCostAppService)
        {
            _budgetingAppService = budgetingAppService;
            _categoryIncomeAppService = categoryIncomeAppService;
            _subcategoryIncomeAppService = subcategoryIncomeAppService;
            _subCategoryCostAppService = subCategoryCostAppService;
            _categoryCostAppService = categoryCostAppService;
        }

        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            int userId = int.Parse(userIdClaim.Value);
            var budgetings = await _budgetingAppService.GetBudgetingByUserIdAsync(userId);

            var model = budgetings.Select(b => new BudgetingViewModel
            {

                Id = b.Id,
                Timings = b.timings,
                Xxpenses = b.Xxpenses,
                MinAmount = b.MinAmount,
                MaxAmount = b.MaxAmount,
                FDate = b.FDate,
                TDate = b.TDate
            }).ToList();

            return View(model);
        }

        public IActionResult Create(int? subcategoryCostId, string subcategoryCostName, int categoryCostId, string categoryCostName, int? subcategoryIncomeId, string subcategoryIncomeName, int categoryIncomeId, string categoryIncomeName)
        {

            SetCategoryCostData(categoryCostId, categoryCostName);
            SetSubcategoryCostData(subcategoryCostId, subcategoryCostName);
            SetCategoryIncomeData(categoryIncomeId, categoryIncomeName);
            SetSubcategoryIncomeData(subcategoryIncomeId, subcategoryIncomeName);

            var result = new BudgetingViewModel
            {
                SubCategoryCostId = HttpContext.Session.GetInt32("SubcategoryCostId") ?? 0,
                CategoryCostId = HttpContext.Session.GetInt32("CategoryCostId") ?? 0,
                CategoryCostName = HttpContext.Session.GetString("CategoryCostName"),
                SubcategoryCostName = HttpContext.Session.GetString("SubcategoryCostName"),
                SubCategoryIncomeId = HttpContext.Session.GetInt32("SubcategoryIncomeId") ?? 0,
                CategoryIncomeId = HttpContext.Session.GetInt32("CategoryIncomeId") ?? 0,
                CategoryIncomeName = HttpContext.Session.GetString("CategoryIncomeName"),
                SubcategoryIncomeName = HttpContext.Session.GetString("SubcategoryIncomeName"),
            };

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BudgetingViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.MinAmount > model.MaxAmount)
            {
                ModelState.AddModelError("MinAmount", "مبلغ حداقل نباید بیشتر از مبلغ حداکثر باشد.");
                return View(model);
            }

            if (model.FDate > model.TDate)
            {
                ModelState.AddModelError("FDate", "تاریخ شروع نباید بعد از تاریخ پایان باشد.");
                return View(model);
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
           

            int userId = int.Parse(userIdClaim.Value);
            var budgeting = new Budgeting
            {
                timings = model.Timings,
                Xxpenses = model.Xxpenses,
                MinAmount = model.MinAmount,
                MaxAmount = model.MaxAmount,
                FDate = model.FDate,
                TDate = model.TDate,
                UserId = userId,
                SubCategoryCostId = model.SubCategoryCostId,
                SubCategoryIncomeId = model.SubCategoryIncomeId,
               
                
            };

            await _budgetingAppService.AddBudgetingAsync(budgeting);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id, int? subcategoryCostId, string subcategoryCostName, int categoryCostId, string categoryCostName, int? subcategoryIncomeId, string subcategoryIncomeName, int categoryIncomeId, string categoryIncomeName)
        {
            SetCategoryCostData(categoryCostId, categoryCostName);
            SetSubcategoryCostData(subcategoryCostId, subcategoryCostName);
            SetCategoryIncomeData(categoryIncomeId, categoryIncomeName);
            SetSubcategoryIncomeData(subcategoryIncomeId, subcategoryIncomeName);

            var budgeting = await _budgetingAppService.GetBudgetingByIdAsync(id);
            if (budgeting == null)
            {
                return NotFound();
            }

            if (budgeting.SubCategoryIncomeId.HasValue && budgeting.SubCategoryIncomeId.Value != 0)
            {
                var resultIncome = budgeting.SubCategoryIncomeId.HasValue
              ? await _subcategoryIncomeAppService.GetByIdSubCatIncomeAsync(budgeting.SubCategoryIncomeId.Value)
              : null;
                if (HttpContext.Session.GetString("SubcategoryIncomeName") == null)
                {
                    HttpContext.Session.SetString("SubcategoryIncomeName", resultIncome?.Name ?? subcategoryIncomeName ?? "نام مشخص نشده");
                }

            }
            else
            {
                var resultCost = budgeting.SubCategoryCostId.HasValue
                   ? await _subCategoryCostAppService.GetByIdSubCatCostAsync(budgeting.SubCategoryCostId.Value)
                   : null;
               
                if (HttpContext.Session.GetString("SubcategoryCostName") == null)
                {
                    HttpContext.Session.SetString("SubcategoryCostName", resultCost?.Name ?? subcategoryCostName ?? "نام مشخص نشده");
                }
            }

            var model = new BudgetingViewModel
            {
                Id = budgeting.Id,
                Timings = budgeting.timings,
                Xxpenses = budgeting.Xxpenses,
                MinAmount = budgeting.MinAmount,
                MaxAmount = budgeting.MaxAmount,
                FDate = budgeting.FDate,
                TDate = budgeting.TDate,

                SubCategoryCostId = HttpContext.Session.GetInt32("SubcategoryCostId") ?? subcategoryCostId ?? 0,
                CategoryCostId = HttpContext.Session.GetInt32("CategoryCostId") ?? categoryCostId,
                CategoryCostName = HttpContext.Session.GetString("CategoryCostName") ?? categoryCostName,
                SubcategoryCostName = HttpContext.Session.GetString("SubcategoryCostName"),

                SubCategoryIncomeId = HttpContext.Session.GetInt32("SubcategoryIncomeId") ?? subcategoryIncomeId ?? 0,
                CategoryIncomeId = HttpContext.Session.GetInt32("CategoryIncomeId") ?? categoryIncomeId,
                CategoryIncomeName = HttpContext.Session.GetString("CategoryIncomeName") ?? categoryIncomeName,
                SubcategoryIncomeName = HttpContext.Session.GetString("SubcategoryIncomeName")
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BudgetingViewModel model)//
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.MinAmount > model.MaxAmount)
            {
                ModelState.AddModelError("MinAmount", "مبلغ حداقل نباید بیشتر از مبلغ حداکثر باشد.");
                return View(model);
            }

            if (model.FDate > model.TDate)
            {
                ModelState.AddModelError("FDate", "تاریخ شروع نباید بعد از تاریخ پایان باشد.");
                return View(model);
            }
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            int userId = int.Parse(userIdClaim.Value);
            var budgeting = new Budgeting
            {
                Id = model.Id,
                timings = model.Timings,
                Xxpenses = model.Xxpenses,
                MinAmount = model.MinAmount,
                MaxAmount = model.MaxAmount,
                FDate = model.FDate,
                TDate = model.TDate,
                SubCategoryCostId = model.SubCategoryCostId,
                SubCategoryIncomeId = model.SubCategoryIncomeId,
                UserId = userId
            };

            await _budgetingAppService.UpdateBudgetingAsync(budgeting);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var budgeting = await _budgetingAppService.GetBudgetingByIdAsync(id);
            if (budgeting == null)
            {
                return NotFound();
            }

            return View(new BudgetingViewModel
            {
                Id = budgeting.Id,
                Timings = budgeting.timings,
                Xxpenses = budgeting.Xxpenses,
                MinAmount = budgeting.MinAmount,
                MaxAmount = budgeting.MaxAmount,
                FDate = budgeting.FDate,
                TDate = budgeting.TDate
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _budgetingAppService.DeleteBudgetingAsync(id);
            return RedirectToAction("Index", "Budgeting");
        }

        private void SetCategoryIncomeData(int categoryIncomeId, string categoryIncomeName)
        {
            if (categoryIncomeId > 0 && !string.IsNullOrEmpty(categoryIncomeName))
            {
                HttpContext.Session.SetInt32("CategoryIncomeId", categoryIncomeId);
                HttpContext.Session.SetString("CategoryIncomeName", categoryIncomeName);
            }
        }
        private void SetSubcategoryIncomeData(int? subcategoryIncomeId, string subcategoryIncomeName)
        {
            if (subcategoryIncomeId.HasValue && !string.IsNullOrEmpty(subcategoryIncomeName))
            {
                HttpContext.Session.SetInt32("SubcategoryIncomeId", subcategoryIncomeId.Value);
                HttpContext.Session.SetString("SubcategoryIncomeName", subcategoryIncomeName);
            }
        }
        private void SetCategoryCostData(int categoryCostId, string categoryCostName)
        {
            if (categoryCostId > 0 && !string.IsNullOrEmpty(categoryCostName))
            {
                HttpContext.Session.SetInt32("CategoryCostId", categoryCostId);
                HttpContext.Session.SetString("CategoryCostName", categoryCostName);
            }
        }
        private void SetSubcategoryCostData(int? subcategoryCostId, string subcategoryCostName)
        {
            if (subcategoryCostId.HasValue && !string.IsNullOrEmpty(subcategoryCostName))
            {
                HttpContext.Session.SetInt32("SubcategoryCostId", subcategoryCostId.Value);
                HttpContext.Session.SetString("SubcategoryCostName", subcategoryCostName);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesIncomeCreate()
        {
            int userId = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {

            }
            var categoryIncomes = await _categoryIncomeAppService.GetCategoryIncomeByUserIdAsync(userId);
            var viewModel = new BudgetingViewModel
            {
                CategoryIncomes = categoryIncomes
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubcategoriesIncomeCreate(int categoryIncomeId, string categoryIncomeName)
        {
            var subcategories = await _subcategoryIncomeAppService.GetSubcategoryIncomesByCategoryId(categoryIncomeId);

            var viewModel = new BudgetingViewModel
            {
                SubcategoryIncomes = subcategories,
                CategoryIncomeId = categoryIncomeId,
                CategoryIncomeName = categoryIncomeName
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesCostCreate()
        {
            int userId = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {

            }
            var categoryCosts = await _categoryCostAppService.GetCategoryCostByUserIdAsync(userId);
            var viewModel = new BudgetingViewModel
            {
                CategoryCosts = categoryCosts
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubcategoriesCostCreate(int categoryCostId, string categoryCostName)
        {
            var subcategories = await _subCategoryCostAppService.GetSubCatCostByCategoryIdAsync(categoryCostId);

            var viewModel = new BudgetingViewModel
            {
                SubcategoryCosts = subcategories,
                CategoryCostId = categoryCostId,
                CategoryCostName = categoryCostName
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesIncomeEdit(int id)
        {
            int userId = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {

            }
            var categoryIncomes = await _categoryIncomeAppService.GetCategoryIncomeByUserIdAsync(userId);
            var viewModel = new BudgetingViewModel
            {
                Id = id,
                CategoryIncomes = categoryIncomes
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubcategoriesIncomeEdit(int categoryIncomeId, string categoryIncomeName, int id)
        {
            var subcategories = await _subcategoryIncomeAppService.GetSubcategoryIncomesByCategoryId(categoryIncomeId);

            var viewModel = new BudgetingViewModel
            {
                Id = id,
                SubcategoryIncomes = subcategories,
                CategoryIncomeId = categoryIncomeId,
                CategoryIncomeName = categoryIncomeName
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesCostEdit(int id)
        {
            int userId = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {

            }
            var categoryCosts = await _categoryCostAppService.GetCategoryCostByUserIdAsync(userId);
            var viewModel = new BudgetingViewModel
            {
                Id =id,
                CategoryCosts = categoryCosts
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubcategoriesCostEdit(int categoryCostId, string categoryCostName, int id)
        {
            var subcategories = await _subCategoryCostAppService.GetSubCatCostByCategoryIdAsync(categoryCostId);

            var viewModel = new BudgetingViewModel
            {
                Id=id,
                SubcategoryCosts = subcategories,
                CategoryCostId = categoryCostId,
                CategoryCostName = categoryCostName
            };

            return View(viewModel);
        }


    }
}
