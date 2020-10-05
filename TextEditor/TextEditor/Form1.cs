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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set title of the OpenFileDialog 
            openFileDialog1.Title = "Open a Text File";

            //Filter the file type to open 
            openFileDialog1.Filter = "Text Files (*.txt) | *.txt | All Files(*.*) | *.*";

            // Show the dialog box
            DialogResult dr = openFileDialog1.ShowDialog();

            // Check the user response
            if (dr == DialogResult.OK)
            {
                // Set the file name
                string filename = openFileDialog1.FileName;
                MessageBox.Show("File Selected: " + filename);

                // Clear the rich text box
                richTextBox1.Clear();

                // Read the file content
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the SaveFileDialog 
            SaveFileDialog saveFile = new SaveFileDialog();

            // Set title of the OpenFileDialog 
            saveFile.Title = "Save";

            // Filter the file types  
            saveFile.Filter = "Text Files (*.txt) | *.txt | All Files(*.*) | *.*";

            // Show the dialog box
            DialogResult dr = saveFile.ShowDialog();

            // Check the user response
            if (dr == DialogResult.OK)
            {
                // Save the file content
                StreamWriter sw = new StreamWriter(saveFile.FileName);

                if (String.IsNullOrEmpty(saveFile.FileName))
                    MessageBox.Show("Please enter File Name","Warning");
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }
        private void cutCtrXToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

   

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            //// Create an instance of the FontDialog 
            //FontDialog fontDialog1 = new FontDialog();

            //// Show the dialog box
            //DialogResult dr = fontDialog1.ShowDialog();

            //// Check the user response
            //if (dr == DialogResult.OK)
            //{
                string fontName;
                FontStyle fontStyle;
                int fontSize;
            if (toolStripComboBox1.SelectedIndex > -1)
            {
                fontSize = Convert.ToInt16(toolStripComboBox1.SelectedItem.ToString());
                fontName = richTextBox1.Font.Name;
                fontStyle = richTextBox1.Font.Style;
               


                // Set the selection font
                richTextBox1.SelectionFont = new Font(fontName, fontSize, fontStyle);
            }
            
            //}
        }
    }
}
