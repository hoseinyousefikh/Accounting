using App.Domain.Core.Accounting.Contract.AppServices.AccountIn;
using App.Domain.Core.Accounting.Contract.Services.AccountIn;
using App.Domain.Core.Accounting.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.AccountIn
{
    public class FromAccountAppService : IFromAccountAppService
    {
        private readonly IFromAccountService _fromAccountService;
        public FromAccountAppService(IFromAccountService fromAccountService)
        {
            _fromAccountService = fromAccountService;
        }
        public Task AddFromAccountAsync(FromAccountCreateDto fromAccountCreateDto)
        {
            return _fromAccountService.AddFromAccountAsync(fromAccountCreateDto);
        }
    }
}
