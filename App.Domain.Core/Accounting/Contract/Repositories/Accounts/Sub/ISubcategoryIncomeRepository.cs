using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub
{
    public interface ISubcategoryIncomeRepository
    {
        Task AddSubCatIncomeAsync(SubcategoryIncome subcategoryIncome);
        Task UpdateSubCatIncomeAsync(SubcategoryIncome subcategoryIncome);
        Task DeleteSubCatIncomeAsync(int id);
        Task<List<SubcategoryIncome>> GetAllSubCatIncomeAsync();
        Task<SubcategoryIncome> GetBySubCatIncomeIdAsync(int id);
        Task<List<SubcategoryIncome>> GetByCategoryIncomeIdAsync(int categoryIncomeId);
        Task<List<SubcategoryIncome>> GetBySubCatIncomeUserIdAsync(int userId);
    }
}
