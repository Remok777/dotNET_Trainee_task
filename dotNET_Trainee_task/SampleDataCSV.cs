using CsvHelper;
using dotNET_Trainee_task.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Trainee_task
{
    public class SampleDataCSV
    {
        public async static void Initialize(ContactContext context)
        {
            List<Contact> contacts = new List<Contact>();

            if(context.Contacts.Any())
            {
                return;
            }
            using (var streamReader = new StreamReader("Contacts.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    contacts.AddRange(csvReader.GetRecords<Contact>().ToList());
                }
            }
            await context.Contacts.AddRangeAsync(contacts);
            await context.SaveChangesAsync();
        }
    }
}
