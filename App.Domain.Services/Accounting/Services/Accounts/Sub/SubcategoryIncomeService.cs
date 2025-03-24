using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts.Sub;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var subcategoryIncomes = await _subcategoryIncomeRepository.GetBySubCatIncomeUserId(userId);
            return _mapper.Map<List<SubcategoryIncomeDto>>(subcategoryIncomes);
        }
        public async Task<List<SubcategoryIncome>> GetSubcategoryIncomesByCategoryId(int categoryIncomeId)
        {
            return await _subcategoryIncomeRepository.GetByCategoryIncomeId(categoryIncomeId);
        }
        public async Task<SubcategoryIncome> GetByIdSubCatIncomeAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid subcategory ID", nameof(id));
            }

            var subcategory = await _subcategoryIncomeRepository.GetBySubCatIncomeId(id);

            if (subcategory == null)
            {
                throw new KeyNotFoundException($"Subcategory with ID {id} not found.");
            }

            return subcategory;
        }
    }
}
