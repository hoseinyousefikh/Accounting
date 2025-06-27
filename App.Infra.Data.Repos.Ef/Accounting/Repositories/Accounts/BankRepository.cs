using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts
{
    public class BankRepository : IBankRepository
    {
        private readonly AppDbContext _context;

        public BankRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddBankAsync(Bank bank)
        {
            if (bank == null)
                throw new ArgumentNullException(nameof(bank), "Bank cannot be null.");

            await _context.Banks.AddAsync(bank);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBankAsync(Bank bank)
        {
            if (bank == null)
                throw new ArgumentNullException(nameof(bank), "Bank cannot be null.");

            _context.Banks.Update(bank);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBankAsync(int id)
        {
            var bank = await _context.Banks.FindAsync(id);
            if (bank == null)
            {
                throw new KeyNotFoundException($"Bank with ID {id} not found.");
            }

            bank.IsDeleted = true;
            _context.Banks.Update(bank);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bank>> GetAllBankAsync()
        {
            return await _context.Banks
                .Where(b => !b.IsDeleted)  
                .Include(b => b.Users)
                .ToListAsync();
        }

        public async Task<Bank> GetBankByIdAsync(int id)
        {
            var bank = await _context.Banks
                .Include(b => b.Users)
                .Where(b => b.Id == id && !b.IsDeleted)  
                .FirstOrDefaultAsync();

            if (bank == null)
            {
                throw new KeyNotFoundException($"Bank with ID {id} not found.");
            }

            return bank;
        }

        public async Task<List<Bank>> GetBankByUserIdAsync(int userId)
        {
            return await _context.Banks
                .Where(b =>
                    (!b.IsDeleted && b.UserId == userId) || b.IsPublic
                )
                .ToListAsync();
        }

    }
}
