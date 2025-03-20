using App.Domain.Core.Accounting.Contract.Repositories.AccountIn;
using App.Domain.Core.Accounting.Contract.Services.AccountIn;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.AccountIn;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.AccountIn
{
    public class FromAccountService : IFromAccountService
    {

        private readonly IFromAccountRepository _fromAccountRepository;

        public FromAccountService(IFromAccountRepository fromAccountRepository)
        {
            _fromAccountRepository = fromAccountRepository;
        }
        public async Task<int> AddFromAccountAsync(FromAccountCreateDto fromAccountCreateDto)
        {
            var fromAccount = new FromAccount
            {
                AssetsId = fromAccountCreateDto.AssetsId,
                BankId = fromAccountCreateDto.BankId,
                CapitalId = fromAccountCreateDto.CapitalId,
                CategoryCostId = fromAccountCreateDto.CategoryCostId,
                CategoryIncomeId = fromAccountCreateDto.CategoryIncomeId,
                DebtsId = fromAccountCreateDto.DebtsId,
                FundsId = fromAccountCreateDto.FundsId,
                PersonsId = fromAccountCreateDto.PersonsId,
                CriticismId = fromAccountCreateDto.CriticismId
            };

            return await _fromAccountRepository.AddFromAccountAsync(fromAccount);
        }

        public async Task<List<Assets>> GetAllAssetsAsync()
        {
            return await _fromAccountRepository.GetAllAssetsAsync();
        }

        public async Task<List<Bank>> GetAllBanksAsync()
        {
            return await _fromAccountRepository.GetAllBanksAsync();
        }

        public async Task<List<Capital>> GetAllCapitalsAsync()
        {
            return await _fromAccountRepository.GetAllCapitalsAsync();
        }

        public async Task<List<CategoryCost>> GetAllCategoryCostsAsync()
        {
            return await _fromAccountRepository.GetAllCategoryCostsAsync();
        }

        public async Task<List<CategoryIncome>> GetAllCategoryIncomesAsync()
        {
            return await _fromAccountRepository.GetAllCategoryIncomesAsync();
        }

        public async Task<List<Debts>> GetAllDebtsAsync()
        {
            return await _fromAccountRepository.GetAllDebtsAsync();
        }

        public async Task<List<Funds>> GetAllFundsAsync()
        {
            return await _fromAccountRepository.GetAllFundsAsync();
        }

        public async Task<List<Persons>> GetAllPersonsAsync()
        {
            return await _fromAccountRepository.GetAllPersonsAsync();
        }

        public async Task<List<Criticism>> GetAllCriticismsAsync()
        {
            return await _fromAccountRepository.GetAllCriticismsAsync();
        }
    }
}
