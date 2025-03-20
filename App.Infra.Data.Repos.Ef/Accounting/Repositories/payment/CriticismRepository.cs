using App.Domain.Core.Accounting.Contract.Repositories.payment;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.payment;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.payment
{
    public class CriticismRepository : ICriticismRepository
    {
        private readonly AppDbContext _dbContext;

        public CriticismRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCriticismAsync(Criticism criticism)
        {
            await _dbContext.Criticisms.AddAsync(criticism);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCriticismAsync(Criticism criticism)
        {
            var existing = await _dbContext.Criticisms.FindAsync(criticism.Id);
            if (existing != null)
            {
                existing.Date = criticism.Date;
                existing.Amount = criticism.Amount;
                existing.Description = criticism.Description;
                existing.IsDeleted = criticism.IsDeleted;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteCriticismAsync(int id)
        {
            var criticism = await _dbContext.Criticisms.FindAsync(id);
            if (criticism != null)
            {
                criticism.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Criticism> GetCriticismByIdAsync(int id)
        {
            var criticism = await _dbContext.Criticisms
                .FirstOrDefaultAsync(c => c.Id == id);
            if (criticism != null)
            {
                return criticism;
            }
            throw new Exception("Criticism not found.");
        }

        public async Task<IEnumerable<Criticism>> GetCriticismByUserIdAsync(int userId)
        {
            return await _dbContext.Criticisms
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Criticism>> GetCriticismByMemberIdAsync(int memberId)
        {
            return await _dbContext.Criticisms
                .Where(c => c.MemderId == memberId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Criticism>> GetCriticismByExpensAsync(Xxpens expensType)
        {
            return await _dbContext.Criticisms
                .Where(c => c.Xxpenses == expensType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Criticism>> GetCriticismByDateAsync(DateTime date)
        {
            return await _dbContext.Criticisms
                .Where(c => c.Date.Date == date.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Xxpens>> GetAllExpenseStatusesAsync()
        {
            return Enum.GetValues(typeof(Xxpens)).Cast<Xxpens>().ToList();
        }
    }
}
