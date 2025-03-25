using App.Domain.Core.Accounting.Contract.Repositories.AccountIn;
using App.Domain.Core.Accounting.Entities.AccountIn;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.payment;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.AccountIn
{
    public class FromAccountRepository : IFromAccountRepository
    {
        private readonly AppDbContext _context;

        public FromAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FromAccount> GetFromAccountByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID", nameof(id));

            return await _context.FromAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(fa => fa.Id == id)
                ?? throw new KeyNotFoundException($"FromAccount with ID {id} not found.");
        }

        public async Task<int> AddFromAccountAsync(FromAccount fromAccount)
        {
            if (fromAccount == null)
                throw new ArgumentNullException(nameof(fromAccount), "The fromAccount object cannot be null.");

            await _context.FromAccounts.AddAsync(fromAccount);
            await _context.SaveChangesAsync();

            return fromAccount.Id;
        }

        public async Task UpdateFromAccountAsync(FromAccount fromAccount)
        {
            if (fromAccount == null)
                throw new ArgumentNullException(nameof(fromAccount), "The fromAccount object cannot be null.");

            var existingFromAccount = await _context.FromAccounts.FindAsync(fromAccount.Id);
            if (existingFromAccount == null)
                throw new KeyNotFoundException($"FromAccount with ID {fromAccount.Id} not found.");

            _context.Entry(existingFromAccount).CurrentValues.SetValues(fromAccount);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Assets>> GetAllAssetsAsync()
        {
            return await _context.Assets.AsNoTracking().ToListAsync();
        }

        public async Task<List<Bank>> GetAllBanksAsync()
        {
            return await _context.Banks.AsNoTracking().ToListAsync();
        }

        public async Task<List<Capital>> GetAllCapitalsAsync()
        {
            return await _context.Capitals.AsNoTracking().ToListAsync();
        }

        public async Task<List<Debts>> GetAllDebtsAsync()
        {
            return await _context.Debts.AsNoTracking().ToListAsync();
        }

        public async Task<List<Funds>> GetAllFundsAsync()
        {
            return await _context.Funds.AsNoTracking().ToListAsync();
        }

        public async Task<List<Persons>> GetAllPersonsAsync()
        {
            return await _context.Persons.AsNoTracking().ToListAsync();
        }

        public async Task<List<Creditors>> GetAllCreditorsAsync()
        {
            return await _context.Creditorses.AsNoTracking().ToListAsync();
        }

        public async Task<List<SubcategoryIncome>> GetAllSubCategoryIncomesAsync()
        {
            return await _context.SubcategoryIncomes.AsNoTracking().ToListAsync();
        }
    }
}
