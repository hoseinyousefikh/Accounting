using App.Domain.Core.Accounting.Contract.AppServices.AccountIn;
using App.Domain.Core.Accounting.Contract.Services.AccountIn;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.AccountIn
{
    public class FromAccountAppService : IFromAccountAppService
    {
        private readonly IFromAccountService _fromAccountService;
        public FromAccountAppService(IFromAccountService fromAccountService)
        {
            _fromAccountService = fromAccountService;
        }
        public Task<int> AddFromAccountAsync(FromAccountCreateDto fromAccountCreateDto)
        {
            return _fromAccountService.AddFromAccountAsync(fromAccountCreateDto);
        }

        public async Task<List<Assets>> GetAllAssetsAsync()
        {
            return await _fromAccountService.GetAllAssetsAsync();
        }

        public async Task<List<Bank>> GetAllBanksAsync()
        {
            return await _fromAccountService.GetAllBanksAsync();
        }

        public async Task<List<Capital>> GetAllCapitalsAsync()
        {
            return await _fromAccountService.GetAllCapitalsAsync();
        }

        public async Task<List<Creditors>> GetAllCreditorsAsync()
        {
            return await _fromAccountService.GetAllCreditorsAsync();
        }

        public async Task<List<Debts>> GetAllDebtsAsync()
        {
            return await _fromAccountService.GetAllDebtsAsync();
        }

        public async Task<List<Funds>> GetAllFundsAsync()
        {
            return await _fromAccountService.GetAllFundsAsync();
        }

        public async Task<List<Persons>> GetAllPersonsAsync()
        {
            return await _fromAccountService.GetAllPersonsAsync();
        }

        public async Task<List<SubcategoryIncome>> GetAllSubCategoryIncomesAsync()
        {
            return await _fromAccountService.GetAllSubCategoryIncomesAsync();
        }

        public async Task<bool> SubtractAmountFromAccountAsync(int fromAccountId, decimal amount)
        {
            try
            {
                await _fromAccountService.SubtractAmountFromAccountAsync(fromAccountId, amount);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
