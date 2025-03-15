using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts
{
    public interface ICapitalRepository
    {
        Task AddCapitalAsync(Capital capital);
        Task UpdateCapitalAsync(Capital capital);
        Task DeleteCapitalAsync(int id);
        Task<List<Capital>> GetAllCapitalAsync();
        Task<Capital> GetCapitalByIdAsync(int id);
        Task<List<Capital>> GetCapitalByUserIdAsync(int userId);
    }
}
