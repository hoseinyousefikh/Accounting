﻿using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.Accounts.Sub
{
    public class SubCategoryCostService : ISubCategoryCostService
    {
        private readonly ISubcategoryCostRepository _subcategoryCostRepository;

        public SubCategoryCostService(ISubcategoryCostRepository subcategoryCostRepository)
        {
            _subcategoryCostRepository = subcategoryCostRepository;
        }

        public async Task<List<SubcategoryCost>> GetSubcategoryCostByUserIdAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(userId));
            }

            var subcategories = await _subcategoryCostRepository.GetByUserIdSubCatCost(userId);

            if (subcategories == null || !subcategories.Any())
            {
                throw new KeyNotFoundException("No subcategories found for the specified user.");
            }

            return subcategories;
        }
        public async Task<List<SubcategoryCost>> GetSubCatCostByCategoryIdAsync(int categoryId)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("Invalid category ID", nameof(categoryId));
            }

            var subcategories = await _subcategoryCostRepository.GetSubCatCostByCategoryId(categoryId);

            if (subcategories == null || !subcategories.Any())
            {
                throw new KeyNotFoundException("No subcategories found for the specified category.");
            }

            return subcategories;
        }
    }
}
