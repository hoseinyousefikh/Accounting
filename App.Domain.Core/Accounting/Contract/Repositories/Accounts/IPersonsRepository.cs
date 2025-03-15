using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts
{
    public interface IPersonsRepository
    {
        Task AddPersons(Persons personsEntity);
        Task UpdatePersons(Persons personsEntity);
        Task DeletePersons(int id);
        Task<Persons> GetPersonsById(int id);
        Task<List<Persons>> GetPersonsByUserId(int userId);
        Task<List<Persons>> GetAllPersons();
        Task<List<Persons>> GetPersonsByContactId(int contactId);
        Task<List<Persons>> GetPersonsByPhoneNumber(int phoneNumber);
        Task<List<Persons>> GetPersonsByPersonCondition(PersonCondition condition);
        Task<List<Persons>> GetCreditors();
        Task<List<Persons>> GetDebtors();
    }
}
