using App.Domain.Core.Accounting.Contract.AppServices;
using App.Domain.Core.Accounting.Contract.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }
        public Task<SignInResult> LoginAsync(string username, string password)
        {
            return _userService.LoginAsync(username,password);
        }

        public Task<IdentityResult> RegisterUserAsync(string username, string password, string firstName, string lastName, string email)
        {
            return _userService.RegisterUserAsync(username, password, firstName, lastName, email);
        }
    }
}
