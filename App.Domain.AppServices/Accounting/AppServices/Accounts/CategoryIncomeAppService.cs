using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.Accounts
{
    public class CategoryIncomeAppService : ICategoryIncomeAppService
    {
        private readonly ICategoryIncomeService _categoryIncomeService;
        public CategoryIncomeAppService(ICategoryIncomeService categoryIncomeService)
        {
           _categoryIncomeService = categoryIncomeService;
        }
        public Task<List<CategoryIncomeDto>> GetCategoryIncomeByUserIdAsync(int userId)
        {
            return _categoryIncomeService.GetCategoryIncomeByUserIdAsync(userId);
        }
    }
}
