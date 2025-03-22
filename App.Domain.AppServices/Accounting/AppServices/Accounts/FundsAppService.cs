using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.Accounts
{
    public class FundsAppService : IFundsAppService
    {
        private readonly IFundsService _fundsService;

        public FundsAppService(IFundsService fundsService)
        {
            _fundsService = fundsService;
        }

        public Task AddFundsAsync(Funds fund)
        {
            return _fundsService.AddFundsAsync(fund);
        }

        public Task<List<Funds>> GetFundsByUserIdAsync(int userId)
        {
            return _fundsService.GetFundsByUserIdAsync(userId);
        }
    }
}
