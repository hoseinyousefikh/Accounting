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
    public class AssetsRepository : IAssetsRepository
    {
        private readonly AppDbContext _context;

        public AssetsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAssetsAsync(Assets assets)
        {
            _context.Assets.Add(assets);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssetsAsync(Assets assets)
        {
            _context.Assets.Update(assets);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssetsAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset != null)
            {
                asset.IsDeleted = true;
                _context.Assets.Update(asset);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Assets>> GetAllAssetsAsync()
        {
            return await _context.Assets
                .Include(a => a.Users)
                .ToListAsync();
        }

        public async Task<Assets> GetAssetsByIdAsync(int id)
        {
            var x = await _context.Assets
                .Include(a => a.Users)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
            if (x != null)
            {
                return x;
            }
            throw new Exception("Is null");
        }

        public async Task<List<Assets>> GetAssetsByUserIdAsync(int userId)
        {
            return await _context.Assets
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Assets>> GetAssetsByIsPublicAsync(bool isPublic)
        {
            return await _context.Assets
                .Where(a => a.IsPublic == isPublic)
                .ToListAsync();
        }
    }
}
