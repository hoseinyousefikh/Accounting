using App.Domain.Core.Accounting.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.AppServices.Reports
{
    public interface IListExpensesAppService
    {
        Task<(List<ListExpenses> expenses, decimal totalAmount)> GetUserExpensesWithTotalAsync(int userId);

    }
}
