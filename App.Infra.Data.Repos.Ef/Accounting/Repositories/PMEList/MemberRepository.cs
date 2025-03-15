using App.Domain.Core.Accounting.Contract.Repositories.PMEList;
using App.Domain.Core.Accounting.Entities.PMEList;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.PMEList
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddMember(Member memberEntity)
        {
            await _context.Members.AddAsync(memberEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMember(Member memberEntity)
        {
            _context.Members.Update(memberEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMember(int id)
        {
            var memberEntity = await _context.Members.FindAsync(id);
            if (memberEntity != null)
            {
                memberEntity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Member> GetMemberById(int id)
        {
            var x = await _context.Members
                 .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }

        public async Task<List<Member>> GetMembersByUserId(int userId)
        {
            return await _context.Members
                .Where(m => m.UserId == userId && !m.IsDeleted)
                .ToListAsync();
        }
    }
}
