using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.Accounts.Sub
{
    public class SubcategoryIncomeService : ISubcategoryIncomeService
    {
        private readonly ISubcategoryIncomeRepository _subcategoryIncomeRepository;
        private readonly IMapper _mapper;

        public SubcategoryIncomeService(ISubcategoryIncomeRepository subcategoryIncomeRepository, IMapper mapper)
        {
            _subcategoryIncomeRepository = subcategoryIncomeRepository;
            _mapper = mapper;
        }

        public async Task<List<SubcategoryIncomeDto>> GetBySubCatIncomeUserIdAsync(int userId)
        {
            var subcategoryIncomes = await _subcategoryIncomeRepository.GetBySubCatIncomeUserIdAsync(userId);
            return _mapper.Map<List<SubcategoryIncomeDto>>(subcategoryIncomes);
        }

        public async Task<List<SubcategoryIncome>> GetSubcategoryIncomesByCategoryIdAsync(int categoryIncomeId)
        {
            return await _subcategoryIncomeRepository.GetByCategoryIncomeIdAsync(categoryIncomeId);
        }

        public async Task<SubcategoryIncome> GetByIdSubCatIncomeAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid subcategory ID", nameof(id));
            }

            // Ensuring the async operation is awaited
            var subcategory = await _subcategoryIncomeRepository.GetBySubCatIncomeIdAsync(id);

            if (subcategory == null)
            {
                throw new KeyNotFoundException($"Subcategory with ID {id} not found.");
            }

            return subcategory;
        }
        public async Task AddAmountToSubCategoryIncomeAsync(int subCategoryId, decimal amount)
        {
            if (subCategoryId <= 0)
                throw new ArgumentException("Invalid subcategory ID", nameof(subCategoryId));

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero", nameof(amount));

            var subcategory = await _subcategoryIncomeRepository.GetBySubCatIncomeIdAsync(subCategoryId);

            if (subcategory == null)
                throw new KeyNotFoundException($"Subcategory with ID {subCategoryId} not found.");

            subcategory.Amount -= amount;

            await _subcategoryIncomeRepository.UpdateSubCatIncomeAsync(subcategory);
        }
    }
}
