using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.Accounts
{
    public class CategoryCostService : ICategoryCostService
    {

        private readonly ICategoryCostRepository _categoryCostRepository;

        public CategoryCostService(ICategoryCostRepository categoryCostRepository)
        {
            _categoryCostRepository = categoryCostRepository;
        }
        public async Task<List<CategoryCost>> GetCategoryCostByUserIdAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(userId));
            }

            var categories = await _categoryCostRepository.GetCategoryCostByUserIdAsync(userId);

            if (categories == null || !categories.Any())
            {
                throw new KeyNotFoundException("No categories found for the specified user.");
            }

            return categories;
        }
    }
}
