using AccountingMVC.Models;
using App.Domain.AppServices.Accounting.AppServices.payment;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.AppServices.payment;
using App.Domain.Core.Accounting.Contract.AppServices.PMEList;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AccountingMVC.Controllers
{
    [Authorize]
    public class CheckIncomeController : Controller
    {
        private readonly IMemberAppService _memberAppService;
        private readonly IEventAppService _eventAppService;
        private readonly IProjectAppService _projectAppService;
        private readonly IBankAppService _bankAppService;
        private readonly ICheckAppService _checkAppService;
        private readonly IMapper _mapper;
        private readonly ICategoryIncomeAppService _categoryIncomeAppService;
        private readonly ISubcategoryIncomeAppService _subcategoryIncomeAppService;


        public CheckIncomeController(IMemberAppService memberAppService, IEventAppService eventAppService, IProjectAppService projectAppService, IBankAppService bankAppService, ICheckAppService checkAppService, IMapper mapper, ICategoryIncomeAppService categoryIncomeAppService, ISubcategoryIncomeAppService subcategoryIncomeAppService)
        {
            _memberAppService = memberAppService;
            _eventAppService = eventAppService;
            _projectAppService = projectAppService;
            _bankAppService = bankAppService;
            _checkAppService = checkAppService;
            _mapper = mapper;
            _categoryIncomeAppService = categoryIncomeAppService;
            _subcategoryIncomeAppService = subcategoryIncomeAppService;
        }

        public async Task<IActionResult> CreateCheck(int subCategoryId, string subCategoryName, int categoryId, string categoryName, int bankId, string bankName, int titr, int? memberId, int? eventId, int? projectId)
        {
            SetCategoryData(categoryId, categoryName);
            SetSubcategoryData(subCategoryId, subCategoryName);
            BankData(bankId, bankName);

            int userId = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {

            }

            var bank = await _bankAppService.GetBankByUserIdAsync(userId);
            var banks = bank.Select(b => new
            {
                b.Id,
                b.Name
            }).ToList();

            ViewBag.Banks = banks;

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


            if (eventId.HasValue)
            {
                HttpContext.Session.SetInt32("EventId", eventId.Value);
            }
            else
            {
                eventId = HttpContext.Session.GetInt32("EventId");
            }

            if (projectId.HasValue)
            {
                HttpContext.Session.SetInt32("ProjectId", projectId.Value);
            }
            else
            {
                projectId = HttpContext.Session.GetInt32("ProjectId");
            }

            var viewModel = new CheckViewModel
            {
                SubcategoryIncomeId = HttpContext.Session.GetInt32("SubcategoryIncomeId") ?? 0,
                CategoryIncomeId = HttpContext.Session.GetInt32("CategoryIncomeId") ?? 0,
                CategoryIncomeName = HttpContext.Session.GetString("CategoryIncomeName"),
                SubcategoryIncomeName = HttpContext.Session.GetString("SubcategoryIncomeName"),
                MemberId = memberId,
                EventId = eventId,
                ProjectId = projectId,
                BankId = bankId
            };
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

        private void BankData(int? bankId, string bankName)
        {
            if (bankId.HasValue && !string.IsNullOrEmpty(bankName))
            {
                HttpContext.Session.SetInt32("BankId", bankId.Value);
                HttpContext.Session.SetString("BankName", bankName);
            }
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
        public async Task<IActionResult> CreateCheck(CheckViewModel viewModel)
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

            var checkRequest = new CheckDto
            {
                Date = viewModel.Date,
                Time = viewModel.Time,
                Amount = viewModel.Amount,
                Description = viewModel.Description,
                SubcategoryIncomeId = viewModel.SubcategoryIncomeId,
                MemberId = viewModel.MemberId,
                EventId = viewModel.EventId,
                ProjectId = viewModel.ProjectId,
                UserId = userId,
                Xxpenses = Xxpens.revenues,
                BankId = viewModel.BankId,
                DuDate = viewModel.DuDate,
                ChecNumber = viewModel.ChecNumber
            };
            if ( viewModel.SubcategoryIncomeId.HasValue)
            {
                await _subcategoryIncomeAppService.AddAmountToSubCategoryIncomeAsync(viewModel.SubcategoryIncomeId.Value, viewModel.Amount);
                await _checkAppService.AddCheckAsync(checkRequest);
            }


            TempData["SuccessMessage"] = "Check added successfully.";
            return RedirectToAction("Index", "Home");
        }
    }
}
