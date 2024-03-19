﻿using Microsoft.AspNetCore.Identity;
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

        Task<List<string>> GetRoles(IdentityUser user);

        //Task<UserWithRolesModel> GetUserWithRoles(LoginModel model);

        Task<UserManager<IdentityUser>> GetUserManager();

        Task<SignInManager<IdentityUser>> GetSignInManager();

        Task<RoleManager<IdentityRole>> GetRoleManager();


    }
}
