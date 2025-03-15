using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts.Sub
{
    public class CreditorsRepository : ICreditorsRepository
    {
        private readonly AppDbContext _context;

        public CreditorsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCreditorsAsync(Creditors creditors)
        {
            await _context.Creditorses.AddAsync(creditors);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCreditorsAsync(Creditors creditors)
        {
            _context.Creditorses.Update(creditors);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCreditorsAsync(int id)
        {
            var creditors = await _context.Creditorses.FindAsync(id);
            if (creditors != null)
            {
                creditors.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Creditors> GetCreditorsByIdAsync(int id)
        {
            var x = await _context.Creditorses.FirstOrDefaultAsync(c => c.Id == id);
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }

        public async Task<List<Creditors>> GetCreditorsByUserIdAsync(int userId)
        {
            return await _context.Creditorses.Where(c => c.UserId == userId).ToListAsync();
        }
    }
}
