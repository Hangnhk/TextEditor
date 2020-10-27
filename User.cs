using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    class User 
    {
        // Accessors
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }

        // Convert information in a single line from the login.txt file to a User object
        public void LoadUser(string fileLine)
        {
            // Split the comma seperated string into fields 
            string[] fields = fileLine.Split(',');

            // Assign values to respective properties
            UserName = fields[0];
            Password = fields[1];
            UserType = fields[2];
            FirstName = fields[3];
            LastName = fields[4];
            DOB = fields[5];
        }
    }
}
