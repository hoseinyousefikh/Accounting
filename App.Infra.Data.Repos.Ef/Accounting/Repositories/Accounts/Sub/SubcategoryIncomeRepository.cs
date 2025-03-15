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
    public class SubcategoryIncomeRepository : ISubcategoryIncomeRepository
    {
        private readonly AppDbContext _context;

        public SubcategoryIncomeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddSubCatIncome(SubcategoryIncome subcategoryIncome)
        {
            await _context.SubcategoryIncomes.AddAsync(subcategoryIncome);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubCatIncome(SubcategoryIncome subcategoryIncome)
        {
            _context.SubcategoryIncomes.Update(subcategoryIncome);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubCatIncome(int id)
        {
            var subcategoryIncome = await _context.SubcategoryIncomes.FindAsync(id);
            if (subcategoryIncome != null)
            {
                subcategoryIncome.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SubcategoryIncome>> GetAllSubCatIncome()
        {
            return await _context.SubcategoryIncomes
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<SubcategoryIncome> GetBySubCatIncomeId(int id)
        {
            var x = await _context.SubcategoryIncomes
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }

        public async Task<List<SubcategoryIncome>> GetBySubCatIncomeUserId(int userId)
        {
            return await _context.SubcategoryIncomes
                .Where(s => s.UserId == userId && !s.IsDeleted)
                .ToListAsync();
        }
    }
}
