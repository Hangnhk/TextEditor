using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class EditorForm : Form
    {
        // Declare variables
        private string userName;
        private bool save = false;
        private string currentFile = "";
        private SaveFileDialog saveFile;
        LoginForm loginForm = new LoginForm();

        public EditorForm(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            if (!Program.myUsers.isUserTypeEdit(userName))
            {
                richTextBox1.ReadOnly = true;
            }
            else richTextBox1.ReadOnly = false;
            welcomeTextbox.Text += userName;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            save = false;
        }

        //_____________________________________________________________
        // HORIZONTAL TOOLSTRIP
        //_____________________________________________________________
        // HORIZONTAL TOOLSTRIP: NEW BUTTON
        private void newButton_Click(object sender, EventArgs e)
        {
            // if rich text box is not empty, show Message box
            if (richTextBox1.Text != "")
            {
                DialogResult dr = MessageBox.Show("Changes were not saved. Are you sure you want to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                // If user input is OK, reset variables 
                if (dr == DialogResult.OK)
                {
                    richTextBox1.Clear();
                    this.Text = "Text Editor Window";
                    currentFile = "";
                }
            }
            else
            {
                // Reset variables
                this.Text = "Text Editor Window";
                currentFile = "";

            }
        }

        // HORIZONTAL TOOLSTRIP: OPEN BUTTON
        private void openButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set title of the OpenFileDialog 
            openFileDialog1.Title = "Open a Text File";

            //Filter the file type to open 
            openFileDialog1.Filter = "Rich Text Format(*.rtf)|*.rtf|Plain Text(*.txt)|*.txt";

            // Show the dialog box
            DialogResult dr = openFileDialog1.ShowDialog();

            // Check the user response
            if (dr == DialogResult.OK)
            {
                // Set the file name
                currentFile = openFileDialog1.FileName;

                // Open file in plain text format if .txt extension. Else, open in rich text format
                if (Path.GetExtension(currentFile) == ".txt")
                    richTextBox1.LoadFile(currentFile, RichTextBoxStreamType.PlainText);
                else richTextBox1.LoadFile(currentFile);

                // Change the text of Editor Form
                this.Text = Path.GetFileName(currentFile) + " - Text Editor";
            }
        }

        // HORIZONTAL TOOLSTRIP: SAVE BUTTON
        private void saveButton_Click(object sender, EventArgs e)
        {
            save = true;
            // If current file path is empty, perform Save As
            if (currentFile == "")
                saveAsButton.PerformClick();

            // Else, save content to current file
            else
            {
                richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.RichText);
                this.Text = Path.GetFileName(currentFile) + " - Text Editor";
            }
        }

        // HORIZONTAL TOOLSTRIP: SAVE AS BUTTON
        private void saveAsButton_Click(object sender, EventArgs e)
        {
            // Change save variable to true
            save = true;
            
            // Create an instance of the SaveFileDialog 
            saveFile = new SaveFileDialog();

            // Set title of the OpenFileDialog 
            saveFile.Title = "Save As";

            // Filter the file types  
            saveFile.Filter = "Rich Text Format(*.rtf)|*.rtf";
            saveFile.FileName = "Untitled";
            // Show the dialog box
            DialogResult dr = saveFile.ShowDialog();

            // If user response = OK
            if (dr == DialogResult.OK)
            {
                // Save the file content
                currentFile = saveFile.FileName;
                richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.RichText);

                // Change the text of Editor Form
                this.Text = Path.GetFileName(currentFile) + " - Text Editor";
            }
        }

        // HORIZONTAL TOOLSTRIP: BOLD BUTTON
        private void boldButton_Click(object sender, EventArgs e)
        {
            FontStyle currentFontStyle = richTextBox1.SelectionFont.Style;

            // Check if the current font style is Bold 
            // If yes, undo Bold for the selected text & set the back color of the Bold button to default
            if ((currentFontStyle & FontStyle.Bold) != 0)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, currentFontStyle & ~FontStyle.Bold);

            // If not, add Bold to the current font style & set the back color of the Bold button to DarkGray
            else
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, currentFontStyle | FontStyle.Bold);
        }

        // HORIZONTAL TOOLSTRIP: ITALIC BUTTON
        private void italicButton_Click(object sender, EventArgs e)
        {
            FontStyle currentFontStyle = richTextBox1.SelectionFont.Style;

            // Check if the current font style is Italic 
            // If yes, undo Italic for the selected text & set the back color of the Italic button to default
            if ((currentFontStyle & FontStyle.Italic) != 0)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, currentFontStyle & ~FontStyle.Italic);

            // If not, add Italic to the current font style & set the back color of the Italic button to DarkGray
            else
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, currentFontStyle | FontStyle.Italic);
        }

        // HORIZONTAL TOOLSTRIP: UNDERLINE BUTTON
        private void underlineButton_Click(object sender, EventArgs e)
        {
            FontStyle currentFontStyle = richTextBox1.SelectionFont.Style;

            // Check if the current font style is Underline
            // If yes, undo Underline for the selected text & set the back color of the Underline button to default
            if ((currentFontStyle & FontStyle.Underline) != 0)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, currentFontStyle & ~FontStyle.Underline);

            // If not, add Underline to the current font style & set the back color of the Underline button to DarkGray
            else
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, currentFontStyle | FontStyle.Underline);
        }

        //HORIZONTAL TOOLSTRIP: COMBO BOX FOR FONT SIZE
        private void fontComboBox_DropDownClosed(object sender, EventArgs e)
        {
            int fontSize = int.Parse(fontComboBox.SelectedItem.ToString());
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, fontSize, richTextBox1.SelectionFont.Style);
        }

        // HORIZONTAL TOOLSTRIP: HELP BUTTON
        private void helpButton_Click(object sender, EventArgs e)
        {
            aboutMenuItem.PerformClick();
        }

        //_____________________________________________________________
        // VERTICAL TOOLSTRIP
        //_____________________________________________________________
        // VERTICAL TOOLSTRIP: CUT BUTTON 
        private void cutButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        // VERTICAL TOOLSTRIP: COPY BUTTON 
        private void copyButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        // VERTICAL TOOLSTRIP: PASTE BUTTON 
        private void pasteButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        //_____________________________________________________________
        // MENU ITEMS
        //_____________________________________________________________
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            newButton.PerformClick();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            openButton.PerformClick();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            saveButton.PerformClick();
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            saveAsButton.PerformClick();
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            cutButton.PerformClick();
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            copyButton.PerformClick();
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            pasteButton.PerformClick();
        }

        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if file has been saved. If no, show Message box. If yes, return to Login Form
            if (save == false)
            {
                DialogResult dr = MessageBox.Show("Changes were not saved. Are you sure you want to exit?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else loginForm.Show();
            }
            else loginForm.Show();
        }
    }
}
