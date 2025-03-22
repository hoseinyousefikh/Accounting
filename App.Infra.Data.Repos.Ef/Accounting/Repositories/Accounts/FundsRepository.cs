using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts
{
    public class FundsRepository : IFundsRepository
    {
        private readonly AppDbContext _context;

        public FundsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddFundsAsync(Funds fund)
        {
            _context.Funds.Add(fund);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFundsAsync(Funds fund)
        {
            var existingFund = await _context.Funds.FindAsync(fund.Id);
            if (existingFund != null)
            {
                existingFund.Name = fund.Name;
                existingFund.IsPublic = fund.IsPublic;
                existingFund.UserId = fund.UserId;
                existingFund.Users = fund.Users;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteFundsAsync(int id)
        {
            var fund = await _context.Funds.FindAsync(id);
            if (fund != null)
            {
                fund.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Funds> GetFundsByIdAsync(int id)
        {
            var fund = await _context.Funds.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (fund != null)
            {
                return fund;
            }
            throw new Exception("Fund not found");
        }

        public async Task<List<Funds>> GetFundsByUserIdAsync(int userId)
        {
            return await _context.Funds.Where(f => f.UserId == userId && !f.IsDeleted).ToListAsync();
        }

        
    }
}
