using App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.Accounts.Sub
{
    public class SubCategoryCostAppService : ISubCategoryCostAppService
    {
        private readonly ISubCategoryCostService _subCategoryCostService;
        public SubCategoryCostAppService(ISubCategoryCostService subCategoryCostService)
        {
            _subCategoryCostService = subCategoryCostService;
        }

        public Task<SubcategoryCost> GetByIdSubCatCostAsync(int id)
        {
            return _subCategoryCostService.GetByIdSubCatCostAsync(id);
        }

        public async Task<List<SubcategoryCost>> GetSubCatCostByCategoryIdAsync(int categoryId)
        {
            return await _subCategoryCostService.GetSubCatCostByCategoryIdAsync(categoryId);
        }

        public async Task<List<SubcategoryCost>> GetSubcategoryCostByUserIdAsync(int userId)
        {
            return await _subCategoryCostService.GetSubcategoryCostByUserIdAsync(userId);
        }

    }
}
