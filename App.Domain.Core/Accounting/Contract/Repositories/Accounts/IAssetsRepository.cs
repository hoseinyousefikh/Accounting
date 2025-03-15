using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Accounts
{

    public interface IAssetsRepository
    {
        Task AddAssetsAsync(Assets assets);
        Task UpdateAssetsAsync(Assets assets);
        Task DeleteAssetsAsync(int id);
        Task<List<Assets>> GetAllAssetsAsync();
        Task<Assets> GetAssetsByIdAsync(int id);
        Task<List<Assets>> GetAssetsByUserIdAsync(int userId);
        Task<List<Assets>> GetAssetsByIsPublicAsync(bool isPublic);
    }
}
