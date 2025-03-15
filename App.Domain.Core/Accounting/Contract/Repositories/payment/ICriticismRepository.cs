using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.payment
{
    public interface ICriticismRepository
    {
        Task AddCriticismAsync(Criticism criticism);
        Task UpdateCriticismAsync(Criticism criticism);
        Task DeleteCriticismAsync(int id);
        Task<Criticism> GetCriticismByIdAsync(int id);
        Task<IEnumerable<Criticism>> GetCriticismByUserIdAsync(int userId);
        Task<IEnumerable<Criticism>> GetCriticismByMemberIdAsync(int memberId);
        Task<IEnumerable<Criticism>> GetCriticismByExpensAsync(Xxpens expensType);
        Task<IEnumerable<Criticism>> GetCriticismByDateAsync(DateTime date);
        Task<IEnumerable<Xxpens>> GetAllExpenseStatusesAsync();
    }

}
