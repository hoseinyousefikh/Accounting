using App.Domain.Core.Accounting.Contract.Repositories.Budgetings;
using App.Domain.Core.Accounting.Entities.Budgetings;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Budgetings
{
    public class BudgetingRepository : IBudgetingRepository
    {
        private readonly AppDbContext _context;

        public BudgetingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddBudgetingAsync(Budgeting budgeting)
        {
            _context.Budgetings.Add(budgeting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBudgetingAsync(Budgeting budgeting)
        {
            _context.Budgetings.Update(budgeting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBudgetingAsync(int id)
        {
            var budgeting = await _context.Budgetings.FindAsync(id);
            if (budgeting != null)
            {
                budgeting.IsDeleted = true;
                _context.Budgetings.Update(budgeting);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Budgeting>> GetAllBudgetingAsync()
        {
            return await _context.Budgetings
                .Where(b => !b.IsDeleted) // فیلتر کردن بودجه‌های حذف نشده
                .Include(b => b.Users)
                .ToListAsync();
        }

        public async Task<Budgeting> GetBudgetingByIdAsync(int id)
        {
            var x = await _context.Budgetings
                .Where(b => b.Id == id && !b.IsDeleted) // اضافه کردن شرط برای حذف نشده بودن
                .Include(b => b.Users)
                .FirstOrDefaultAsync();
            if (x != null)
            {
                return x;
            }
            throw new Exception("Is null");
        }

        public async Task<List<Budgeting>> GetBudgetingByUserIdAsync(int userId)
        {
            return await _context.Budgetings
                .Where(b => b.UserId == userId && !b.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Budgeting>> GetBudgetingByExpensAsync(Xxpens expens)
        {
            return await _context.Budgetings
                .Where(b => b.Xxpenses == expens && !b.IsDeleted) 
                .ToListAsync();
        }

        public async Task<List<Budgeting>> GetBudgetingByTimingAsync(Timing timing)
        {
            return await _context.Budgetings
                .Where(b => b.timings == timing && !b.IsDeleted)
                .ToListAsync();
        }

    }
}
