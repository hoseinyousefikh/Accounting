using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.AppServices.Accounts
{
    public interface IBankAppService
    {
        Task AddBankAsync(Bank bank);
        Task<List<Bank>> GetBankByUserIdAsync(int userId);
    }
}
