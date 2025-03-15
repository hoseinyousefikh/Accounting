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
    public class CapitalRepository : ICapitalRepository
    {
        private readonly AppDbContext _context;

        public CapitalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCapitalAsync(Capital capital)
        {
            _context.Capitals.Add(capital);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCapitalAsync(Capital capital)
        {
            _context.Capitals.Update(capital);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCapitalAsync(int id)
        {
            var capital = await _context.Capitals.FindAsync(id);
            if (capital != null)
            {
                _context.Capitals.Remove(capital);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Capital>> GetAllCapitalAsync()
        {
            return await _context.Capitals
                .Include(c => c.AddCapital)
                .ToListAsync();
        }

        public async Task<Capital> GetCapitalByIdAsync(int id)
        {
            var x = await _context.Capitals
                .Include(c => c.AddCapital)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }

        public async Task<List<Capital>> GetCapitalByUserIdAsync(int userId)
        {
            return await _context.Capitals
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
    }
}
