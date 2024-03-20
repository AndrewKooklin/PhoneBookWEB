using Microsoft.AspNetCore.Mvc;
using PhoneBookWEB.Domain;
using PhoneBookWEB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookWEB.Controllers
{
    public class CreateRecordController : Controller
    {
        private readonly DataManager _dataManager;

        public CreateRecordController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult CreateRecord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRecord(PhoneBookRecord model)
        {
            if (ModelState.IsValid)
            {
                _dataManager.PhoneBookRecords.SavePhoneBookRecord(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
