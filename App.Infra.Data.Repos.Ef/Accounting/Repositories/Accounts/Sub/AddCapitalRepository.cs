using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts.Sub
{
    public class AddCapitalRepository : IAddCapitalRepository
    {
        private readonly AppDbContext _context;

        public AddCapitalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAddCapitalAsync(AddCapital addCapital)
        {
            _context.AddCapitals.Add(addCapital);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddCapitalAsync(AddCapital addCapital)
        {
            _context.AddCapitals.Update(addCapital);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddCapitalAsync(int id)
        {
            var addCapital = await _context.AddCapitals.FindAsync(id);
            if (addCapital != null)
            {
                addCapital.IsDeleted = true;
                _context.AddCapitals.Update(addCapital);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<AddCapital>> GetAddCapitalByPersonConditionAsync(PersonCondition personCondition)
        {
            return await _context.AddCapitals
                .Where(a => a.personConditions == personCondition && !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<AddCapital>> GetAllAddCapitalAsync()
        {
            return await _context.AddCapitals
                .Where(a => !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<AddCapital> GetAddCapitalByIdAsync(int id)
        {
            var x = await _context.AddCapitals
                .Where(a => a.Id == id && !a.IsDeleted)
                .FirstOrDefaultAsync();
            if (x != null)
            {
                return x;
            }
            throw new Exception("Is null");
        }

        public async Task<List<AddCapital>> GetAddCapitalByUserIdAsync(int userId)
        {
            return await _context.AddCapitals
                .Where(a => a.UserId == userId && !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<AddCapital>> GetAddCapitalByCapitalIdAsync(int capitalId)
        {
            return await _context.AddCapitals
                .Where(a => a.CapitalId == capitalId && !a.IsDeleted)
                .ToListAsync();
        }


    }
}
