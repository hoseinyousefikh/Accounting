using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Services.Accounts
{
    public interface ICategoryCostService
    {
        Task<List<CategoryCost>> GetCategoryCostByUserIdAsync(int userId);

    }
}
