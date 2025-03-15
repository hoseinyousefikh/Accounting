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


        public async Task AddFromAccountAsync(FromAccount fromAccount)
        {
            if (fromAccount == null)
                throw new ArgumentNullException(nameof(fromAccount), "The fromAccount object cannot be null.");
            await _context.FromAccounts.AddAsync(fromAccount);
            await _context.SaveChangesAsync();
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
            if (assets == null || !assets.Any())
                throw new InvalidOperationException("No assets found.");

            return assets;
        }

        public async Task<List<Bank>> GetAllBanksAsync()
        {
            var banks = await _context.Banks.ToListAsync();
            if (banks == null || !banks.Any())
                throw new InvalidOperationException("No banks found.");

            return banks;
        }

        public async Task<List<Capital>> GetAllCapitalsAsync()
        {
            var capitals = await _context.Capitals.ToListAsync();
            if (capitals == null || !capitals.Any())
                throw new InvalidOperationException("No capitals found.");

            return capitals;
        }

        public async Task<List<CategoryCost>> GetAllCategoryCostsAsync()
        {
            var categoryCosts = await _context.CategoryCosts.ToListAsync();
            if (categoryCosts == null || !categoryCosts.Any())
                throw new InvalidOperationException("No category costs found.");

            return categoryCosts;
        }

        public async Task<List<CategoryIncome>> GetAllCategoryIncomesAsync()
        {
            var categoryIncomes = await _context.CategoryIncomes.ToListAsync();
            if (categoryIncomes == null || !categoryIncomes.Any())
                throw new InvalidOperationException("No category incomes found.");

            return categoryIncomes;
        }

        public async Task<List<Debts>> GetAllDebtsAsync()
        {
            var debts = await _context.Debts.ToListAsync();
            if (debts == null || !debts.Any())
                throw new InvalidOperationException("No debts found.");

            return debts;
        }

        public async Task<List<Funds>> GetAllFundsAsync()
        {
            var funds = await _context.Funds.ToListAsync();
            if (funds == null || !funds.Any())
                throw new InvalidOperationException("No funds found.");

            return funds;
        }

        public async Task<List<Persons>> GetAllPersonsAsync()
        {
            var persons = await _context.Persons.ToListAsync();
            if (persons == null || !persons.Any())
                throw new InvalidOperationException("No persons found.");

            return persons;
        }

        public async Task<List<Criticism>> GetAllCriticismsAsync()
        {
            var criticisms = await _context.Criticisms.ToListAsync();
            if (criticisms == null || !criticisms.Any())
                throw new InvalidOperationException("No criticisms found.");

            return criticisms;
        }
    }
}
