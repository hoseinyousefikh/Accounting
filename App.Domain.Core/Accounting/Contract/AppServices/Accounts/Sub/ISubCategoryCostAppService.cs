using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub
{
    public interface ISubCategoryCostAppService
    {
        Task<List<SubcategoryCost>> GetSubcategoryCostByUserIdAsync(int userId);
        Task<List<SubcategoryCost>> GetSubCatCostByCategoryIdAsync(int categoryId);
        Task<SubcategoryCost> GetByIdSubCatCostAsync(int id);
        Task AddAmountToSubCategoryCostAsync(int subCategoryId, decimal amount);


    }
}
