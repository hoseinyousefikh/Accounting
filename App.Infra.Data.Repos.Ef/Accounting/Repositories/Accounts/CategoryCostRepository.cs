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
    public class CategoryCostRepository : ICategoryCostRepository
    {
        private readonly AppDbContext _context;

        public CategoryCostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryCostAsync(CategoryCost categoryCost)
        {
            _context.CategoryCosts.Add(categoryCost);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryCostAsync(CategoryCost categoryCost)
        {
            _context.CategoryCosts.Update(categoryCost);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryCostAsync(int id)
        {
            var categoryCost = await _context.CategoryCosts.FindAsync(id);
            if (categoryCost != null)
            {
                categoryCost.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryCost>> GetAllCategoryCostAsync()
        {
            return await _context.CategoryCosts
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<CategoryCost> GetCategoryCostByIdAsync(int id)
        {
            var x = await _context.CategoryCosts
                .Where(c => c.Id == id && !c.IsDeleted)
                .FirstOrDefaultAsync();
            if (x != null)
            {
                return x;
            }
            throw new Exception("Is null");
        }

        public async Task<List<CategoryCost>> GetCategoryCostByUserIdAsync(int userId)
        {
            return await _context.CategoryCosts
                .Where(c => c.UserId == userId && !c.IsDeleted)
                .ToListAsync();
        }
    }
}
