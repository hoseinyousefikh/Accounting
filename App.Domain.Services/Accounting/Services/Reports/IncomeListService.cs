using App.Domain.Core.Accounting.Contract.Repositories.Reports;
using App.Domain.Core.Accounting.Contract.Services.Reports;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Reports;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.Reports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.Reports
{
    public class IncomeListService : IIncomeListService
    {

        private readonly IIncomeListRepository _incomeListRepository;
        public IncomeListService(IIncomeListRepository incomeListRepository)
        {
            _incomeListRepository = incomeListRepository;
        }
        public async Task<(List<IncomeList> expenses, decimal totalAmount)> GetUserExpensesWithTotalAsync(int userId)
        {
            var income = await _incomeListRepository.GetByUserIdAsync(userId);

            decimal totalAmount = income.Sum(e => e.Amount);

            return (income, totalAmount);
        }

    }
}
