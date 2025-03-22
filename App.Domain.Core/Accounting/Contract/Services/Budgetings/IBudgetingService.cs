using App.Domain.Core.Accounting.Entities.Budgetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Services.Budgetings
{
    public interface IBudgetingService
    {
        Task AddBudgetingAsync(Budgeting budgeting);
        Task UpdateBudgetingAsync(Budgeting budgeting);
        Task DeleteBudgetingAsync(int id);
        Task<Budgeting> GetBudgetingByIdAsync(int id);
        Task<List<Budgeting>> GetBudgetingByUserIdAsync(int userId);
    }
}
