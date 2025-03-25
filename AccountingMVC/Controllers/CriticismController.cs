using AccountingMVC.Models;
using App.Domain.Core.Accounting.Contract.AppServices.AccountIn;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.AppServices.payment;
using App.Domain.Core.Accounting.Contract.AppServices.PMEList;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AccountingMVC.Controllers
{
    [Authorize]
    public class CriticismController : Controller
    {
        private readonly ICriticismAppService _criticismAppService;
        private readonly ISubCategoryCostAppService _subCategoryCostAppService;
        private readonly ICategoryCostAppService _categoryCostAppService;
        private readonly IFromAccountAppService _fromAccountAppService;
        private readonly IMemberAppService _memberAppService;
        private readonly IEventAppService _eventAppService;
        private readonly IProjectAppService _projectAppService;

        public CriticismController(
            ICriticismAppService criticismAppService,
            ISubCategoryCostAppService subCategoryCostAppService,
            ICategoryCostAppService categoryCostAppService,
            IFromAccountAppService fromAccountAppService,
            IMemberAppService memberAppService,
            IEventAppService eventAppService,
            IProjectAppService projectAppService)
        {
            _criticismAppService = criticismAppService;
            _subCategoryCostAppService = subCategoryCostAppService;
            _categoryCostAppService = categoryCostAppService;
            _fromAccountAppService = fromAccountAppService;
            _memberAppService = memberAppService;
            _eventAppService = eventAppService;
            _projectAppService = projectAppService;
        }

        public async Task<IActionResult> Create(int? subcategoryId, string subcategoryName, int categoryId, string categoryName, int? fromAccountSubId, string fromAccountName, int titr, int? memberId, int? EventId, int? ProjectId)
        {
            SetCategoryData(categoryId, categoryName);
            SetSubcategoryData(subcategoryId, subcategoryName);
            SetFromAccountData(fromAccountSubId, fromAccountName);

            int userId = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {
                // UserId is fetched from claim
            }

            var members = await _memberAppService.GetMembersByUserIdAsync(userId);
            var memberNames = members.Select(m => new { m.Id, m.Name }).ToList();
            ViewBag.Member = memberNames;

            var events = await _eventAppService.GetEventByUserIdAsync(userId);
            var eventNames = events.Select(e => new { e.Id, e.Name }).ToList();
            ViewBag.Events = eventNames;

            var project = await _projectAppService.GetProjectsByUserIdAsync(userId);
            var projectNames = project.Select(p => new { p.Id, p.Name }).ToList();
            ViewBag.Projects = projectNames;

            if (memberId.HasValue) HttpContext.Session.SetInt32("MemberId", memberId.Value);
            else memberId = HttpContext.Session.GetInt32("MemberId");

            if (EventId.HasValue) HttpContext.Session.SetInt32("EventId", EventId.Value);
            else EventId = HttpContext.Session.GetInt32("EventId");

            if (ProjectId.HasValue) HttpContext.Session.SetInt32("ProjectId", ProjectId.Value);
            else ProjectId = HttpContext.Session.GetInt32("ProjectId");

            var viewModel = new CriticismViewModel
            {
                CategoryCostId = HttpContext.Session.GetInt32("CategoryCostId") ?? 0,
                CategoryCostName = HttpContext.Session.GetString("CategoryCostName"),
                SubcategoryCostId = HttpContext.Session.GetInt32("SubcategoryCostId") ?? 0,
                SubcategoryCostName = HttpContext.Session.GetString("SubcategoryCostName"),
                FromAccountSubId = HttpContext.Session.GetInt32("FromAccountSubId") ?? 0,
                FromAccountName = HttpContext.Session.GetString("FromAccountName"),
                FromAccountId = HttpContext.Session.GetInt32("FromAccountId") ?? 0,
                MemberId = memberId,
                EventId = EventId,
                ProjectId = ProjectId,
                Date = DateTime.Now.Date,
                Time = DateTime.Now
            };

            int fromId = await CreateFromAccount(fromAccountSubId, titr);

            if (fromId > 0)
            {
                viewModel.FromAccountId = fromId;
                HttpContext.Session.SetInt32("FromAccountId", fromId);
            }

            return View(viewModel);
        }

        private void SetCategoryData(int categoryId, string categoryName)
        {
            if (categoryId > 0 && !string.IsNullOrEmpty(categoryName))
            {
                HttpContext.Session.SetInt32("CategoryCostId", categoryId);
                HttpContext.Session.SetString("CategoryCostName", categoryName);
            }
        }

        private void SetSubcategoryData(int? subcategoryId, string subcategoryName)
        {
            if (subcategoryId.HasValue && !string.IsNullOrEmpty(subcategoryName))
            {
                HttpContext.Session.SetInt32("SubcategoryCostId", subcategoryId.Value);
                HttpContext.Session.SetString("SubcategoryCostName", subcategoryName);
            }
        }

        private void SetFromAccountData(int? fromAccountSubId, string fromAccountName)
        {
            if (fromAccountSubId.HasValue && !string.IsNullOrEmpty(fromAccountName))
            {
                HttpContext.Session.SetInt32("FromAccountSubId", fromAccountSubId.Value);
                HttpContext.Session.SetString("FromAccountName", fromAccountName);
            }
        }

        private async Task<int> CreateFromAccount(int? fromAccountSubId, int titr)
        {
            FromAccountCreateDto N = titr switch
            {
                1 => new FromAccountCreateDto { SubCategoryIncomeId = fromAccountSubId },
                2 => new FromAccountCreateDto { FundsId = fromAccountSubId },
                3 => new FromAccountCreateDto { AssetsId = fromAccountSubId },
                4 => new FromAccountCreateDto { BankId = fromAccountSubId },
                5 => new FromAccountCreateDto { DebtsId = fromAccountSubId },
                6 => new FromAccountCreateDto { CreditorsId = fromAccountSubId },
                7 => new FromAccountCreateDto { PersonsId = fromAccountSubId },
                8 => new FromAccountCreateDto { CapitalId = fromAccountSubId },
                _ => null
            };

            if (N != null)
            {
                var resultId = await _fromAccountAppService.AddFromAccountAsync(N);
                return resultId;
            }

            return 0;
        }

        [HttpGet]
        public async Task<IActionResult> GetOptions()
        {
            var subCategoryIncomeOptions = await _fromAccountAppService.GetAllSubCategoryIncomesAsync();
            var creditorsOptions = await _fromAccountAppService.GetAllCreditorsAsync();
            var fundOptions = await _fromAccountAppService.GetAllFundsAsync();
            var assetOptions = await _fromAccountAppService.GetAllAssetsAsync();
            var bankOptions = await _fromAccountAppService.GetAllBanksAsync();
            var debtorOptions = await _fromAccountAppService.GetAllDebtsAsync();
            var personOptions = await _fromAccountAppService.GetAllPersonsAsync();
            var capitalOptions = await _fromAccountAppService.GetAllCapitalsAsync();

            var model = new OptionsViewModel
            {
                SubCategoryIncomeOptions = subCategoryIncomeOptions,
                CreditorsOptions = creditorsOptions,
                FundOptions = fundOptions,
                AssetOptions = assetOptions,
                BankOptions = bankOptions,
                DebtorOptions = debtorOptions,
                PersonOptions = personOptions,
                CapitalOptions = capitalOptions
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            int userId = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {
                // UserId is fetched from claim
            }

            var categoryCosts = await _categoryCostAppService.GetCategoryCostByUserIdAsync(userId);
            var viewModel = new CriticismViewModel
            {
                CategoryCosts = categoryCosts
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubcategories(int categoryId, string categoryName)
        {
            var subcategories = await _subCategoryCostAppService.GetSubCatCostByCategoryIdAsync(categoryId);

            var viewModel = new CriticismViewModel
            {
                SubcategoryCosts = subcategories,
                CategoryCostId = categoryId,
                CategoryCostName = categoryName
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriticismViewModel viewModel)
        {
            int userId = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {
                // UserId is fetched from claim
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            int fromAccountId = HttpContext.Session.GetInt32("FromAccountId") ?? 0;

            var criticismRequest = new CriticismRequestDto
            {
                Date = viewModel.Date,
                Time = viewModel.Time,
                Amount = viewModel.Amount,
                Description = viewModel.Description,
                SubcategoryCostId = viewModel.SubcategoryCostId,
                MemderId = viewModel.MemberId,
                EventId = viewModel.EventId,
                ProjectId = viewModel.ProjectId,
                UserId = viewModel.UserId = userId,
                Xxpenses = Xxpens.Costs,
                FromAccountId = fromAccountId
            };

            var result = await _fromAccountAppService.SubtractAmountFromAccountAsync(fromAccountId, viewModel.Amount);

            if (result == true && viewModel.SubcategoryCostId.HasValue)
            {
                await _subCategoryCostAppService.AddAmountToSubCategoryCostAsync(viewModel.SubcategoryCostId.Value, viewModel.Amount);
                await _criticismAppService.AddCriticismAsync(criticismRequest);
            }

            TempData["SuccessMessage"] = "Criticism added successfully.";
            return RedirectToAction("Index", "Home");
        }
    }
}
