using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.Accounts
{
    public class CategoryCostAppService : ICategoryCostAppService
    {
        private readonly ICategoryCostService _categoryCostService;
        public CategoryCostAppService(ICategoryCostService categoryCostService)
        {
            _categoryCostService = categoryCostService;
        }
        public Task<List<CategoryCost>> GetCategoryCostByUserIdAsync(int userId)
        {
            return _categoryCostService.GetCategoryCostByUserIdAsync(userId);
        }
    }
}
