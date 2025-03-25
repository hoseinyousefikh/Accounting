using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts.Sub
{
    public class SubcategoryIncomeRepository : ISubcategoryIncomeRepository
    {
        private readonly AppDbContext _context;

        public SubcategoryIncomeRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Add a new SubcategoryIncome record asynchronously
        public async Task AddSubCatIncomeAsync(SubcategoryIncome subcategoryIncome)
        {
            if (subcategoryIncome == null)
                throw new ArgumentNullException(nameof(subcategoryIncome), "SubcategoryIncome cannot be null.");

            await _context.SubcategoryIncomes.AddAsync(subcategoryIncome);
            await _context.SaveChangesAsync();
        }

        // Update an existing SubcategoryIncome record asynchronously
        public async Task UpdateSubCatIncomeAsync(SubcategoryIncome subcategoryIncome)
        {
            if (subcategoryIncome == null)
                throw new ArgumentNullException(nameof(subcategoryIncome), "SubcategoryIncome cannot be null.");

            _context.SubcategoryIncomes.Update(subcategoryIncome);
            await _context.SaveChangesAsync();
        }

        // Soft delete a SubcategoryIncome record asynchronously by marking it as deleted
        public async Task DeleteSubCatIncomeAsync(int id)
        {
            var subcategoryIncome = await _context.SubcategoryIncomes.FindAsync(id);
            if (subcategoryIncome == null)
            {
                throw new KeyNotFoundException($"SubcategoryIncome with ID {id} not found.");
            }

            // Mark as deleted if soft delete is needed
            subcategoryIncome.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        // Retrieve all SubcategoryIncome records asynchronously
        public async Task<List<SubcategoryIncome>> GetAllSubCatIncomeAsync()
        {
            return await _context.SubcategoryIncomes
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        // Retrieve a specific SubcategoryIncome record by ID asynchronously
        public async Task<SubcategoryIncome> GetBySubCatIncomeIdAsync(int id)
        {
            var subcategoryIncome = await _context.SubcategoryIncomes
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

            if (subcategoryIncome == null)
            {
                throw new KeyNotFoundException($"SubcategoryIncome with ID {id} not found.");
            }

            return subcategoryIncome;
        }

        // Retrieve SubcategoryIncome records by CategoryIncomeId asynchronously
        public async Task<List<SubcategoryIncome>> GetByCategoryIncomeIdAsync(int categoryIncomeId)
        {
            return await _context.SubcategoryIncomes
                .Where(s => s.CategoryIncomeId == categoryIncomeId && !s.IsDeleted)
                .ToListAsync();
        }

        // Retrieve SubcategoryIncome records by UserId asynchronously
        public async Task<List<SubcategoryIncome>> GetBySubCatIncomeUserIdAsync(int userId)
        {
            return await _context.SubcategoryIncomes
                .Where(s => s.UserId == userId && !s.IsDeleted)
                .ToListAsync();
        }
    }
}
