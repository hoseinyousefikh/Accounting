using App.Domain.Core.Accounting.Entities.Budgetings;
using App.Domain.Core.Accounting.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Budgetings
{
    public interface IBudgetingRepository
    {
        Task AddBudgetingAsync(Budgeting budgeting);
        Task UpdateBudgetingAsync(Budgeting budgeting);
        Task DeleteBudgetingAsync(int id);
        Task<List<Budgeting>> GetAllBudgetingAsync();
        Task<Budgeting> GetBudgetingByIdAsync(int id);
        Task<List<Budgeting>> GetBudgetingByUserIdAsync(int userId);
        Task<List<Budgeting>> GetBudgetingByExpensAsync(Xxpens expens);
        Task<List<Budgeting>> GetBudgetingByTimingAsync(Timing timing);
    }
}

