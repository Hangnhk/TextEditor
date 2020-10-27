using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        // Create an instance of the User Dictionary
        public static UserDict myUsers = new UserDict();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load the text file to the Dictionary
            myUsers.LoadUsers("login.txt");
            Application.Run(new LoginForm());
        }
    }
}
