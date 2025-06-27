using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
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
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task AddBankAsync(Bank bank)
        {
            await _bankRepository.AddBankAsync(bank);
        }

        public async Task<List<Bank>> GetBankByUserIdAsync(int userId)
        {
            return await _bankRepository.GetBankByUserIdAsync(userId);
        }
        public async Task<Bank> GetBankByIdAsync(int id)
        {
            var bank = await _bankRepository.GetBankByIdAsync(id);
            return bank;
        }
        public async Task UpdateBankAsync(Bank bank)
        {
            if (bank == null)
                throw new ArgumentNullException(nameof(bank), "Bank cannot be null.");

            await _bankRepository.UpdateBankAsync(bank);
        }
        public async Task<bool> DeleteBankAsync(int id, int userId)
        {
            var bank = await _bankRepository.GetBankByIdAsync(id);

            if (bank == null || bank.UserId != userId || bank.IsDeleted)
            {
                return false; 
            }

            bank.IsDeleted = true;
            await _bankRepository.UpdateBankAsync(bank);

            return true;
        }


    }
}
