using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        //Set Click event for Login Button
        private void loginButton_Click(object sender, EventArgs e)
        {
            // Check user login credentials
            if (Program.myUsers.checkLogInCredentials(userNameTextBox.Text.Trim(), passwordTextBox.Text.Trim()))
            {
                // If correct, hide Login Form & display Editor Form
                this.Hide();
                EditorForm editorForm = new EditorForm(userNameTextBox.Text.Trim());
                editorForm.Show();
            }
            // If incorrect, display Warning Message Box
            else
            {
                MessageBox.Show("Incorrect Login Info. Please try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userNameTextBox.Focus();
            }
        }

        //Set Click event for Exit Button
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Set Click event for New User Button
        private void newUserButton_Click(object sender, EventArgs e)
        {
            // Create & display register form
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            // Hide login form
            this.Hide();
        }

        // Set Keydown event: Go to next field if pressing Enter or Arrow Down 
        private void userNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
        }

        // Set Keydown event: Go to login button if pressing Enter. Go up if pressing Arrow Up
        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
            if (e.KeyCode == Keys.Up)
                SendKeys.Send("+{TAB}");
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
