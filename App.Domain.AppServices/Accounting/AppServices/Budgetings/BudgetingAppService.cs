using App.Domain.Core.Accounting.Contract.AppServices.Budgetings;
using App.Domain.Core.Accounting.Contract.Services.Budgetings;
using App.Domain.Core.Accounting.Entities.Budgetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.Budgetings
{
    public class BudgetingAppService : IBudgetingAppService
    {
        private readonly IBudgetingService _budgetingService;

        public BudgetingAppService(IBudgetingService budgetingService)
        {
            _budgetingService = budgetingService;
        }

        public Task AddBudgetingAsync(Budgeting budgeting)
        {
            return _budgetingService.AddBudgetingAsync(budgeting);
        }

        public Task DeleteBudgetingAsync(int id)
        {
            return _budgetingService.DeleteBudgetingAsync(id);
        }

        public Task<Budgeting> GetBudgetingByIdAsync(int id)
        {
            return _budgetingService.GetBudgetingByIdAsync(id);
        }

        public Task<List<Budgeting>> GetBudgetingByUserIdAsync(int userId)
        {
            return _budgetingService.GetBudgetingByUserIdAsync(userId);
        }

        public Task UpdateBudgetingAsync(Budgeting budgeting)
        {
            return _budgetingService.UpdateBudgetingAsync(budgeting);
        }
    }
}
