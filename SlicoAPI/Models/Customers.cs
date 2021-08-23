using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SlicoAPI.Models
{
    public class Customers
    {
     
        public string IDCode { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string DOB { get; set; }

        public string BusinessLocation { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Telephone { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      
        public string RegDate { get; set; }
        public Customers()
        {
            RegDate = DateTime.UtcNow.ToShortDateString();
        }

        public string Username { get; set; }
        public string Photo { get; set; }

    }
}
