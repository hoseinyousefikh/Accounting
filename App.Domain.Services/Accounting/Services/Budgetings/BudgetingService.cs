using App.Domain.Core.Accounting.Contract.Repositories.Budgetings;
using App.Domain.Core.Accounting.Contract.Services.Budgetings;
using App.Domain.Core.Accounting.Entities.Budgetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.Budgetings
{
    public class BudgetingService : IBudgetingService
    {
        private readonly IBudgetingRepository _budgetingRepository;

        public BudgetingService(IBudgetingRepository budgetingRepository)
        {
            _budgetingRepository = budgetingRepository;
        }

        public async Task AddBudgetingAsync(Budgeting budgeting)
        {
            await _budgetingRepository.AddBudgetingAsync(budgeting);
        }

        public async Task UpdateBudgetingAsync(Budgeting budgeting)
        {
            await _budgetingRepository.UpdateBudgetingAsync(budgeting);
        }

        public async Task DeleteBudgetingAsync(int id)
        {
            await _budgetingRepository.DeleteBudgetingAsync(id);
        }

        public async Task<Budgeting> GetBudgetingByIdAsync(int id)
        {
            return await _budgetingRepository.GetBudgetingByIdAsync(id);
        }

        public async Task<List<Budgeting>> GetBudgetingByUserIdAsync(int userId)
        {
            return await _budgetingRepository.GetBudgetingByUserIdAsync(userId);
        }
    }
}
