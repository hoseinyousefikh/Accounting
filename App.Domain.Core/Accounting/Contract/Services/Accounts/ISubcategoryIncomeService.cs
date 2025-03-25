using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Services.Accounts
{
    public interface ISubcategoryIncomeService
    {
        Task AddAmountToSubCategoryIncomeAsync(int subCategoryId, decimal amount);
        Task<List<SubcategoryIncomeDto>> GetBySubCatIncomeUserIdAsync(int userId);
        Task<List<SubcategoryIncome>> GetSubcategoryIncomesByCategoryIdAsync(int categoryIncomeId);
        Task<SubcategoryIncome> GetByIdSubCatIncomeAsync(int id);
    }
}
