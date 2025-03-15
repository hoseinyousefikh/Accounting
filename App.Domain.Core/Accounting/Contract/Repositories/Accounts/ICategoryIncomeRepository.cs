using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts
{
    public interface ICategoryIncomeRepository
    {
        Task AddCategoryIncomeAsync(CategoryIncome categoryIncome);
        Task UpdateCategoryIncomeAsync(CategoryIncome categoryIncome);
        Task DeleteCategoryIncomeAsync(int id);
        Task<List<CategoryIncome>> GetAllCategoryIncomeAsync();
        Task<CategoryIncome> GetCategoryIncomeByIdAsync(int id);
        Task<List<CategoryIncome>> GetCategoryIncomeByUserIdAsync(int userId);
    }
}
