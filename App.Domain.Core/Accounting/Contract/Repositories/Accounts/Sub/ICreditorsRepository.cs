using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub
{
    public interface ICreditorsRepository
    {
        Task AddCreditorsAsync(Creditors creditors);
        Task UpdateCreditorsAsync(Creditors creditors);
        Task DeleteCreditorsAsync(int id);
        Task<Creditors> GetCreditorsByIdAsync(int id);
        Task<List<Creditors>> GetCreditorsByUserIdAsync(int userId);
    }
}
