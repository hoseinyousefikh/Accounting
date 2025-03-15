using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub
{
    public interface IAddDbtsRepository
    {
        Task AddAddDbtsAsync(AddDbts addDbts);
        Task UpdateAddDbtsAsync(AddDbts addDbts);
        Task DeleteAddDbtsAsync(int id);
        Task<List<AddDbts>> GetAddDbtsByPersonConditionAsync(PersonCondition personCondition);
        Task<List<AddDbts>> GetAllAddDbtsAsync();
        Task<AddDbts> GetAddDbtsByIdAsync(int id);
        Task<List<AddDbts>> GetAddDbtsByUserIdAsync(int userId);
        Task<List<AddDbts>> GetAddDbtsByDebtsIdAsync(int debtsId);
    }
}
