using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneBookWEB.Domain;
using PhoneBookWEB.Domain.Entities;

namespace PhoneBookWEB.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DataManager _dataManager;
        IEnumerable<string> roleNames;

        public RegisterController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        RegisterModel _registerModel = new RegisterModel();

        [HttpGet]
        public IActionResult CreateUser()
        {
            roleNames = _dataManager.Accounts.GetRoleNames().AsEnumerable();
            _registerModel = new RegisterModel
            {
                RolesList = roleNames.Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                })
            };
            return View(_registerModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _dataManager.Accounts.CreateUser(model);
                if (result)
                {
                    return RedirectToAction("LogInIndex", "Login");
                }
                else
                {
                    return View(_registerModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(_registerModel);
            }
        }
    }
}
