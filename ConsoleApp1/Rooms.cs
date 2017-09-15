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
            if (tbRoomName.Text != String.Empty && tbSeats.Text != String.Empty )
            {
                string name = tbRoomName.Text;
                int seats = int.Parse(tbSeats.Text);
                bool lab;
                if (chbLab.Checked) lab = true;
                else lab = false;
                lab = true;
                c.insertRoom(name, seats, lab);
                MessageBox.Show("Room was added successfuly");

            }
            else
                MessageBox.Show("please fill all require fields");
        }

        private void tbRoomName_TextChanged(object sender, EventArgs e)
        {
            //if (!System.Text.RegularExpressions.Regex.IsMatch(tbRoomName.Text, "^[a-zA-Z]"))
            //{
             //   MessageBox.Show("This textbox accepts only alphabetical characters");
              //  tbRoomName.Text.Remove(tbRoomName.Text.Length - 1);
            //}
        }

        

        private void Rooms_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible =false;
        }

        private void tbSeats_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                label1.Visible = true;
                label2.Visible = true;
                tbSeats.Clear();
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
            }
        }

        private void tbSeats_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
