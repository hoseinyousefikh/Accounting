using App.Domain.Core.Accounting.Contract.AppServices.Reports;
using App.Domain.Core.Accounting.Contract.Services.Reports;
using App.Domain.Core.Accounting.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.Reports
{
    public class IncomeListAppService : IIncomeListAppService
    {
        private readonly IIncomeListService _incomeListService;
        public IncomeListAppService(IIncomeListService incomeListService)
        {
            _incomeListService = incomeListService;
        }
        public Task<(List<IncomeList> expenses, decimal totalAmount)> GetUserExpensesWithTotalAsync(int userId)
        {
            return _incomeListService.GetUserExpensesWithTotalAsync(userId);
        }
    }
}
