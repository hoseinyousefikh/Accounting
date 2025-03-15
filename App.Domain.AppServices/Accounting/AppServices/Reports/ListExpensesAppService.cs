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
    public class ListExpensesAppService : IListExpensesAppService
    {
        private readonly IListExpensesService _listExpensesService;
        public ListExpensesAppService(IListExpensesService listExpensesService)
        {
            _listExpensesService = listExpensesService;
        }
        public Task<(List<ListExpenses> expenses, decimal totalAmount)> GetUserExpensesWithTotalAsync(int userId)
        {
            return _listExpensesService.GetUserExpensesWithTotalAsync(userId);
        }
    }
}
