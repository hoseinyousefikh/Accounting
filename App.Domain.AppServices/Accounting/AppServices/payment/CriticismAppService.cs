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
    public class CriticismAppService : ICriticismAppService
    {
        private readonly ICriticismService _criticismService;
        public CriticismAppService(ICriticismService criticismService)
        {
            _criticismService = criticismService;
        }
        public Task AddCriticismAsync(CriticismRequestDto criticismRequest)
        {
            return _criticismService.AddCriticismAsync(criticismRequest);
        }
    }
}
