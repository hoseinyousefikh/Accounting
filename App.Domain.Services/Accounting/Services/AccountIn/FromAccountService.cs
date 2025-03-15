using App.Domain.Core.Accounting.Contract.Repositories.AccountIn;
using App.Domain.Core.Accounting.Contract.Services.AccountIn;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.AccountIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.AccountIn
{
    public class FromAccountService : IFromAccountService
    {

        private readonly IFromAccountRepository _fromAccountRepository;

        public FromAccountService(IFromAccountRepository fromAccountRepository)
        {
            _fromAccountRepository = fromAccountRepository;
        }
        public async Task AddFromAccountAsync(FromAccountCreateDto fromAccountCreateDto)
        {
            var fromAccount = new FromAccount
            {
                AssetsId = fromAccountCreateDto.AssetsId,
                BankId = fromAccountCreateDto.BankId,
                CapitalId = fromAccountCreateDto.CapitalId,
                CategoryCostId = fromAccountCreateDto.CategoryCostId,
                CategoryIncomeId = fromAccountCreateDto.CategoryIncomeId,
                DebtsId = fromAccountCreateDto.DebtsId,
                FundsId = fromAccountCreateDto.FundsId,
                PersonsId = fromAccountCreateDto.PersonsId,
                CriticismId = fromAccountCreateDto.CriticismId
            };

            await _fromAccountRepository.AddFromAccountAsync(fromAccount);
        }
    }
}
