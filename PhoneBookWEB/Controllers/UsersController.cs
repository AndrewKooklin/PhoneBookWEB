using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneBookWEB.Domain;

namespace PhoneBookWEB.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataManager _dataManager;
        IEnumerable<string> roleNames;

        public UsersController(DataManager dataManager)
        {
            _dataManager = dataManager;
            roleNames = _dataManager.Accounts.GetRoleNames().AsEnumerable();
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
            user.RolesList = roleNames.Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
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

        [HttpGet]
        public IActionResult AddRoleToUser(string userId, string role)
        {
            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteRoleUser(string userId, string role)
        {
            //IdentityUser user = _userManager.FindByIdAsync(id).GetAwaiter().GetResult();
            //_userManager.DeleteAsync(user).GetAwaiter().GetResult();

            return RedirectToAction("Index");
        }
    }
}
