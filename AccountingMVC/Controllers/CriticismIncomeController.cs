using AccountingMVC.Models;
using App.Domain.AppServices.Accounting.AppServices.Accounts;
using App.Domain.AppServices.Accounting.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.AppServices.AccountIn;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.AppServices.payment;
using App.Domain.Core.Accounting.Contract.AppServices.PMEList;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AccountingMVC.Controllers
{
    [Authorize]
    public class CriticismIncomeController : Controller
    {

        private readonly ISubCategoryCostAppService _subCategoryCostAppService;
        private readonly ICriticismAppService _criticismAppService;
        private readonly ICategoryIncomeAppService _categoryIncomeAppService;
        private readonly ISubcategoryIncomeAppService _subcategoryIncomeAppService;

        private readonly IFromAccountAppService _fromAccountAppService;
        private readonly IMemberAppService _memberAppService;
        private readonly IEventAppService _eventAppService;
        private readonly IProjectAppService _projectAppService;
        public CriticismIncomeController(ICriticismAppService criticismAppService, IFromAccountAppService fromAccountAppService, IMemberAppService memberAppService, IEventAppService eventAppService, IProjectAppService projectAppService, ICategoryIncomeAppService categoryIncomeAppService, ISubcategoryIncomeAppService subcategoryIncomeAppService, ISubCategoryCostAppService subCategoryCostAppService)
        {
            _criticismAppService = criticismAppService;
            _fromAccountAppService = fromAccountAppService;
            _memberAppService = memberAppService;
            _eventAppService = eventAppService;
            _projectAppService = projectAppService;
            _categoryIncomeAppService = categoryIncomeAppService;
            _subcategoryIncomeAppService = subcategoryIncomeAppService;
            _subCategoryCostAppService = subCategoryCostAppService;
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

            }


            var members = await _memberAppService.GetMembersByUserIdAsync(userId);
            var memberNames = members.Select(m => new
            {
                m.Id,
                m.Name
            }).ToList();

            ViewBag.Member = memberNames;

            var events = await _eventAppService.GetEventByUserIdAsync(userId);
            var eventNames = events.Select(e => new
            {
                e.Id,
                e.Name
            }).ToList();

            ViewBag.Events = eventNames;


            var project = await _projectAppService.GetProjectsByUserIdAsync(userId);
            var projectNames = project.Select(p => new
            {
                p.Id,
                p.Name
            }).ToList();

            ViewBag.Projects = projectNames;

            if (memberId.HasValue)
            {
                HttpContext.Session.SetInt32("MemberId", memberId.Value);
            }
            else
            {
                memberId = HttpContext.Session.GetInt32("MemberId");
            }


            if (EventId.HasValue)
            {
                HttpContext.Session.SetInt32("EventId", EventId.Value);
            }
            else
            {
                EventId = HttpContext.Session.GetInt32("EventId");
            }

            if (ProjectId.HasValue)
            {
                HttpContext.Session.SetInt32("ProjectId", ProjectId.Value);
            }
            else
            {
                ProjectId = HttpContext.Session.GetInt32("ProjectId");
            }

            var viewModel = new CriticismViewModel
            {
                SubcategoryIncomeId = HttpContext.Session.GetInt32("SubcategoryIncomeId") ?? 0,
                CategoryIncomeId = HttpContext.Session.GetInt32("CategoryIncomeId") ?? 0,
                CategoryIncomeName = HttpContext.Session.GetString("CategoryIncomeName"),
                SubcategoryIncomeName = HttpContext.Session.GetString("SubcategoryIncomeName"),
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
                HttpContext.Session.SetInt32("CategoryIncomeId", categoryId);
                HttpContext.Session.SetString("CategoryIncomeName", categoryName);
            }
        }
        private void SetSubcategoryData(int? subcategoryId, string subcategoryName)
        {
            if (subcategoryId.HasValue && !string.IsNullOrEmpty(subcategoryName))
            {
                HttpContext.Session.SetInt32("SubcategoryIncomeId", subcategoryId.Value);
                HttpContext.Session.SetString("SubcategoryIncomeName", subcategoryName);
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
                1 => new FromAccountCreateDto { SubCategoryCostId = fromAccountSubId },  // تغییر به SubCategoryIncomeId
                2 => new FromAccountCreateDto { FundsId = fromAccountSubId },
                3 => new FromAccountCreateDto { AssetsId = fromAccountSubId },
                4 => new FromAccountCreateDto { BankId = fromAccountSubId },
                5 => new FromAccountCreateDto { DebtsId = fromAccountSubId },
                6 => new FromAccountCreateDto { CreditorsId = fromAccountSubId },  // تغییر به CreditorsId
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
            var subCategoryCostOptions = await _fromAccountAppService.GetAllSubCategoryCostAsync(); 
            var creditorsOptions = await _fromAccountAppService.GetAllCreditorsAsync();  
            var fundOptions = await _fromAccountAppService.GetAllFundsAsync();
            var assetOptions = await _fromAccountAppService.GetAllAssetsAsync();
            var bankOptions = await _fromAccountAppService.GetAllBanksAsync();
            var debtorOptions = await _fromAccountAppService.GetAllDebtsAsync();
            var personOptions = await _fromAccountAppService.GetAllPersonsAsync();
            var capitalOptions = await _fromAccountAppService.GetAllCapitalsAsync();

            var model = new OptionsViewModel
            {
                SubCategoryCostOptions = subCategoryCostOptions, 
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

            }
            var categoryIncomes = await _categoryIncomeAppService.GetCategoryIncomeByUserIdAsync(userId);
            var viewModel = new CheckViewModel
            {
                CategoryIncomes = categoryIncomes
            };
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetSubcategories(int categoryId, string categoryName)
        {
            var subcategories = await _subcategoryIncomeAppService.GetSubcategoryIncomesByCategoryId(categoryId);

            var viewModel = new CheckViewModel
            {
                SubcategoryIncomes = subcategories,
                CategoryIncomeId = categoryId,
                CategoryIncomeName = categoryName
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
                SubcategoryIncomeId = viewModel.SubcategoryIncomeId,
                MemderId = viewModel.MemberId,
                EventId = viewModel.EventId,
                ProjectId = viewModel.ProjectId,
                UserId = viewModel.UserId  = userId,
                Xxpenses = Xxpens.revenues,
                FromAccountId = fromAccountId
            };
            var result = await _fromAccountAppService.SubtractAmountFromAccountIncomeAsync(fromAccountId, viewModel.Amount);

            if (result == true && viewModel.SubcategoryIncomeId.HasValue)
            {
                await _subcategoryIncomeAppService.AddAmountToSubCategoryIncomeAsync(viewModel.SubcategoryIncomeId.Value, viewModel.Amount);
                await _criticismAppService.AddCriticismAsync(criticismRequest);
            }


            TempData["SuccessMessage"] = "Criticism added successfully.";
            return RedirectToAction("Index", "Home");
        }

    }
}
