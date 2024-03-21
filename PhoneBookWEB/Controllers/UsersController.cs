using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBookWEB.Domain;

namespace PhoneBookWEB.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataManager _dataManager;

        public UsersController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult GetUsersList()
        {
            var users = _dataManager.Accounts.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult UserDetails(string id)
        {
            var user = _dataManager.Accounts.GetUserWithRoles(id);
            return View(user);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpGet]
        public IActionResult DeleteUser(string id)
        {
            //IdentityUser user = _userManager.FindByIdAsync(id).GetAwaiter().GetResult();
            //_userManager.DeleteAsync(user).GetAwaiter().GetResult();

            return RedirectToAction("Index");
        }
    }
}
