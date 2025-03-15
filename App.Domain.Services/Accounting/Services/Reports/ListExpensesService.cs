using App.Domain.Core.Accounting.Contract.Repositories.Reports;
using App.Domain.Core.Accounting.Contract.Services.Reports;
using App.Domain.Core.Accounting.Entities.Reports;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.Reports
{
    public class ListExpensesService : IListExpensesService
    {
        private readonly IListExpensesRepository _expenseRepository;

        public ListExpensesService(IListExpensesRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<(List<ListExpenses> expenses, decimal totalAmount)> GetUserExpensesWithTotalAsync(int userId)
        {
            var expenses = await _expenseRepository.GetListExpensesByUserIdAsync(userId);

            decimal totalAmount = expenses.Sum(e => e.Amount);

            return (expenses, totalAmount);
        }
    }
}
