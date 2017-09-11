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
            int val = c.InsertInstructor(InstructorName, TA);
            if (val > 0)
            {
                textBox1.Text = "";
            }
        }
    }
}
