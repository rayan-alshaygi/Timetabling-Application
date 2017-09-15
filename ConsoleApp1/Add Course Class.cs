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
            if (tbcode.Text == "" || tbClassDuration.Text == "" || (chbLab.Checked == true && chbLabInstrucctores.SelectedItems.Count == 0) || (chbLecture.Checked == true && chbLectureInstructores.SelectedItems.Count == 0) || (checkBox3.Checked == true && chbTutorialInstructors.SelectedItems.Count == 0))
            {
                MessageBox.Show("please fill all require fields");
            }
            else
            {
                DataTable dt2 = c.ComboInstructorName();
                string classname;
                bool lab = false;
                bool tut = false;
                string n ="";
                DataTable dt = c.GetCourseIdandName(tbcode.Text);
                int?[] x = new int?[2];
                if (dt.Rows.Count != 0)
                {
                    cid = Int32.Parse(dt.Rows[0]["Id"].ToString());
                    n = dt.Rows[0].Field<string>(1).ToString();
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
                    for (int i = 0; i < numCheckedItems; i++)
                    {
                        ins[i] = (chbLectureInstructores.Items[checkedIndices[i]] as MyListBoxItem).Value;
                    }
                    c.InsertCourseClass(classname, duration, lab, tut, ins, cid);
                }
                int id = 0;

                if (checkBox3.Checked == true)
                {
                    int numCheckedItems = chbTutorialInstructors.CheckedItems.Count;
                    int[] ta = new int[numCheckedItems];
                    int[] checkedIndices = new int[numCheckedItems];
                    tut = true;
                    classname = "تمارين " + n;
                    int d = 2;
                    chbTutorialInstructors.CheckedIndices.CopyTo(checkedIndices, 0); //ToString().CopyTo(0,ta,0,chbTutorialInstructors.SelectedItems.Count);
                    for (int j = 0; j < numCheckedItems; j++)
                    {
                        ta[j] = (chbTutorialInstructors.Items[checkedIndices[j]] as MyListBoxItem).Value;
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
                    for (int k = 0; k < numCheckedItems; k++)
                    {
                        ta[k] = (chbLabInstrucctores.Items[checkedIndices[k]] as MyListBoxItem).Value;
                    }
                    chbLabInstrucctores.CheckedItems.CopyTo(ta, 0);
                    c.insertLabsOrTutorial(classname, d, lab, tut, ta, cid);
                    lab = false;
                }

                MessageBox.Show(" Classes Inserted " + id);
            }
        }
        private void Add_Course_Class_Load(object sender, EventArgs e)
        {
            
            label5.Visible = false;
            label6.Visible = false;
            DataTable dt2 = c.ComboInstructorName();
            for (int j = 0; j < dt2.Rows.Count; j++)
                chbLectureInstructores.Items.Add(dt2.Rows[j].Field<string>(1));
            chbLabInstrucctores.Visible = false;
            chbLectureInstructores.Visible = true;
            chbTutorialInstructors.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void chbLab_CheckedChanged(object sender, EventArgs e)
        {
            chbLabInstrucctores.Visible = true;
            label3.Visible = true;
            DataTable dt = c.ComboInstructorName();
            int z = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dt.Rows[i]["TA"].Equals(false))
                {
                    chbLabInstrucctores.Items.Add(dt.Rows[i].Field<string>(1));
                    z++;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chbTutorialInstructors.Visible = true;
            label4.Visible = true;
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
                        chbTutorialInstructors.Items.Add(dt.Rows[i].Field<string>(1));
                        z++;
                        // chbTutorialInstructors.Items.Add(dt.Rows[i].Field<string>(1));
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void tbClassDuration_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tbClassDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                label5.Visible = true;
                label6.Visible = true;
                tbClassDuration.Clear();
            }
            else
            {

                label5.Visible = false;
                label6.Visible = false;
            }
        }
    }
    public class MyListBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
