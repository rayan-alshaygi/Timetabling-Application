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
    public partial class Add_Cource : Form
    {
        FormDbData c = new FormDbData();
        int cid;
        public Add_Cource()
        {
            InitializeComponent();
        }

        private void btAddLevel_Click(object sender, EventArgs e)
        {

            if (cbNumberOfLevels.SelectedItem.ToString() == "1")
            {
                gbOneLevel.Visible = true;
                gbTwoLevels.Visible = false;
            }
            if (cbNumberOfLevels.SelectedItem.ToString() == "2")
            {
                gbTwoLevels.Visible = true;
                gbOneLevel.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            int y1 = int.Parse(cbyears1.SelectedItem.ToString());
            string[] dv1 = new string[6];
            clbDivisions1.CheckedItems.CopyTo(dv1, 0);
            int y2 = int.Parse(cbyears2.SelectedItem.ToString());
            string[] dv2 = new string[6];
            clbDivisions2.CheckedItems.CopyTo(dv2, 0);
            string codeArabic = tbCourseCodeArabic.Text;
            string codeEnglish = tbCourseCodeEnglish.Text;
            cid = c.InsertCourse(name, codeArabic, codeEnglish, y1, dv1, y2, dv2);
            MessageBox.Show(" COURSE INSERTION WORKED click on course class details button to enter class details");
            button1.Visible = true;
        }

        private void btAddLevelAS_Click(object sender, EventArgs e)
        {

            string name = tbName.Text;
            string codeArabic = tbCourseCodeArabic.Text;
            string codeEnglish = tbCourseCodeEnglish.Text;
            int y = int.Parse(cbYears.SelectedItem.ToString());
            string[] dv = new string[6];
            clbDivisions.CheckedItems.CopyTo(dv, 0);
            cid = c.InsertCourse(name, codeArabic, codeEnglish, y, dv);
            MessageBox.Show(" COURSE INSERTION WORKED click on course class details button to enter class details");
            button1.Visible = true;
        }

        private void Add_Cource_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            gbOneLevel.Visible = false;
            gbTwoLevels.Visible = false;
            cbNumberOfLevels.Items.Add("1");
            cbNumberOfLevels.Items.Add("2");
            for (int i = 1; i <= 5; i++)
            {
                cbYears.Items.Add(i);
                cbyears1.Items.Add(i);
                cbyears2.Items.Add(i);
            }
            DataTable dt = c.comboDivision();

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                clbDivisions.Items.Add((dt.Columns[i].ColumnName).ToString());
                clbDivisions1.Items.Add((dt.Columns[i].ColumnName).ToString());
                clbDivisions2.Items.Add((dt.Columns[i].ColumnName).ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Course_Class frm = new Add_Course_Class();
            frm.Show();
        }
    }
}
