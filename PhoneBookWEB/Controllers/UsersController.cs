﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBookWEB.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult UsersList()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpGet]
        public IActionResult DeleteUser(string id)
        {
            IdentityUser user = _userManager.FindByIdAsync(id).GetAwaiter().GetResult();
            _userManager.DeleteAsync(user).GetAwaiter().GetResult();

            return RedirectToAction("Index");
        }
    }
}
