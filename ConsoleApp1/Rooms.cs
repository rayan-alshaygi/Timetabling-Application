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
    public partial class Rooms : Form
    {
        FormDbData c = new FormDbData();
        public Rooms()
        {
            InitializeComponent();
        }

        private void gbAddRoom_Enter(object sender, EventArgs e)
        {

        }

        private void btAddRoomAS_Click(object sender, EventArgs e)
        {
            string name = tbRoomName.Text;
            int seats = int.Parse(tbSeats.Text);
            bool lab;
            if (chbLab.Checked) lab = true;
            else lab = false;
            lab = true;
            c.insertRoom(name, seats, lab);

        }

        private void tbSeats_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSeats_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
