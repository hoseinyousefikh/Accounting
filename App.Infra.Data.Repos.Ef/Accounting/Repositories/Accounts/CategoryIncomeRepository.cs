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
    public class CategoryIncomeRepository : ICategoryIncomeRepository
    {
        private readonly AppDbContext _context;

        public CategoryIncomeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryIncomeAsync(CategoryIncome categoryIncome)
        {
            _context.CategoryIncomes.Add(categoryIncome);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryIncomeAsync(CategoryIncome categoryIncome)
        {
            _context.CategoryIncomes.Update(categoryIncome);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryIncomeAsync(int id)
        {
            var categoryIncome = await _context.CategoryIncomes.FindAsync(id);
            if (categoryIncome != null)
            {
                categoryIncome.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryIncome>> GetAllCategoryIncomeAsync()
        {
            return await _context.CategoryIncomes
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<CategoryIncome> GetCategoryIncomeByIdAsync(int id)
        {
            var x = await _context.CategoryIncomes
                .Where(c => c.Id == id && !c.IsDeleted)
                .FirstOrDefaultAsync();
            if (x != null)
            {
                return x;
            }
            throw new Exception("Is null");
        }

        public async Task<List<CategoryIncome>> GetCategoryIncomeByUserIdAsync(int userId)
        {
            return await _context.CategoryIncomes
                .Where(c => c.UserId == userId && !c.IsDeleted)
                .ToListAsync();
        }
    }
}
