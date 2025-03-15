using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts
{
    public class BankRepository : IBankRepository
    {
        private readonly AppDbContext _context;

        public BankRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddBankAsync(Bank bank)
        {
            _context.Banks.Add(bank);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBankAsync(Bank bank)
        {
            _context.Banks.Update(bank);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBankAsync(int id)
        {
            var bank = await _context.Banks.FindAsync(id);
            if (bank != null)
            {
                bank.IsDeleted = true;
                _context.Banks.Update(bank);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Bank>> GetAllBankAsync()
        {
            return await _context.Banks
                .Include(b => b.Users)
                .ToListAsync();
        }

        public async Task<Bank> GetBankByIdAsync(int id)
        {
            var x = await _context.Banks
                .Include(b => b.Users)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            if (x != null)
            {
                return x;
            }
            throw new Exception("Is null");
        }

        public async Task<List<Bank>> GetBankByUserIdAsync(int userId)
        {
            return await _context.Banks
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }
    }
}
