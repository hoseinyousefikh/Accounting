using App.Domain.Core.Accounting.Contract.Repositories.Users;
using App.Domain.Core.Accounting.Entities.Users;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddUser(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _appDbContext.Users.Where(u => u.IsDeleted == false || u.IsDeleted == null).ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task DeleteUser(int id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                _appDbContext.Users.Update(user);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
