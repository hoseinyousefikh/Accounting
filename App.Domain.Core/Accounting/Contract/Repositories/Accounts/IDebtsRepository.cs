using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts
{
    public interface IDebtsRepository
    {
        Task AddDebtsAsync(Debts debt);
        Task UpdateDebtsAsync(Debts debt);
        Task DeleteDebtsAsync(int id);
        Task<Debts> GetDebtsByIdAsync(int id);
        Task<List<Debts>> GetDebtsByUserIdAsync(int userId);
    }
}
