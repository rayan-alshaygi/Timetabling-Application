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

        private void add_division_size_Load(object sender, EventArgs e)
        {
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

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                cbRooms.Items.Add((dt2.Columns[i].ColumnName).ToString());
            }
        }
    }
}
