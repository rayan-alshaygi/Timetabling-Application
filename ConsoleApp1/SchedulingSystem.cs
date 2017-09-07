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
    }
}
