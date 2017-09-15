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
    public partial class SchedulingSystem : Form
    {
        public SchedulingSystem()
        {
            InitializeComponent();
        }

        private void btAddTeacher_Click(object sender, EventArgs e)
        {
            Teacher frm = new Teacher();
            frm.ShowDialog();
        }

        private void btAddRoom_Click(object sender, EventArgs e)
        {
            Rooms frm = new Rooms();
            frm.Show();
        }

        private void btAddDivisionSize_Click(object sender, EventArgs e)
        {
            add_division_size frm = new add_division_size();
            frm.Show();
        }

        private void btMakeSchedule_Click(object sender, EventArgs e)
        {
            GenerateSheet  frm = new GenerateSheet ();
            frm.Show();
        }

        private void btAddTeacher_Click_1(object sender, EventArgs e)
        {
            Teacher frm = new Teacher();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SchedulingSystem_Load(object sender, EventArgs e)
        {

        }

        private void btSeeSchedule_Click(object sender, EventArgs e)
        {

        }

        private void btAddCourse_Click(object sender, EventArgs e)
        {

            Add_Cource frm = new Add_Cource();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Course_Class frm = new Add_Course_Class();
            frm.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
