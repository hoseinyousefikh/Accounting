using App.Domain.Core.Accounting.Contract.AppServices.PMEList;
using App.Domain.Core.Accounting.Contract.Repositories.PMEList;
using App.Domain.Core.Accounting.Contract.Services.PMEList;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.PMEList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.PMEList
{
    public class MemberAppService : IMemberAppService
    {
        private readonly IMemberService _memberService;
        public MemberAppService(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public Task AddMemberAsync(MemberDto memberDto)
        {
            return _memberService.AddMemberAsync(memberDto);
        }

        public Task<List<MemberDto>> GetMembersByUserIdAsync(int userId)
        {
            return _memberService.GetMembersByUserIdAsync(userId);
        }
    }
}
