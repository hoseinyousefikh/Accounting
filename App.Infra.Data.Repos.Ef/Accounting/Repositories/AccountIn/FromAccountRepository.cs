using App.Domain.Core.Accounting.Contract.Repositories.AccountIn;
using App.Domain.Core.Accounting.Entities.AccountIn;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.payment;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.AccountIn
{
    public class FromAccountRepository : IFromAccountRepository
    {
        private readonly AppDbContext _context;

        public FromAccountRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public async Task<int> AddFromAccountAsync(FromAccount fromAccount)
        {
            if (fromAccount == null)
                throw new ArgumentNullException(nameof(fromAccount), "The fromAccount object cannot be null.");

            var entityEntry = await _context.FromAccounts.AddAsync(fromAccount);
            await _context.SaveChangesAsync();

            return entityEntry.Entity.Id;
        }

        public async Task UpdateFromAccountAsync(FromAccount fromAccount)
        {
            if (fromAccount == null)
                throw new ArgumentNullException(nameof(fromAccount), "The fromAccount object cannot be null.");

            var existingFromAccount = await _context.FromAccounts
                                                     .FirstOrDefaultAsync(fa => fa.Id == fromAccount.Id);

            if (existingFromAccount == null)
                throw new InvalidOperationException($"FromAccount with ID {fromAccount.Id} not found.");
            existingFromAccount.AssetsId = fromAccount.AssetsId;
            existingFromAccount.BankId = fromAccount.BankId;
            existingFromAccount.CapitalId = fromAccount.CapitalId;
            existingFromAccount.CategoryCostId = fromAccount.CategoryCostId;
            existingFromAccount.CategoryIncomeId = fromAccount.CategoryIncomeId;
            existingFromAccount.DebtsId = fromAccount.DebtsId;
            existingFromAccount.FundsId = fromAccount.FundsId;
            existingFromAccount.PersonsId = fromAccount.PersonsId;
            existingFromAccount.CriticismId = fromAccount.CriticismId;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Assets>> GetAllAssetsAsync()
        {
            var assets = await _context.Assets.ToListAsync();
            return assets?.Any() == true ? assets : null;
        }

        public async Task<List<Bank>> GetAllBanksAsync()
        {
            var banks = await _context.Banks.ToListAsync();
            return banks?.Any() == true ? banks : null;
        }

        public async Task<List<Capital>> GetAllCapitalsAsync()
        {
            var capitals = await _context.Capitals.ToListAsync();
            return capitals?.Any() == true ? capitals : null;
        }

        public async Task<List<CategoryCost>> GetAllCategoryCostsAsync()
        {
            var categoryCosts = await _context.CategoryCosts.ToListAsync();
            return categoryCosts?.Any() == true ? categoryCosts : null;
        }

        public async Task<List<CategoryIncome>> GetAllCategoryIncomesAsync()
        {
            var categoryIncomes = await _context.CategoryIncomes.ToListAsync();
            return categoryIncomes?.Any() == true ? categoryIncomes : null;
        }

        public async Task<List<Debts>> GetAllDebtsAsync()
        {
            var debts = await _context.Debts.ToListAsync();
            return debts?.Any() == true ? debts : null;
        }

        public async Task<List<Funds>> GetAllFundsAsync()
        {
            var funds = await _context.Funds.ToListAsync();
            return funds?.Any() == true ? funds : null;
        }

        public async Task<List<Persons>> GetAllPersonsAsync()
        {
            var persons = await _context.Persons.ToListAsync();
            return persons?.Any() == true ? persons : null;
        }

        public async Task<List<Criticism>> GetAllCriticismsAsync()
        {
            var criticisms = await _context.Criticisms.ToListAsync();
            return criticisms?.Any() == true ? criticisms : null;
        }
    }
}
