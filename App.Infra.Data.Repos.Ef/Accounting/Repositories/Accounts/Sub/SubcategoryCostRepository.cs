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
    public class SubcategoryCostRepository : ISubcategoryCostRepository
    {
        private readonly AppDbContext _appDbContext;

        public SubcategoryCostRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task AddSubCatCost(SubcategoryCost subcategoryCost)
        {
            await _appDbContext.SubcategoryCosts.AddAsync(subcategoryCost);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateSubCatCost(SubcategoryCost subcategoryCost)
        {
            _appDbContext.SubcategoryCosts.Update(subcategoryCost);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteSubCatCost(int id)
        {
            var subcategoryCost = await _appDbContext.SubcategoryCosts.FindAsync(id);
            if (subcategoryCost != null)
            {
                subcategoryCost.IsDeleted = true;
                _appDbContext.SubcategoryCosts.Update(subcategoryCost);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<SubcategoryCost>> GetAllSubCatCost()
        {
            return await _appDbContext.SubcategoryCosts.Where(sc => !sc.IsDeleted).ToListAsync();
        }

        public async Task<SubcategoryCost> GetByIdSubCatCost(int id)
        {
            var x = await _appDbContext.SubcategoryCosts.FirstOrDefaultAsync(sc => sc.Id == id && !sc.IsDeleted);
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }
        public async Task<List<SubcategoryCost>> GetSubCatCostByCategoryId(int categoryId)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("Invalid category ID", nameof(categoryId));
            }

            var subcategories = await _appDbContext.SubcategoryCosts
                .Where(sc => sc.CategoryCostId == categoryId && !sc.IsDeleted)
                .ToListAsync();

            if (subcategories == null || !subcategories.Any())
            {
                throw new KeyNotFoundException("No subcategories found for the specified category.");
            }

            return subcategories;
        }

        public async Task<List<SubcategoryCost>> GetByUserIdSubCatCost(int userId)
        {
            return await _appDbContext.SubcategoryCosts.Where(sc => sc.UserId == userId && !sc.IsDeleted).ToListAsync();
        }
    }
}
