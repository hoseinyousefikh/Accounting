using App.Domain.Core.Accounting.Contract.Repositories.payment;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.payment;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.payment
{

    public class CheckRepository : ICheckRepository
    {
        private readonly AppDbContext _context;

        public CheckRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCheckAsync(Check check)
        {
            _context.Checks.Add(check);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCheckAsync(int id)
        {
            var check = await _context.Checks.FindAsync(id);
            if (check != null)
            {
                check.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCheckAsync(Check check)
        {
            _context.Checks.Update(check);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Check>> GetCheckByDateAsync(DateTime date)
        {
            return await _context.Checks
                .Where(c => c.Date.Date == date.Date && !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Check>> GetCheckByDueDateAsync(DateTime dueDate)
        {
            return await _context.Checks
                .Where(c => c.DuDate.Date == dueDate.Date && !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Check>> GetCheckByBankIdAsync(int bankId)
        {
            return await _context.Checks
                .Where(c => c.BankId == bankId && !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Check>> GetCheckByExpensesAsync(Xxpens expenseType)
        {
            return await _context.Checks
                .Where(c => c.Xxpenses == expenseType && !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Check>> GetCheckByUserIdAsync(int userId)
        {
            return await _context.Checks
                .Where(c => c.UserId == userId && !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<Check> GetCheckByIdAsync(int id)
        {
            var x = await _context.Checks
                .Where(c => c.Id == id && !c.IsDeleted)
                .FirstOrDefaultAsync();
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }

        public Task<List<Xxpens>> GetAllExpenseStatusesAsync()
        {
            return Task.FromResult(Enum.GetValues(typeof(Xxpens))
                .Cast<Xxpens>()
                .ToList());
        }
    }
}
