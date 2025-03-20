using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub
{
    public interface ISubcategoryIncomeRepository
    {
        Task AddSubCatIncome(SubcategoryIncome subcategoryIncome);
        Task UpdateSubCatIncome(SubcategoryIncome subcategoryIncome);
        Task DeleteSubCatIncome(int id);
        Task<List<SubcategoryIncome>> GetAllSubCatIncome();
        Task<SubcategoryIncome> GetBySubCatIncomeId(int id);
        Task<List<SubcategoryIncome>> GetByCategoryIncomeId(int categoryIncomeId);
        Task<List<SubcategoryIncome>> GetBySubCatIncomeUserId(int userId);
    }
}
