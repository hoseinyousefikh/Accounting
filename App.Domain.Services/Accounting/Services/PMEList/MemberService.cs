using App.Domain.Core.Accounting.Contract.AppServices.PMEList;
using App.Domain.Core.Accounting.Contract.Repositories.PMEList;
using App.Domain.Core.Accounting.Contract.Services.PMEList;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.PMEList;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.PMEList
{
    public class MemberService : IMemberService
    {
       
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task AddMemberAsync(MemberDto memberDto)
        {
            var memberEntity = new Member
            {
                Name = memberDto.Name,
                Description = memberDto.Description,
                UserId = memberDto.UserId,
                IsDeleted = false
            };

            await _memberRepository.AddMember(memberEntity);
        }
        public async Task<List<MemberDto>> GetMembersByUserIdAsync(int userId)
        {
            var members = await _memberRepository.GetMembersByUserId(userId);
            return members.Select(m => new MemberDto
            {
                Id =m.Id,
                Name = m.Name,
                Description = m.Description,
                UserId = m.UserId
            }).ToList();
        }
    }

   
}
