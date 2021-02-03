using CsvHelper;
using dotNET_Trainee_task.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Trainee_task.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            using (var streamReader = new StreamReader("Contacts.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<Contact>().ToList();
                }
            }
            return View();
        }
    }
}
