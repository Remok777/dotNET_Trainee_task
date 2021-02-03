using dotNET_Trainee_task.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Trainee_task.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactContext _db;

        public ContactController(ContactContext context)
        {
            _db = context;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
