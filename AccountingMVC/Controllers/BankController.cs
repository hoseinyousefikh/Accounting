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

            return RedirectToAction("Index","Home"); 
        }
    }
}
