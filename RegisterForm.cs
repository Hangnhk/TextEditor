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
    public partial class RegisterForm : Form
    {
        User newUser;
        LoginForm loginForm = new LoginForm();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        //Set Click event for Cancel Button
        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Display login form
            loginForm.Show();
            // Hide register form
            this.Hide();
        }

        //Set Click event for Submit Button
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Check Existing username
            if (Program.myUsers.CheckExistingUser(userNameTextBox.Text))
                MessageBox.Show("UserName has been chosen. Please choose a new UserName!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Check if re-entered password matches 
            else if (!reenterPassTextBox.Text.Equals(passwordTextBox.Text))
                MessageBox.Show("Password does not match. Please re-enter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Check empty fields
            else if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)) || userTypeComboBox.SelectedItem == null)
                MessageBox.Show("Empty field detected. Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // If pass all validation, Add new User to the existing User Dictionary
            else
            {
                // Create a new user object
                newUser = new User();
                newUser.UserName = userNameTextBox.Text;
                newUser.Password = passwordTextBox.Text;
                newUser.UserType = userTypeComboBox.SelectedItem.ToString();
                newUser.FirstName = firstNameTextBox.Text;
                newUser.LastName = lastNameTextBox.Text;
                newUser.DOB = dateTimePicker.Value.Date.ToString("dd-MM-yyyy");

                // Add newUser to User Dictionary and add info to "login.txt"
                Program.myUsers.addNewUser(newUser.UserName, newUser);

                // Close register form & display login form
                this.Close();
                loginForm.Show();
            }
        }

        // Display message box if existing username
        private void userNameTextBox_Leave(object sender, EventArgs e)
        {
            if (Program.myUsers.CheckExistingUser(userNameTextBox.Text))
            {
                MessageBox.Show("UserName has been chosen. Please choose a new UserName!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userNameTextBox.Focus();
            }
        }

        // Display message box if re-entered password does not match password 
        private void reenterPassTextBox_Leave(object sender, EventArgs e)
        {
            if (!reenterPassTextBox.Text.Equals(passwordTextBox.Text))
            {
                MessageBox.Show("Password does not match. Please re-enter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Focus();
            }
        }

        // Set Keydown event for all fields: Go to next field if pressing Enter or Arrow Down. Go up to previous field if pressing Arrow Up
        // Exception for datetime picker & user type combo box: only o to next field if pressing Enter
        private void userNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
            if (e.KeyCode == Keys.Up)
                SendKeys.Send("+{TAB}");
        }

        private void reenterPassTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
            if (e.KeyCode == Keys.Up)
                SendKeys.Send("+{TAB}");
        }

        private void firstNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
            if (e.KeyCode == Keys.Up)
                SendKeys.Send("+{TAB}");
        }

        private void lastNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
            if (e.KeyCode == Keys.Up)
                SendKeys.Send("+{TAB}");
        }

        private void dateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void userTypeComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }
    }
}
