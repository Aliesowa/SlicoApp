using System;
using System.Collections.Generic;
using System.Text;

namespace Slico.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public Users()
        {

        }

        public Users(string Username)
        {
            this.Username = Username;
        }

       public bool CheckInformation()
        {
            if (!Username.Equals(""))
            {
                return true;
            }
            else

            return false; 
        }
    }
}
