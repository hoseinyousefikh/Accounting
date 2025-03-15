using App.Domain.Core.Accounting.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Users
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task DeleteUser(int id);
    }
}
