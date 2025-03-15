using App.Domain.Core.Accounting.Contract.Repositories.Reports;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.Reports;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Reports
{
    public class ListExpensesRepository : IListExpensesRepository
    {
        private readonly AppDbContext _context;

        public ListExpensesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddListExpensesAsync(ListExpenses expense)
        {
            await _context.ListExpenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateListExpensesAsync(ListExpenses expense)
        {
            _context.ListExpenses.Update(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteListExpensesAsync(int id)
        {
            var expense = await _context.ListExpenses.FindAsync(id);
            if (expense != null)
            {
                expense.IsDeleted = true;
                _context.ListExpenses.Update(expense);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ListExpenses>> GetAllListExpensesAsync()
        {
            return await _context.ListExpenses
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<ListExpenses> GetListExpensesByIdAsync(int id)
        {
            var expense = await _context.ListExpenses
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

            if (expense != null)
            {
                return expense;
            }

            throw new Exception("Expense not found");
        }

        public async Task<List<ListExpenses>> GetListExpensesByUserIdAsync(int userId)
        {
            return await _context.ListExpenses
                .Where(e => e.UserId == userId && !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<ListExpenses>> GetListExpensesByDueDateAsync(DateTime dueDate)
        {
            return await _context.ListExpenses
                .Where(e => e.DueDate.Date == dueDate.Date && !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<ListExpenses>> GetListExpensesByPaymentTypeAsync(PaymentType paymentType)
        {
            return await _context.ListExpenses
                .Where(e => e.PaymentType == paymentType && !e.IsDeleted)
                .ToListAsync();
        }
    }
}
