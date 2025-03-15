using App.Domain.Core.Accounting.Contract.Repositories.Loans;
using App.Domain.Core.Accounting.Entities.Loans;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Loans
{
    public class SettledLoansRepository : ISettledLoansRepository
    {
        private readonly AppDbContext _context;

        public SettledLoansRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddSettledLoans(SettledLoans settledLoan)
        {
            await _context.SettledLoans.AddAsync(settledLoan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSettledLoans(SettledLoans settledLoan)
        {
            _context.SettledLoans.Update(settledLoan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSettledLoans(int id)
        {
            var settledLoan = await _context.SettledLoans.FindAsync(id);
            if (settledLoan != null)
            {
                settledLoan.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SettledLoans>> GetAllSettledLoans()
        {
            return await _context.SettledLoans
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<SettledLoans> GetSettledLoansById(int id)
        {
            var x = await _context.SettledLoans
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }

        public async Task<List<SettledLoans>> GetSettledLoansByUserId(int userId)
        {
            return await _context.SettledLoans
                .Where(s => s.UserId == userId && !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<SettledLoans>> GetSettledLoansByTime(DateTime startTime, DateTime endTime)
        {
            return await _context.SettledLoans
                .Where(s => s.ReceiveTime >= startTime && s.ReceiveTime <= endTime && !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<SettledLoans>> GetSettledLoansByActive()
        {
            return await _context.SettledLoans
                .Where(s => s.IsActive && !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<SettledLoans>> GetSettledLoansByNotActive()
        {
            return await _context.SettledLoans
                .Where(s => !s.IsActive && !s.IsDeleted)
                .ToListAsync();
        }
    }
}
