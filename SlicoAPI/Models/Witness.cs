using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlicoAPI.Models
{
    public class Witness
    {
        public int FFID { get; set; }
      
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
       
        public string Address { get; set; }
        public string Telephone { get; set; }
     
        public DateTime RegDate { get; set; }
    }
}

