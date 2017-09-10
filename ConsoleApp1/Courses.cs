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

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                clbDivisions.Items.Add((dt.Columns[i].ColumnName).ToString());
                clbDivisions1.Items.Add((dt.Columns[i].ColumnName).ToString());
                clbDivisions2.Items.Add((dt.Columns[i].ColumnName).ToString());
            }
            chbLectureInstructores.Visible = true;
            chbLectureInstructores.DisplayMember = "Text";
            chbLectureInstructores.ValueMember = "Value";
            DataTable dt2 = c.ComboInstructorName();
            //for (int j = 0; j < dt2.Rows.Count; j++)
            // cbLectureInstructor.Items.Add(dt2.Rows[j].Field<string>(1));
            int z = 0;
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                chbLectureInstructores.Items.Insert(z, new MyListBoxItem { Text = dt2.Rows[i].Field<string>(1), Value = Int32.Parse(dt2.Rows[i]["Id"].ToString()) });
                z++;

            }
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
            cid = c.InsertCourse(name, codeArabic, codeEnglish, y1, dv1, y2, dv2);
            MessageBox.Show(" COURSE INSERTION WORKED CONTINUE DATA ENTRY");
        }

        private void chbLab_CheckedChanged(object sender, EventArgs e)
        {
            chbLabInstrucctores.Visible = true;
            chbLabInstrucctores.DisplayMember = "Text";
            chbLabInstrucctores.ValueMember = "Value";

            DataTable dt = c.ComboInstructorName();
            int z = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dt.Rows[i]["TA"].Equals(false))
                {
                    chbLabInstrucctores.Items.Insert(z, new MyListBoxItem { Text = dt.Rows[i].Field<string>(1), Value = Int32.Parse(dt.Rows[i]["Id"].ToString()) });
                    z++;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chbTutorialInstructors.Visible = true;
            chbTutorialInstructors.DisplayMember = "Text";
            chbTutorialInstructors.ValueMember = "Value";

            DataTable dt = c.ComboInstructorName();
            try
            {
                int z = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!dt.Rows[i]["TA"].Equals(false))
                    {
                        chbTutorialInstructors.Items.Insert(z, new MyListBoxItem { Text = dt.Rows[i].Field<string>(1), Value = Int32.Parse(dt.Rows[i]["Id"].ToString()) });
                        z++;
                        // chbTutorialInstructors.Items.Add(dt.Rows[i].Field<string>(1));
                    }
                }
            }
            catch (Exception)
            { }
        }
        public class MyListBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }
        private void btAddCourseAS_Click(object sender, EventArgs e)
        {
            DataTable dt2 = c.ComboInstructorName();
            string classname;
            bool lab = false;
            bool tut = false;
            string n;
            n = tbName.Text;
            if (checkBox1.Checked == true)
            {
                DataTable dt = c.GetCourseIdandName(textBox1.Text);
                int?[] x = new int?[2];
                if (dt.Rows.Count != 0)
                {
                    cid = Int32.Parse(dt.Rows[0]["Id"].ToString());
                    n = dt.Rows[0]["name"].ToString();
                }
                coName.Text = n;
            }
            if (chbLecture.Checked == true)
            {
                int numCheckedItems = chbLectureInstructores.CheckedItems.Count;
                int[] ins = new int[numCheckedItems];
                int[] checkedIndices = new int[numCheckedItems];
                int duration = int.Parse(tbClassDuration.Text);
                classname = "محاضرة " + n;
                //string instructor = cbLectureInstructor.SelectedItem.ToString();// .SelectedValue.ToString();
                //int ins = Int32.Parse(dt2.Rows[cbLectureInstructor.SelectedIndex]["Id"].ToString());
                chbLectureInstructores.CheckedIndices.CopyTo(checkedIndices, 0); 
                for (int x = 0; x < numCheckedItems; x++)
                {
                    ins[x] = (chbLectureInstructores.Items[checkedIndices[x]] as MyListBoxItem).Value;
                }
                c.InsertCourseClass(classname, duration, lab, tut, ins, cid);
            }
            int id=0;

            if (checkBox3.Checked == true)
            {
                int numCheckedItems = chbTutorialInstructors.CheckedItems.Count;
                int[] ta = new int[numCheckedItems];
                int[] checkedIndices = new int[numCheckedItems];
                tut = true;
                classname = "تمارين " + n;
                int d = 2;
                chbTutorialInstructors.CheckedIndices.CopyTo(checkedIndices, 0); //ToString().CopyTo(0,ta,0,chbTutorialInstructors.SelectedItems.Count);
                for (int x = 0; x < numCheckedItems; x++)
                {
                    ta[x] = (chbTutorialInstructors.Items[checkedIndices[x]] as MyListBoxItem).Value;
                }
                id = c.insertLabsOrTutorial(classname, d, lab, tut, ta, cid);
                tut = false;
            }

            if (chbLab.Checked == true)
            {
                int numCheckedItems = chbTutorialInstructors.CheckedItems.Count;
                int[] ta = new int[numCheckedItems];
                int[] checkedIndices = new int[numCheckedItems];
                lab = true;
                tut = false;
                classname = "Lab" + n;
                int d = 2;
                chbLabInstrucctores.CheckedIndices.CopyTo(checkedIndices, 0); //ToString().CopyTo(0,ta,0,chbTutorialInstructors.SelectedItems.Count);
                for (int x = 0; x < numCheckedItems; x++)
                {
                    ta[x] = (chbLabInstrucctores.Items[checkedIndices[x]] as MyListBoxItem).Value;
                }
                chbLabInstrucctores.CheckedItems.CopyTo(ta, 0);
                c.insertLabsOrTutorial(classname, d, lab, tut, ta, cid);
                lab = false;
            }

            MessageBox.Show(" Classes Inserted " + id);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void chbLecture_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
