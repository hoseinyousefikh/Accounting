using AccountingMVC.Models;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AccountingMVC.Controllers
{
    [Authorize]
    public class BankController : Controller
    {

        private readonly IBankAppService _bankAppService;
        public BankController(IBankAppService bankAppService)
        {
            _bankAppService = bankAppService;
        }


        [HttpGet]
        public IActionResult CreateBank()
        {
            return View(new BankViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBank(BankViewModel model)
        {
            int userId = 0;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {

            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var bank = new Bank
            {
                Name = model.Name,
                Description = model.Description,
                Oranches = model.Oranches,
                AccountNumber = model.AccountNumber,
                CardNumber = model.CardNumber,
                ShabaNumber = model.ShabaNumber,
                Amount = model.Amount,
                IsPublic = model.IsPublic,
                UserId = model.UserId = userId
            };

            await _bankAppService.AddBankAsync(bank);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized(); 
            }

            var banks = await _bankAppService.GetBankByUserIdAsync(userId);

            if (banks == null || banks.Count == 0)
            {
                ViewBag.Message = "بانکی برای این کاربر یافت نشد.";
                return View("NoBanks");
            }

            var viewModelList = banks.Select(b => new BankViewModel
            {
                Id = b.Id,
                Name = b.Name,
                CardNumber = b.CardNumber,
                UserId = b.UserId,
                IsPublic = b.IsPublic
            }).ToList();

            return View(viewModelList);
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailBankByUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized(); 
            }

            var banks = await _bankAppService.GetBankByUserIdAsync(userId);

            if (banks == null || banks.Count == 0)
            {
                ViewBag.Message = "بانکی برای این کاربر یافت نشد.";
                return View("NoBanks");
            }

            var viewModelList = banks.Select(b => new BankViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                Oranches = b.Oranches,
                AccountNumber = b.AccountNumber,
                CardNumber = b.CardNumber,
                ShabaNumber = b.ShabaNumber,
                Amount = b.Amount,
                IsPublic = b.IsPublic,
                UserId = b.UserId
            }).ToList();

            return View(viewModelList);
        }


    }
}
