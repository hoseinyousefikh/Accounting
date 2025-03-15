using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Reports
{
    public interface IListExpensesRepository
    {

        Task AddListExpensesAsync(ListExpenses expense);
        Task UpdateListExpensesAsync(ListExpenses expense);
        Task DeleteListExpensesAsync(int id);
        Task<List<ListExpenses>> GetAllListExpensesAsync();
        Task<ListExpenses> GetListExpensesByIdAsync(int id);
        Task<List<ListExpenses>> GetListExpensesByUserIdAsync(int userId);
        Task<List<ListExpenses>> GetListExpensesByDueDateAsync(DateTime dueDate);
        Task<List<ListExpenses>> GetListExpensesByPaymentTypeAsync(PaymentType paymentType);
    }
}
