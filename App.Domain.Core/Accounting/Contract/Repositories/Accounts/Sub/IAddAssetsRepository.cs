using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub
{
    public interface IAddAssetsRepository
    {
        Task AddAddAssetsAsync(AddAssets addAssets);
        Task UpdateAddAssetsAsync(AddAssets addAssets);
        Task DeleteAddAssetsAsync(int id);
        Task<List<AddAssets>> GetAddAssetsByPersonConditionAsync(PersonCondition personCondition);
        Task<List<AddAssets>> GetAllAddAssetsAsync();
        Task<AddAssets> GetAddAssetsByIdAsync(int id);
        Task<List<AddAssets>> GetAddAssetsByUserIdAsync(int userId);
        Task<List<AddAssets>> GetAddAssetsByAssetsIdAsync(int assetsId);
    }
}
