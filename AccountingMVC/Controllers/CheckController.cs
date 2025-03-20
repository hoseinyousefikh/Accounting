using AccountingMVC.Models;
using App.Domain.AppServices.Accounting.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.AppServices.payment;
using App.Domain.Core.Accounting.Contract.AppServices.PMEList;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.payment;
using App.Domain.Core.Accounting.Entities.PMEList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AccountingMVC.Controllers
{
    public class CheckController : Controller
    {
        private readonly IMemberAppService _memberAppService;
        private readonly IEventAppService _eventAppService;
        private readonly IProjectAppService _projectAppService;
        private readonly IBankAppService _bankAppService;
        private readonly ISubCategoryCostAppService _subCategoryCostAppService;
        private readonly ICategoryCostAppService _categoryCostAppService;
        private readonly ICheckAppService _checkAppService;
        private readonly IMapper _mapper;

        public CheckController(IMemberAppService memberAppService, IEventAppService eventAppService, IProjectAppService projectAppService, IBankAppService bankAppService, ISubCategoryCostAppService subCategoryCostAppService, ICategoryCostAppService categoryCostAppService, ICheckAppService checkAppService, IMapper mapper)
        {
            _memberAppService = memberAppService;
            _eventAppService = eventAppService;
            _projectAppService = projectAppService;
            _bankAppService = bankAppService;
            _subCategoryCostAppService = subCategoryCostAppService;
            _categoryCostAppService = categoryCostAppService;
            _checkAppService = checkAppService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CreateCheck(int subCategoryId,string subCategoryName,int categoryId , string categoryName,int bankId ,string bankName ,int titr , int? memberId , int? eventId ,int? projectId)
        {
            SetCategoryData(categoryId, categoryName);
            SetSubcategoryData(subCategoryId, subCategoryName);
            BankData(bankId, bankName);

            int userId = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {

            }

            var bank = await _bankAppService.GetBankByUserIdAsync(1);
            var banks = bank.Select(b => new
            {
                b.Id,
                b.Name
            }).ToList();

            ViewBag.Banks = banks;

            var members = await _memberAppService.GetMembersByUserIdAsync(1);
            var memberNames = members.Select(m => new
            {
                m.Id,
                m.Name
            }).ToList();

            ViewBag.Member = memberNames;

            var events = await _eventAppService.GetEventByUserIdAsync(1);
            var eventNames = events.Select(e => new
            {
                e.Id,
                e.Name
            }).ToList();

            ViewBag.Events = eventNames;


            var project = await _projectAppService.GetProjectsByUserIdAsync(1);
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
                SubcategoryCostId = HttpContext.Session.GetInt32("SubcategoryCostId") ?? 0,
                CategoryCostId = HttpContext.Session.GetInt32("CategoryCostId") ?? 0,
                CategoryCostName = HttpContext.Session.GetString("CategoryCostName"),
                SubcategoryCostName = HttpContext.Session.GetString("SubcategoryCostName"),
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

        private void BankData(int? bankId ,string bankName)
        {
            if(bankId.HasValue && !string.IsNullOrEmpty(bankName))
            {
                HttpContext.Session.SetInt32("BankId", bankId.Value);
                HttpContext.Session.SetString("BankName", bankName);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categoryCosts = await _categoryCostAppService.GetCategoryCostByUserIdAsync(1);
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
        public async Task<IActionResult> CreateCheck(CheckViewModel viewModel)
        {
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
                SubcategoryCostId = viewModel.SubcategoryCostId,
                MemberId = viewModel.MemberId,
                EventId = viewModel.EventId,
                ProjectId = viewModel.ProjectId,
                UserId = 1,
                Xxpenses = Xxpens.Costs,
                BankId = viewModel.BankId,
                DuDate = viewModel.DuDate,
                ChecNumber =viewModel.ChecNumber
            };


            await _checkAppService.AddCheckAsync(checkRequest);

            TempData["SuccessMessage"] = "Check added successfully.";
            return RedirectToAction("Index", "Home");
        }
    }
}
