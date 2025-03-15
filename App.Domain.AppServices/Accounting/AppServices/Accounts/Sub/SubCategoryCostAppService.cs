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

        public Task<List<SubcategoryCost>> GetSubCatCostByCategoryIdAsync(int categoryId)
        {
            return _subCategoryCostService.GetSubCatCostByCategoryIdAsync(categoryId);
        }

        public Task<List<SubcategoryCost>> GetSubcategoryCostByUserIdAsync(int userId)
        {
            return _subCategoryCostService.GetSubcategoryCostByUserIdAsync(userId);
        }

    }
}
