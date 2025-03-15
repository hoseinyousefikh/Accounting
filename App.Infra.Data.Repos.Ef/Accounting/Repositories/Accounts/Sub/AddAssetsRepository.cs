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
    public class AddAssetsRepository : IAddAssetsRepository
    {
        private readonly AppDbContext _context;

        public AddAssetsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAddAssetsAsync(AddAssets addAssets)
        {
            _context.AddAssets.Add(addAssets);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddAssetsAsync(AddAssets addAssets)
        {
            _context.AddAssets.Update(addAssets);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddAssetsAsync(int id)
        {
            var addAssets = await _context.AddAssets.FindAsync(id);
            if (addAssets != null)
            {
                addAssets.IsDeleted = true;
                _context.AddAssets.Update(addAssets);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<AddAssets>> GetAddAssetsByPersonConditionAsync(PersonCondition personCondition)
        {
            return await _context.AddAssets
                .Where(a => a.personConditions == personCondition && !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<AddAssets>> GetAllAddAssetsAsync()
        {
            return await _context.AddAssets
                .Where(a => !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<AddAssets> GetAddAssetsByIdAsync(int id)
        {
            var x = await _context.AddAssets
                .Where(a => a.Id == id && !a.IsDeleted)
                .FirstOrDefaultAsync();
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }

        public async Task<List<AddAssets>> GetAddAssetsByUserIdAsync(int userId)
        {
            return await _context.AddAssets
                .Where(a => a.UserId == userId && !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<AddAssets>> GetAddAssetsByAssetsIdAsync(int assetsId)
        {
            return await _context.AddAssets
                .Where(a => a.AssetsId == assetsId && !a.IsDeleted)
                .ToListAsync();
        }
    }
}
