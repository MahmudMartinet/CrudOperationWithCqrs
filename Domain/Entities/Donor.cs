using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Donor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }

        //public Donor(string firstName, string lastName, string email, string passWord)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Email = email;
        //    Password = passWord;
        //}
    }

   
}
