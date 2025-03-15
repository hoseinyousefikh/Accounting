using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.AppServices
{
    public interface IUserAppService
    {
        Task<SignInResult> LoginAsync(string username, string password);
        Task<IdentityResult> RegisterUserAsync(string username, string password, string firstName, string lastName, string email);
    }
}
