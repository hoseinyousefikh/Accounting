﻿using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Services.AccountIn
{
    public interface IFromAccountService
    {
        Task<int> AddFromAccountAsync(FromAccountCreateDto fromAccountCreateDto);
        Task<List<Assets>> GetAllAssetsAsync();
        Task<List<Bank>> GetAllBanksAsync();
        Task<List<Capital>> GetAllCapitalsAsync();
        Task<List<CategoryCost>> GetAllCategoryCostsAsync();
        Task<List<CategoryIncome>> GetAllCategoryIncomesAsync();
        Task<List<Debts>> GetAllDebtsAsync();
        Task<List<Funds>> GetAllFundsAsync();
        Task<List<Persons>> GetAllPersonsAsync();
        Task<List<Criticism>> GetAllCriticismsAsync();
    }
}
