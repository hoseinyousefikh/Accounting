using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub
{
    public interface IAddCapitalRepository
    {
        Task AddAddCapitalAsync(AddCapital addCapital);
        Task UpdateAddCapitalAsync(AddCapital addCapital);
        Task DeleteAddCapitalAsync(int id);
        Task<List<AddCapital>> GetAddCapitalByPersonConditionAsync(PersonCondition personCondition);
        Task<List<AddCapital>> GetAllAddCapitalAsync();
        Task<AddCapital> GetAddCapitalByIdAsync(int id);
        Task<List<AddCapital>> GetAddCapitalByUserIdAsync(int userId);
        Task<List<AddCapital>> GetAddCapitalByCapitalIdAsync(int capitalId);
    }
}
