using App.Domain.Core.Accounting.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Users
{
    public interface IContactsRepository
    {
        Task AddContactsAsync(Contacts contact);
        Task UpdateContactsAsync(Contacts contact);
        Task DeleteContactsAsync(int id);
        Task<Contacts> GetContactsByIdAsync(int id);
        Task<List<Contacts>> GetContactsByUserIdAsync(int userId);
    }
}
