using CsvHelper;
using dotNET_Trainee_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ContactContext _db;

        public ContactController(ContactContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Contacts = await _db.Contacts.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<ContactMap>();
                    var records = csvReader.GetRecords<Contact>().ToList();
                    await _db.AddRangeAsync(records);
                    await _db.SaveChangesAsync();
                }
            }
            ViewBag.Contacts = await _db.Contacts.ToListAsync();
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = await _db.Contacts
                .FirstOrDefaultAsync(item => item.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewBag.Contacts = contact;
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _db.Contacts.FindAsync(id);
            _db.Contacts.Remove(contact);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
