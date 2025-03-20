using App.Domain.Core.Accounting.Contract.AppServices.payment;
using App.Domain.Core.Accounting.Contract.Services.payment;
using App.Domain.Core.Accounting.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.payment
{
    public class CheckAppService : ICheckAppService
    {
        private readonly ICheckService _checkService;

        public CheckAppService(ICheckService checkService)
        {
            _checkService = checkService;
        }

        public Task AddCheckAsync(CheckDto checkDto)
        {
            return _checkService.AddCheckAsync(checkDto);
        }
    }
}
