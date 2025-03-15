using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts
{
    public interface IFundsRepository
    {
        Task AddFundsAsync(Funds fund);
        Task UpdateFundsAsync(Funds fund);
        Task DeleteFundsAsync(int id);
        Task<Funds> GetFundsByIdAsync(int id);
        Task<List<Funds>> GetFundsByUserIdAsync(int userId);
        Task<List<Funds>> GetFundsByFundOperationsAsync();
    }
}
