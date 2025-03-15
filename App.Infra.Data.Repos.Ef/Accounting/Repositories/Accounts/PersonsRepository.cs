using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly AppDbContext _context;

        public PersonsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPersons(Persons personsEntity)
        {
            await _context.Persons.AddAsync(personsEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersons(Persons personsEntity)
        {
            _context.Persons.Update(personsEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersons(int id)
        {
            var personsEntity = await _context.Persons.FindAsync(id);
            if (personsEntity != null)
            {
                personsEntity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Persons> GetPersonsById(int id)
        {
            var x = await _context.Persons
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }

        public async Task<List<Persons>> GetPersonsByUserId(int userId)
        {
            return await _context.Persons
                .Where(p => p.UserId == userId && !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Persons>> GetAllPersons()
        {
            return await _context.Persons
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Persons>> GetPersonsByContactId(int contactId)
        {
            return await _context.Persons
                .Where(p => p.Contacts != null && p.Contacts.Id == contactId && !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Persons>> GetPersonsByPhoneNumber(int phoneNumber)
        {
            return await _context.Persons
                .Where(p => p.PhonNumber == phoneNumber && !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Persons>> GetPersonsByPersonCondition(PersonCondition condition)
        {
            return await _context.Persons
                .Where(p => p.PersonConditions == condition && !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Persons>> GetCreditors()
        {
            return await _context.Persons
                .Where(p => p.PersonConditions == PersonCondition.creditor && !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Persons>> GetDebtors()
        {
            return await _context.Persons
                .Where(p => p.PersonConditions == PersonCondition.debtor && !p.IsDeleted)
                .ToListAsync();
        }
    }
}
