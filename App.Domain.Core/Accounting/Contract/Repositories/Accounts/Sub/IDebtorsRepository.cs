using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub
{
    public interface IDebtorsRepository
    {
        Task AddDebtorsAsync(Debtors debtor);
        Task UpdateDebtorsAsync(Debtors debtor);
        Task DeleteDebtorsAsync(int id);
        Task<Debtors> GetDebtorsByIdAsync(int id);
        Task<List<Debtors>> GetDebtorsByUserIdAsync(int userId);
    }
}
