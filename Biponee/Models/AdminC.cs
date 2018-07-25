using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models
{
    public class AdminC
    {
        public int ID { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public AdminC(int iD, String email, String password, String firstName, String lastName)
        {
            ID = iD;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        public AdminC(String email, String password, String firstName, String lastName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        public AdminC()
        {
        }
    }
}