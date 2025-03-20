using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.Accounts
{
    public class CategoryIncomeService : ICategoryIncomeService
    {
        private readonly ICategoryIncomeRepository _categoryIncomeRepository;
        private readonly IMapper _mapper;

        public CategoryIncomeService(ICategoryIncomeRepository categoryIncomeRepository, IMapper mapper)
        {
            _categoryIncomeRepository = categoryIncomeRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryIncomeDto>> GetCategoryIncomeByUserIdAsync(int userId)
        {
            var categoryIncomes = await _categoryIncomeRepository.GetCategoryIncomeByUserIdAsync(userId);
            return _mapper.Map<List<CategoryIncomeDto>>(categoryIncomes);
        }
    }
}
