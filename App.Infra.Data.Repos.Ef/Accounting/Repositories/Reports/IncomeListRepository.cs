using App.Domain.Core.Accounting.Contract.Repositories.Reports;
using App.Domain.Core.Accounting.Entities.Reports;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Reports
{
    public class IncomeListRepository : IIncomeListRepository
    {
        private readonly AppDbContext _context;

        public IncomeListRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(IncomeList incomeList)
        {
            await _context.IncomeLists.AddAsync(incomeList);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IncomeList incomeList)
        {
            _context.IncomeLists.Update(incomeList);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var incomeList = await _context.IncomeLists.FirstOrDefaultAsync(x => x.Id == id);
            if (incomeList != null)
            {
                incomeList.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IncomeList>> GetAllAsync()
        {
            return await _context.IncomeLists
                                 .Where(x => !x.IsDeleted)
                                 .ToListAsync();
        }

        public async Task<IncomeList> GetByIdAsync(int id)
        {
            var x = await _context.IncomeLists
                                 .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (x != null)
            {
                return x;
            }
            throw new Exception("Is null");
        }

        public async Task<List<IncomeList>> GetByUserIdAsync(int userId)
        {
            return await _context.IncomeLists
                                 .Where(x => x.UserId == userId && !x.IsDeleted)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<IncomeList>> GetByDueDateAsync(DateTime dueDate)
        {
            return await _context.IncomeLists
                                 .Where(x => x.DueDate == dueDate && !x.IsDeleted)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<IncomeList>> GetByTimingAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.IncomeLists
                                 .Where(x => x.Date >= startDate && x.Date <= endDate && !x.IsDeleted)
                                 .ToListAsync();
        }
    }
}

