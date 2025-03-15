using App.Domain.Core.Accounting.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.AppServices.AccountIn
{
    public interface IFromAccountAppService
    {
        Task AddFromAccountAsync(FromAccountCreateDto fromAccountCreateDto);

    }
}
