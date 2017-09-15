using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public partial class Teacher : Form
    {
        FormDbData c = new FormDbData();
        public Teacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool TA = false;
            if (checkBox1.Checked == true)
                TA = true;
            string InstructorName = textBox1.Text;
            if (InstructorName != string.Empty)
            {
                int val = c.InsertInstructor(InstructorName, TA);
                if (val > 0)
                {
                textBox1.Text = "";
                }
            }
            else
                MessageBox.Show("please fill name of instructor");
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z]"))
            {
         
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Clear();
            }
            else
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
        
    }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }
    }
}
