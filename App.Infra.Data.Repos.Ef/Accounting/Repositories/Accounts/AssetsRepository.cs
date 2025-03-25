using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // Add a new asset
        public async Task AddAssetsAsync(Assets assets)
        {
            if (assets == null)
                throw new ArgumentNullException(nameof(assets), "Asset cannot be null.");

            await _context.Assets.AddAsync(assets);
            await _context.SaveChangesAsync();
        }

        // Update an existing asset
        public async Task UpdateAssetsAsync(Assets assets)
        {
            if (assets == null)
                throw new ArgumentNullException(nameof(assets), "Asset cannot be null.");

            _context.Assets.Update(assets);
            await _context.SaveChangesAsync();
        }

        // Soft delete an asset by setting IsDeleted flag
        public async Task DeleteAssetsAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                throw new KeyNotFoundException($"Asset with ID {id} not found.");
            }

            asset.IsDeleted = true;
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
        }

        // Get all assets with associated users
        public async Task<List<Assets>> GetAllAssetsAsync()
        {
            return await _context.Assets
                .Include(a => a.Users)
                .Where(a => !a.IsDeleted)  // Assuming you want to exclude deleted assets
                .ToListAsync();
        }

        // Get an asset by its ID
        public async Task<Assets> GetAssetsByIdAsync(int id)
        {
            var asset = await _context.Assets
                .Include(a => a.Users)
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);  // Assuming you want to exclude deleted assets

            if (asset == null)
            {
                throw new KeyNotFoundException($"Asset with ID {id} not found.");
            }

            return asset;
        }

        // Get all assets belonging to a specific user
        public async Task<List<Assets>> GetAssetsByUserIdAsync(int userId)
        {
            return await _context.Assets
                .Where(a => a.UserId == userId && !a.IsDeleted) // Assuming you want to exclude deleted assets
                .ToListAsync();
        }

        // Get assets that are marked as public or private
        public async Task<List<Assets>> GetAssetsByIsPublicAsync(bool isPublic)
        {
            return await _context.Assets
                .Where(a => a.IsPublic == isPublic && !a.IsDeleted) // Assuming you want to exclude deleted assets
                .ToListAsync();
        }
    }
}
