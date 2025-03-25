using App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.Accounts.Sub
{
    public class SubcategoryIncomeAppService : ISubcategoryIncomeAppService
    {
        private readonly ISubcategoryIncomeService  _subcategoryIncomeService;
        private readonly IMapper _mapper;

        public SubcategoryIncomeAppService( IMapper mapper, ISubcategoryIncomeService subcategoryIncomeService)
        {
            _mapper = mapper;
            _subcategoryIncomeService = subcategoryIncomeService;
        }

        public Task<SubcategoryIncome> GetByIdSubCatIncomeAsync(int id)
        {
            return _subcategoryIncomeService.GetByIdSubCatIncomeAsync(id);
        }

        public async Task<List<SubcategoryIncomeDto>> GetBySubCatIncomeUserIdAsync(int userId)
        {
            var subcategoryIncomes = await _subcategoryIncomeService.GetBySubCatIncomeUserIdAsync(userId);
            return _mapper.Map<List<SubcategoryIncomeDto>>(subcategoryIncomes);
        }

        public async Task<List<SubcategoryIncomeDto>> GetSubcategoryIncomesByCategoryId(int categoryIncomeId)
        {
            var subcategoryCosts = await _subcategoryIncomeService.GetSubcategoryIncomesByCategoryIdAsync(categoryIncomeId);
            return _mapper.Map<List<SubcategoryIncomeDto>>(subcategoryCosts);
        }

    }
}
