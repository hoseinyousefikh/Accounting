using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
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
    }
}
