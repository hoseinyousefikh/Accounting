using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.AccountIn;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.AppServices.AccountIn
{
    public interface IFromAccountAppService
    {
        Task<bool> SubtractAmountFromAccountAsync(int fromAccountId, decimal amount);
        Task<int> AddFromAccountAsync(FromAccountCreateDto fromAccountCreateDto);
        Task<List<Assets>> GetAllAssetsAsync();
        Task<List<Bank>> GetAllBanksAsync();
        Task<List<Capital>> GetAllCapitalsAsync();
        Task<List<Debts>> GetAllDebtsAsync();
        Task<List<Funds>> GetAllFundsAsync();
        Task<List<Persons>> GetAllPersonsAsync();
        Task<List<Creditors>> GetAllCreditorsAsync();
        Task<List<SubcategoryIncome>> GetAllSubCategoryIncomesAsync();
    }
}
