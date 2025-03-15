using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts
{
    public interface ICategoryCostRepository
    {
        Task AddCategoryCostAsync(CategoryCost categoryCost);
        Task UpdateCategoryCostAsync(CategoryCost categoryCost);
        Task DeleteCategoryCostAsync(int id);
        Task<List<CategoryCost>> GetAllCategoryCostAsync();
        Task<CategoryCost> GetCategoryCostByIdAsync(int id);
        Task<List<CategoryCost>> GetCategoryCostByUserIdAsync(int userId);
    }
}
