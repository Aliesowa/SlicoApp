using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlicoAPI.Models
{
    public class Nominees
    {
        public int FFID { get; set; }
        public string NomineeStatus { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Relationship { get; set; }
        public string PercentageShared { get; set; }
        public DateTime RegDate { get; set; }
    }
}
