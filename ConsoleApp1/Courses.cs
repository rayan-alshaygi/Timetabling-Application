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
    public partial class courses : Form
    {
        public courses()
        {
            InitializeComponent();
        }
        FormDbData c = new FormDbData();
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbNumberOfLevels.SelectedItem.ToString() == "1")
            {
                gbOneLevel.Visible = true;
                gbTowLevels.Visible = false;
            }
            if (cbNumberOfLevels.SelectedItem.ToString() == "2")
            {
                gbTowLevels.Visible = true;
                gbOneLevel.Visible = false;

            }
        }
        private void courses_Load(object sender, EventArgs e)
        {
            gbOneLevel.Visible = false;
            gbTowLevels.Visible = false;
            cbNumberOfLevels.Items.Add("1");
            cbNumberOfLevels.Items.Add("2");
            for (int i = 1; i <= 5; i++)
            {
                cbYears.Items.Add(i);
                cbyears1.Items.Add(i);
                cbyears2.Items.Add(i);
            }
            DataTable dt = c.comboDivision();
            clbDivisions.CheckOnClick = true;
            clbDivisions1.CheckOnClick = true;
            clbDivisions1.CheckOnClick = true;

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                clbDivisions.Items.Add((dt.Columns[i].ColumnName).ToString());
                clbDivisions1.Items.Add((dt.Columns[i].ColumnName).ToString());
                clbDivisions1.Items.Add((dt.Columns[i].ColumnName).ToString());
            }
        }

        private void btAddLevelAS_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            int y = int.Parse(cbYears.SelectedItem.ToString());
            string[] dv = new string[6];
            clbDivisions.CheckedItems.CopyTo(dv, 0);
            //.SelectedItems.CopyTo(dv, 0);

            c.InsertCourse(name, y, dv);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = tbName.Text;
            int y1 = int.Parse(cbyears1.SelectedItem.ToString());
            string[] dv1 = new string[6];
            clbDivisions1.SelectedItems.CopyTo(dv1, 0);
            int y2 = int.Parse(cbyears2.SelectedItem.ToString());
            string[] dv2 = new string[6];
            clbDivisions2.SelectedItems.CopyTo(dv2, 0);

            c.InsertCourse(name, y1, dv1, y2, dv2);
        }

        private void clbDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btAddCourseAS_Click(object sender, EventArgs e)
        {

        }
    }
}
