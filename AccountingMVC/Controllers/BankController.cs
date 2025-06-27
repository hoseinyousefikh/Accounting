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
        public async Task<IActionResult> GetDetailBankByUserId(int Id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized();
            }

            var bank = await _bankAppService.GetBankByIdAsync(Id);
            if (bank == null || bank.UserId != userId)
            {
                ViewBag.Message = "بانکی برای این شناسه یافت نشد یا به شما تعلق ندارد.";
                return View("NoBanks");
            }

            var viewModel = new BankViewModel
            {
                Id = bank.Id,
                Name = bank.Name,
                Description = bank.Description,
                Oranches = bank.Oranches,
                AccountNumber = bank.AccountNumber,
                CardNumber = bank.CardNumber,
                ShabaNumber = bank.ShabaNumber,
                Amount = bank.Amount,
                IsPublic = bank.IsPublic,
                UserId = bank.UserId
            };

            return View( viewModel); 
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var bank = await _bankAppService.GetBankByIdAsync(id);
            if (bank == null)
                return NotFound();

            var viewModel = new BankViewModel
            {
                Id = bank.Id,
                Name = bank.Name,
                Description = bank.Description,
                Oranches = bank.Oranches,
                AccountNumber = bank.AccountNumber,
                CardNumber = bank.CardNumber,
                ShabaNumber = bank.ShabaNumber,
                Amount = bank.Amount,
                IsPublic = bank.IsPublic,
                UserId = bank.UserId
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BankViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized();
            }

            try
            {
                var bank = await _bankAppService.GetBankByIdAsync(model.Id);
                if (bank == null || bank.UserId != userId)
                {
                    return NotFound(); 
                }

                bank.Name = model.Name;
                bank.Description = model.Description;
                bank.Oranches = model.Oranches;
                bank.AccountNumber = model.AccountNumber;
                bank.CardNumber = model.CardNumber;
                bank.ShabaNumber = model.ShabaNumber;
                bank.Amount = model.Amount;
                bank.IsPublic = model.IsPublic;

                await _bankAppService.UpdateBankAsync(bank);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی در به‌روزرسانی رخ داد: " + ex.Message);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized();
            }

            var result = await _bankAppService.DeleteBankAsync(id, userId);

            if (!result)
            {
                TempData["Error"] = "حذف بانک انجام نشد. ممکن است بانک وجود نداشته یا متعلق به شما نباشد.";
                return RedirectToAction("Index");
            }

            TempData["Success"] = "بانک با موفقیت حذف شد.";
            return RedirectToAction("Index");
        }

    }
}
