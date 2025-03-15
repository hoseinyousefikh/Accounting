using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub
{
    public interface ISubcategoryCostRepository
    {
        Task AddSubCatCost(SubcategoryCost subcategoryCost);
        Task UpdateSubCatCost(SubcategoryCost subcategoryCost);
        Task DeleteSubCatCost(int id);
        Task<List<SubcategoryCost>> GetAllSubCatCost();
        Task<SubcategoryCost> GetByIdSubCatCost(int id);
        Task<List<SubcategoryCost>> GetByUserIdSubCatCost(int userId);
        Task<List<SubcategoryCost>> GetSubCatCostByCategoryId(int categoryId);
    }
}
