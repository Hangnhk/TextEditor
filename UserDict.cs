using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    class UserDict
    {
        // Create a Dictionary to store the information from login.txt file
        private Dictionary <string, User> users;

        // UserDict constructor
        public UserDict()
        {
            // Create an instance of Dictionary
            users = new Dictionary <string, User> ();
        }

        // Method to get all users 
        public void LoadUsers(string filename)
        {
            // Read the file content using the StreamReader
            StreamReader fileContent = new StreamReader(filename);
            
            // Read the StremReader till the last line
            while (!fileContent.EndOfStream)
            {
                // Create an object of User class
                User user = new User();
                // Read each line and from the StreamReader
                string line = fileContent.ReadLine();
                // Load the user detail from file to respective fields
                user.LoadUser(line);
                // Add the detall to the Dictionary collection
                users.Add(user.UserName, user);
            }
            // Close the StreamReader
            fileContent.Close();
        }

        // Method to check existing user
        public bool CheckExistingUser(string userName)
        {
            if (users.ContainsKey(userName))
                return true;
            return false;
        }

        // Method to add new user
        public void addNewUser(string key, User value)
        {
            // Add new user to users Dictionary
            users.Add(key, value);

            // Add info of new user to login.txt
            using (StreamWriter sw = File.AppendText("login.txt"))
            {
                string newfileContent = value.UserName + "," + value.Password + "," + value.UserType + "," +
                                        value.FirstName + "," + value.LastName + "," + value.DOB;
                sw.WriteLine(newfileContent);
            }
        }

        // Method to check login credentials
        public bool checkLogInCredentials(string userName, string password)
        {

            // Check if user exists
            if (CheckExistingUser(userName))
            {
                // Find the user with the matching password using Lambda
                var matchedUser = users.Where(x => x.Key.Equals(userName) && x.Value.Password.Equals(password));

                // Return true if there is a user with matching password. Else, return false
                if (matchedUser.Any())
                    return true;
                return false;
            }
            return false;
        }

        // Method to check if user type is edit or not
        public bool isUserTypeEdit(string username)
        {
            var matchedUser = users.FirstOrDefault(x => x.Key == username);
            if (matchedUser.Value.UserType.Equals("Edit"))
                return true;
            return false;
        }
    }

}
