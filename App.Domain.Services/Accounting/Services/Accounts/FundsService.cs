using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.Accounts
{
    public class FundsService : IFundsService
    {
        private readonly IFundsRepository _fundsRepository;

        public FundsService(IFundsRepository fundsRepository)
        {
            _fundsRepository = fundsRepository;
        }

        public async Task AddFundsAsync(Funds fund)
        {
            await _fundsRepository.AddFundsAsync(fund);
        }

        public async Task<List<Funds>> GetFundsByUserIdAsync(int userId)
        {
            return await _fundsRepository.GetFundsByUserIdAsync(userId);
        }
    }
}
