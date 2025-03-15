using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts
{
    public interface IBankRepository
    {
        Task AddBankAsync(Bank bank);
        Task UpdateBankAsync(Bank bank);
        Task DeleteBankAsync(int id);
        Task<List<Bank>> GetAllBankAsync();
        Task<Bank> GetBankByIdAsync(int id);
        Task<List<Bank>> GetBankByUserIdAsync(int userId);
    }
}
