using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Trainee_task.Models
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(item => item.Id).Ignore();
        }
        
    }
}
