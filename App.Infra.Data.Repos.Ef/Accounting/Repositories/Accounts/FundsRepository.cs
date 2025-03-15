using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts
{
    public class FundsRepository : IFundsRepository
    {
        private readonly List<Funds> _funds;

        public FundsRepository()
        {
            _funds = new List<Funds>();
        }

        public async Task AddFundsAsync(Funds fund)
        {
            await Task.Run(() => _funds.Add(fund));
        }

        public async Task UpdateFundsAsync(Funds fund)
        {
            await Task.Run(() =>
            {
                var existingFund = _funds.FirstOrDefault(f => f.Id == fund.Id);
                if (existingFund != null)
                {
                    existingFund.Name = fund.Name;
                    existingFund.IsPublic = fund.IsPublic;
                    existingFund.FundOperations = fund.FundOperations;
                    existingFund.UserId = fund.UserId;
                    existingFund.Users = fund.Users;
                }
            });
        }

        public async Task DeleteFundsAsync(int id)
        {
            await Task.Run(() =>
            {
                var fund = _funds.FirstOrDefault(f => f.Id == id);
                if (fund != null)
                {
                    fund.IsDeleted = true;
                }
            });
        }

        public async Task<Funds> GetFundsByIdAsync(int id)
        {
            var x = await Task.Run(() => _funds.FirstOrDefault(f => f.Id == id && !f.IsDeleted));
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }

        public async Task<List<Funds>> GetFundsByUserIdAsync(int userId)
        {
            return await Task.Run(() => _funds.Where(f => f.UserId == userId && !f.IsDeleted).ToList());
        }

        public async Task<List<Funds>> GetFundsByFundOperationsAsync()
        {
            return await Task.Run(() => _funds.Where(f => f.FundOperations == FundOperations.invoice && !f.IsDeleted).ToList());
        }
    }
}
