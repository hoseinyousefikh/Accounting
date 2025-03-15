using App.Domain.Core.Accounting.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.AppServices.Reports
{
    public interface IIncomeListAppService
    {
        Task<(List<IncomeList> expenses, decimal totalAmount)> GetUserExpensesWithTotalAsync(int userId);

    }
}
