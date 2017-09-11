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
    public partial class Add_Course_Class : Form
    {

        FormDbData c = new FormDbData();
        int cid;
        public Add_Course_Class()
        {
            InitializeComponent();
        }

        private void btAddCourseAS_Click(object sender, EventArgs e)
        {
            DataTable dt2 = c.ComboInstructorName();
            string classname;
            bool lab = false;
            bool tut = false; ;
            if (checkBox3.Checked == true && chbLab.Checked == true)
            { 
            int duration = int.Parse(tbClassDuration.Text);
            classname = "محاضرة " + tbcode.Text;
            //string instructor = cbLectureInstructor.SelectedItem.ToString();// .SelectedValue.ToString();
            int ins = Int32.Parse(dt2.Rows[cbLectureInstructor.SelectedIndex]["Id"].ToString());
            c.InsertCourseClass(classname, duration, lab, tut, ins, cid);
        }
            if (checkBox3.Checked == true )
            {
                int numCheckedItems = chbTutorialInstructors.CheckedItems.Count;
                int[] ta = new int[numCheckedItems];
                int[] checkedIndices = new int[numCheckedItems];
                tut = true;
                classname = "تمارين " + tbcode.Text;
                int d = 2;
                chbTutorialInstructors.CheckedIndices.CopyTo(checkedIndices, 0); //ToString().CopyTo(0,ta,0,chbTutorialInstructors.SelectedItems.Count);
                for (int x = 0; x < numCheckedItems; x++)
                {
                    ta[x] = (chbTutorialInstructors.Items[checkedIndices[x]] as MyListBoxItem).Value;
                }
                c.insertLabsOrTutorial(classname, d, lab, tut, ta, cid);
                tut = false;
            }

            if (chbLab.Checked == true)
            {
                int numCheckedItems = chbTutorialInstructors.CheckedItems.Count;
                int[] ta = new int[numCheckedItems];
                int[] checkedIndices = new int[numCheckedItems];
                lab = true;
                tut = false;
                classname = "Lab" + tbcode.Text;
                int d = 2; chbTutorialInstructors.CheckedIndices.CopyTo(checkedIndices, 0); //ToString().CopyTo(0,ta,0,chbTutorialInstructors.SelectedItems.Count);
                for (int x = 0; x < numCheckedItems; x++)
                {
                    ta[x] = (chbTutorialInstructors.Items[checkedIndices[x]] as MyListBoxItem).Value;
                }
                chbLabInstrucctores.CheckedItems.CopyTo(ta, 0);
                c.insertLabsOrTutorial(classname, d, lab, tut, ta, cid);
                lab = false;
            }

            MessageBox.Show(" Classes Inserted ");
            this.Dispose(false);
            courses course = new courses();
            course.Show();
        }
        private void Add_Course_Class_Load(object sender, EventArgs e)
        {
            DataTable dt2 = c.ComboInstructorName();
            for (int j = 0; j < dt2.Rows.Count; j++)
                cbLectureInstructor.Items.Add(dt2.Rows[j].Field<string>(1));
            chbLabInstrucctores.Visible = false;
            cbLectureInstructor.Visible = true;
            chbTutorialInstructors.Visible = false;
        }

        private void chbLab_CheckedChanged(object sender, EventArgs e)
        {
            chbLabInstrucctores.Visible = true;

            DataTable dt = c.ComboInstructorName();
            int z = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dt.Rows[i]["TA"].Equals(false))
                {
                    chbTutorialInstructors.Items.Insert(z, new MyListBoxItem { Text = dt.Rows[i].Field<string>(1), Value = Int32.Parse(dt.Rows[i]["Id"].ToString()) });
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
    }
    public class MyListBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
