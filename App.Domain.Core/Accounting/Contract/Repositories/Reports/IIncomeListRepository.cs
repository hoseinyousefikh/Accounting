using App.Domain.Core.Accounting.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Reports
{
    public interface IIncomeListRepository
    {
        Task AddAsync(IncomeList incomeList);
        Task UpdateAsync(IncomeList incomeList);
        Task DeleteAsync(int id);
        Task<IEnumerable<IncomeList>> GetAllAsync();
        Task<IncomeList> GetByIdAsync(int id);
        Task<List<IncomeList>> GetByUserIdAsync(int userId);
        Task<IEnumerable<IncomeList>> GetByDueDateAsync(DateTime dueDate);
        Task<IEnumerable<IncomeList>> GetByTimingAsync(DateTime startDate, DateTime endDate);
    }
}
