using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub
{
    public interface ISubcategoryIncomeAppService
    {
        Task<List<SubcategoryIncomeDto>> GetBySubCatIncomeUserIdAsync(int userId);
        Task<List<SubcategoryIncomeDto>> GetSubcategoryIncomesByCategoryId(int categoryIncomeId);


    }
}
