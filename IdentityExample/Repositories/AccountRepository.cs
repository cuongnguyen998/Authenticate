using Microsoft.AspNetCore.Identity;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace IdentityExample.Repositories
{
    public class AccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailService _emailService;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public async Task<bool> IsUserExist(string userId=null, string username=null)
        {
            IdentityUser user = new IdentityUser();
            if (!string.IsNullOrEmpty(username))
                user = await _userManager.FindByNameAsync(username);
            else if (!string.IsNullOrEmpty(userId))
                user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
