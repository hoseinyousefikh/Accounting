﻿using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.AppServices.Accounts
{
    public interface IFundsAppService
    {
        Task AddFundsAsync(Funds fund);
        Task<List<Funds>> GetFundsByUserIdAsync(int userId);
    }
}
