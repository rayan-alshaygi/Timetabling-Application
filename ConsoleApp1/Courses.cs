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
        int cid;
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
            this.WindowState = FormWindowState.Maximized;
            chbLecture.Checked = true;
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

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                clbDivisions.Items.Add((dt.Columns[i].ColumnName).ToString());
                clbDivisions1.Items.Add((dt.Columns[i].ColumnName).ToString());
                clbDivisions2.Items.Add((dt.Columns[i].ColumnName).ToString());
            }
            DataTable dt2 = c.ComboInstructorName();
            for (int j = 0; j < dt2.Rows.Count; j++)
                cbLectureInstructor.Items.Add(dt2.Rows[j].Field<string>(1));
            chbLabInstrucctores.Visible = false;
            cbLectureInstructor.Visible = true;
            chbTutorialInstructors.Visible = false;
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
            MessageBox.Show(" COURSE INSERTION WORKED CONTINUE DATA ENTRY");
        }

        private void button1_Click_1(object sender, EventArgs e)
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
           cid = c.InsertCourse(name, codeArabic, codeEnglish,y1, dv1, y2, dv2);
            MessageBox.Show(" COURSE INSERTION WORKED CONTINUE DATA ENTRY");
        }

        private void chbLab_CheckedChanged(object sender, EventArgs e)
        {
            chbLabInstrucctores.Visible = true;

            DataTable dt = c.ComboInstructorName();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if(!dt.Rows[i]["TA"].Equals(false) )
                    chbLabInstrucctores.Items.Add(dt.Rows[i].Field<string>(1));
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chbTutorialInstructors.Visible = true;
            DataTable dt = c.ComboInstructorName();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!dt.Rows[i]["TA"].Equals(false))
                    {
                        chbTutorialInstructors.Items.Add(dt.Rows[i].Field<string>(1));

                    }                             
                }
            }
            catch (Exception)
            { }
        }

        private void btAddCourseAS_Click(object sender, EventArgs e)
        {
            string classname;
            bool lab= false;
            bool tut = false; ;
            if (chbLecture.Checked ==  true)
            {
                int duration = int.Parse(tbClassDuration.Text);
                classname = "محاضرة " + tbName.Text;
                string instructor = cbLectureInstructor.SelectedItem.ToString();// .SelectedValue.ToString();
                c.InsertCourseClass(classname, duration, lab, tut, instructor, cid);
            }
            
            string[] ta = new string[10];
            if (checkBox3.Checked == true)
            {
                tut = true;
                classname = "تمارين " + tbName.Text;
                int d = 2;
                chbTutorialInstructors.CheckedItems.CopyTo(ta,0);
                c.insertLabsOrTutorial(classname, d, lab,tut, ta, cid);
                tut = false;
            }
                
            if (chbLab.Checked == true)
            {
                lab = true;
                classname = "Lab" + tbName.Text;
                int d = 2;
                chbLabInstrucctores.CheckedItems.CopyTo(ta, 0);
                c.insertLabsOrTutorial(classname, d, lab, tut, ta, cid);
                lab = false;
            }

            MessageBox.Show(" Classes Inserted ");
            this.Dispose(false);
            courses course = new courses();
            course.Show();
        }

        private void cbyears2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chbLabInstrucctores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chbTutorialInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbLectureInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tbClassName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbClassDuration_TextChanged(object sender, EventArgs e)
        {

        }

        private void clbDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void clbDivisions1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
