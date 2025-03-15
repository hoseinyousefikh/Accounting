using App.Domain.Core.Accounting.Entities.PMEList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.PMEList
{
    public interface IMemberRepository
    {
        Task AddMember(Member memberEntity);
        Task UpdateMember(Member memberEntity);
        Task DeleteMember(int id);
        Task<Member> GetMemberById(int id);
        Task<List<Member>> GetMembersByUserId(int userId);
    }
}
