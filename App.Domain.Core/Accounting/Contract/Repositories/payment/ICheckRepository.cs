using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.payment
{
    public interface ICheckRepository
    {
        Task AddCheckAsync(Check check);
        Task DeleteCheckAsync(int id);
        Task UpdateCheckAsync(Check check);
        Task<List<Check>> GetCheckByDateAsync(DateTime date);
        Task<List<Check>> GetCheckByDueDateAsync(DateTime dueDate);
        Task<List<Check>> GetCheckByBankIdAsync(int bankId);
        Task<List<Check>> GetCheckByExpensesAsync(Xxpens expenseType);
        Task<List<Check>> GetCheckByUserIdAsync(int userId);
        Task<Check> GetCheckByIdAsync(int id);
        Task<List<Xxpens>> GetAllExpenseStatusesAsync();
    }
}
