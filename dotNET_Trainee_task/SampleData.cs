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
    public class SampleData
    {
        public async static void Initialize(ContactContext context)
        {
            

            if(context.Contacts.Any())
            {
                return;
            }
            await context.Contacts.AddAsync(
                    new Contact
                    {
                        Name = "John",
                        DateOfBirth = DateTime.Now,
                        Maried = true,
                        Phone = "380665747859",
                        Salary = 500
                    }
                );
            context.SaveChanges();
        }
    }
}
