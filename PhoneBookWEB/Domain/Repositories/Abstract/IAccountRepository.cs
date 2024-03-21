using Microsoft.AspNetCore.Identity;
using PhoneBookWEB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookWEB.Domain.Repositories.Abstract
{
    public interface IAccountRepository
    {
        Task<bool> CheckUserToDB(LoginModel model);

        void LogoutUser();

        Task<bool> CreateUser(RegisterModel model);

        Task<IdentityUser> GetUser(LoginModel model);

        List<string> GetRoleNames();

        Task<List<string>> GetUserRoles(LoginModel model);

        //Task<UserManager<IdentityUser>> GetUserManager();

        //Task<SignInManager<IdentityUser>> GetSignInManager();

        //Task<RoleManager<IdentityRole>> GetRoleManager();


    }
}
