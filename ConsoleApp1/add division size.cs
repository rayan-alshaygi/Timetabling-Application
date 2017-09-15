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
    public partial class add_division_size : Form
    {
        FormDbData c = new FormDbData();
        public add_division_size()
        {
            InitializeComponent();
        }

        private void btAddDivisioSizeAD_Click(object sender, EventArgs e)
        {
            if (tbDivisionSize.Text != String.Empty && cbDivision1.SelectedItem.ToString() != String.Empty && cbYear1.SelectedItem.ToString() != String.Empty && cbRooms.SelectedValue.ToString() != String.Empty)
            {
                int size = Int32.Parse(tbDivisionSize.Text);
                string dvname = cbDivision1.SelectedItem.ToString();
                int year = Int32.Parse(cbYear1.SelectedItem.ToString());
                string labroom = cbRooms.SelectedValue.ToString();

                DataTable dt = c.combolab();
                int roomsize = 0;
                int roomid = 0;
                for (int i = 0; i <= dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].Field<bool>(1).ToString() == labroom)
                    {
                        roomsize = int.Parse(dt.Rows[i].Field<int>(2).ToString());
                        roomid = int.Parse(dt.Rows[i].Field<int>(0).ToString());
                    }
                }
                int groups = c.sectioning(roomsize, size);
                int x = c.insertdivisionsize(dvname, year, size, roomid, groups);
                if (x > 0)
                {
                    tbDivisionSize.Text = "";
                    cbDivision1.Text = "";
                    cbYear1.Text = "";
                }
            }
            else
                MessageBox.Show("please fill all require fields");
        }

        private void add_division_size_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            tbDivisionSize.Clear();
            cbDivision1.Items.Clear();
            cbYear1.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                cbYear1.Items.Add(i);
            }
            DataTable dt = c.comboDivision();

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                cbDivision1.Items.Add((dt.Columns[i].ColumnName).ToString());
            }
            DataTable dt2 = c.combolab();

            for (int i = 1; i < dt2.Rows.Count; i++)
            {
                cbRooms.Items.Add((dt2.Rows[i].Field<string>(1)).ToString());
            }
        }

        private void tbDivisionSize_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                label4.Visible = true;
                label5.Visible = true;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
            }
        }

        private void tbDivisionSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDivisionSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                label4.Visible = true;
                label5.Visible = true;
                tbDivisionSize.Clear();
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        //private void tbDivisionSize_KeyPress(object sender, KeyPressEventArgs e)
        // {
        //    if (!Char.IsDigit(e.KeyChar))
        //        MessageBox.Show("please enter digits only");
        //}
    }
}
