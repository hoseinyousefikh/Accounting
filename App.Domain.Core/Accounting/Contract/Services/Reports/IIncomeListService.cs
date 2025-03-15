using App.Domain.Core.Accounting.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Services.Reports
{
    public interface IIncomeListService
    {
        Task<(List<IncomeList> expenses, decimal totalAmount)> GetUserExpensesWithTotalAsync(int userId);
    }
}
