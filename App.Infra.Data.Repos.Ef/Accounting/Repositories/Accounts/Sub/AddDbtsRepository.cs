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
    public class AddDbtsRepository : IAddDbtsRepository
    {
        private readonly AppDbContext _context;

        public AddDbtsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAddDbtsAsync(AddDbts addDbts)
        {
            _context.AddDbts.Add(addDbts);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddDbtsAsync(AddDbts addDbts)
        {
            _context.AddDbts.Update(addDbts);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddDbtsAsync(int id)
        {
            var addDbt = await _context.AddDbts.FindAsync(id);
            if (addDbt != null)
            {
                addDbt.IsDeleted = true;
                _context.AddDbts.Update(addDbt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<AddDbts>> GetAddDbtsByPersonConditionAsync(PersonCondition personCondition)
        {
            return await _context.AddDbts
                .Where(a => a.personConditions == personCondition && !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<AddDbts>> GetAllAddDbtsAsync()
        {
            return await _context.AddDbts
                .Where(a => !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<AddDbts> GetAddDbtsByIdAsync(int id)
        {
            return await _context.AddDbts
                .Where(a => a.Id == id && !a.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<List<AddDbts>> GetAddDbtsByUserIdAsync(int userId)
        {
            return await _context.AddDbts
                .Where(a => a.UserId == userId && !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<AddDbts>> GetAddDbtsByDebtsIdAsync(int debtsId)
        {
            return await _context.AddDbts
                .Where(a => a.DebtsId == debtsId && !a.IsDeleted)
                .ToListAsync();
        }


    }
}
