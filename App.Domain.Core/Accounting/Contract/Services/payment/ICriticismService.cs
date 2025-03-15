using App.Domain.Core.Accounting.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Services.payment
{
    public interface ICriticismService
    {
        Task AddCriticismAsync(CriticismRequestDto criticismRequest);
    }
}
