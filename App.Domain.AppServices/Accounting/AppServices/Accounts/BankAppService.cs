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
    public class BankAppService : IBankAppService
    {
        private readonly IBankService _bankService;
        public BankAppService(IBankService bankService)
        {
            _bankService = bankService;
        }
        public Task AddBankAsync(Bank bank)
        {
            return _bankService.AddBankAsync(bank);
        }

        public Task<List<Bank>> GetBankByUserIdAsync(int userId)
        {
            return _bankService.GetBankByUserIdAsync(userId);
        }
    }
}
