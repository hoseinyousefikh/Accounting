using App.Domain.Core.Accounting.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.AppServices.PMEList
{
    public interface IMemberAppService
    {
        Task AddMemberAsync(MemberDto memberDto);
        Task<List<MemberDto>> GetMembersByUserIdAsync(int userId);
    }
}
