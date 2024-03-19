using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBookWEB.Domain;
using PhoneBookWEB.Domain.Entities;
using PhoneBookWEB.Models;

namespace PhoneBookWEB.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
            //if()
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (_dataManager == null)
            {
                return RedirectToAction("NoData", "NotFound");
            }
            else
            {
                List<PhoneBookRecord> records = null;
                records = _dataManager.PhoneBookRecords.GetPhoneBookRecords().GetAwaiter().GetResult();
                Role.RoleName = "Anonymus";
                return View(records);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
