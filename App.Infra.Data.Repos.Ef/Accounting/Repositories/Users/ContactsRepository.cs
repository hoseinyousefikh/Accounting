using App.Domain.Core.Accounting.Contract.Repositories.Users;
using App.Domain.Core.Accounting.Entities.Users;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Users
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly AppDbContext _context;

        public ContactsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddContactsAsync(Contacts contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContactsAsync(Contacts contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactsAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Contacts> GetContactsByIdAsync(int id)
        {
            var x = await _context.Contacts
                .Where(c => c.Id == id && !c.IsDeleted)
                .FirstOrDefaultAsync();
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }


        public async Task<List<Contacts>> GetContactsByUserIdAsync(int userId)
        {
            return await _context.Contacts
                .Where(c => c.UserId == userId && !c.IsDeleted)
                .ToListAsync();
        }
    }
}
