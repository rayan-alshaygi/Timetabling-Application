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
    public partial class MainForm : Form
    {
        FormDbData c = new FormDbData();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btAddTeacher_Click(object sender, EventArgs e)
        {
            gbAddCourse.Visible = false;
            gbAddStudent.Visible = false;
            gbMakeSchedule.Visible = false;
            gbAddTeacher.Visible = true;
            gbAddTeacher.Location = new Point(391, 222);
            gbAddTeacher.Size = new System.Drawing.Size(467, 181);
            tbInstructorName.Text = "";

        }

        private void btAddCourse_Click(object sender, EventArgs e)
        {
            gbAddCourse.Visible = true;
            gbAddStudent.Visible = false;
            gbMakeSchedule.Visible = false;
            gbAddTeacher.Visible = false;
            gbAddCourse.Location = new Point(391, 222);
            gbAddCourse.Size = new System.Drawing.Size(467, 181);
            tbCourseName.Text = "";
            cbdivision.Items.Clear();
            DataTable dt = c.ComboCourseName();
            dataGridView1.DataSource = dt;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int index = 0; index < dataGridView1.Rows.Count - 1; index++)
                {
                    //cbIntructorName.Items.Add(dataGridView1.Rows[index].Cells[0].Value);
                }
            }
        }

        private void btAddStudent_Click(object sender, EventArgs e)
        {
            gbAddCourse.Visible = false;
            gbAddStudent.Visible = true;
            gbMakeSchedule.Visible = false;
            gbAddTeacher.Visible = false;
            gbAddStudent.Location = new Point(391, 222);
            gbAddStudent.Size = new System.Drawing.Size(467, 181);
            CBSelectDivision.Items.Clear();
            CBSelectYear.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                CBSelectYear.Items.Add(i);
            }
            DataTable dt = c.comboDivision();

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                CBSelectDivision.Items.Add((dt.Columns[i].ColumnName).ToString());
            }

        }

        private void btMakeSchedule_Click(object sender, EventArgs e)
        {
            gbAddCourse.Visible = false;
            gbAddStudent.Visible = false;
            gbMakeSchedule.Visible = true;
            gbAddTeacher.Visible = false;
            gbMakeSchedule.Location = new Point(391, 222);
            gbMakeSchedule.Size = new System.Drawing.Size(467, 181);
            cbCourseName.Items.Clear();
            DataTable dt = c.ComboCourseName();
            dataGridView4.DataSource = dt;
            if (dataGridView4.Rows.Count > 0)
            {
                for (int index = 0; index < dataGridView4.Rows.Count - 1; index++)
                {
                    cbCourseName.Items.Add(dataGridView4.Rows[index].Cells[0].Value);
                }
            }
            //DataTable dt1 = Counts.RandomNumberList();
            //dataGridView5.DataSource = dt1;

        }
        private void btAddDivisionSize_Click_1(object sender, EventArgs e)
        {
            gbAddCourse.Visible = false;
            gbAddStudent.Visible = false;
            gbMakeSchedule.Visible = false;
            gbAddTeacher.Visible = false;
            gbAddDivisionSize.Visible = true;
            gbAddDivisionSize.Location = new Point(391, 222);
            gbAddDivisionSize.Size = new System.Drawing.Size(467, 181);
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
            
        }
        private void btAddCurriculum_Click(object sender, EventArgs e)
        {
            gbAddCourse.Visible = false;
            gbAddStudent.Visible = false;
            gbMakeSchedule.Visible = false;
            gbAddTeacher.Visible = false;
            gbAddDivisionSize.Visible = false;
            gbAddCurriculm.Visible = true;
            gbAddCurriculm.Location = new Point(391, 222);
            gbAddCurriculm.Size = new System.Drawing.Size(467, 181);
            for (int i = 1; i <= 5; i++)
            {
                comboBox1.Items.Add(i);
            }
            DataTable dt = c.comboDivision();

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                comboBox2.Items.Add((dt.Columns[i].ColumnName).ToString());
            }

        }


        private void btInsertTeacher_Click(object sender, EventArgs e)
        {

            string InstructorName = tbInstructorName.Text;
            int val = c.InsertInstructor(InstructorName);
            if (val > 0)
            {
                tbInstructorName.Text = "";
            }
        }

        private void btAddCourseAC_Click(object sender, EventArgs e)
        {
            // string CoursName = tbCourseName.Text;
            // string InstructorName = cbIntructorName.Text;
            //int val = c.InsertCourse(CoursName, InstructorName);
            //if (val > 0)
            //{
            //    tbCourseName.Text = "";
            //}

        }

        private void cbCourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CourseName = cbCourseName.Text;
            DataTable dt = c.InstructorName(CourseName);
            dataGridView3.DataSource = dt;
            if (dataGridView3.Rows.Count > 0)
            {
                tbInstructorNameMS.Text = dataGridView3.Rows[0].Cells[0].Value.ToString();
            }

        }

        private void btMakeScheduleMS_Click(object sender, EventArgs e)
        {
            //List<string> RandomNumberList = new List<string>();
            //DataTable dt = Counts.RandomNumberList();
            //dataGridView5.DataSource = dt;
            //if (dataGridView5.Rows.Count > 0)
            //{
            //    for (int index = 0; index < dataGridView5.Rows.Count - 1; index++)
            //    {
            //        RandomNumberList.Add(dataGridView5.Rows[index].Cells[0].Value.ToString());

            //    }
            //}
            //goto a;
            //a:
            //bool inList = false; ;
            //Random RandomRow = new Random();
            //Random RandomColumn = new Random();
            //int intRow = RandomRow.Next(0, 5);
            //int intColumn = RandomColumn.Next(0, 3);
            //string CombineNumber = intRow.ToString() + intColumn.ToString();
            //for (int index = 0; index < RandomNumberList.Count - 1; index++)
            //{
            //    if (CombineNumber == RandomNumberList[index])
            //    {
            //        inList = true;
            //    }
            //}
            //if (inList == true)
            //{
            //    goto a;
            //}
            //else if (inList == false)
            //{
            //    string CourseName = cbCourseName.Text;
            //    string InstructorName = tbInstructorNameMS.Text;
            //    int val = Counts.UpdateCourseRowColumn(CourseName, InstructorName, intRow.ToString(), intColumn.ToString());
            //    int val2 = Counts.insertRandom(CombineNumber);

            //}

        }

        private void btSeeSchedule_Click(object sender, EventArgs e)
        {
            this.Hide();
            Schedule sc = new Schedule();
            //sc.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gbAddDivisionSize.Visible = false;
            gbAddCurriculm.Visible = false;
        }

        private void gbAddStudent_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            F.Show();
        }

        private void gbAddCourse_Enter(object sender, EventArgs e)
        {

        }

        private void lblInstructorNameAC_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btAddStudentAS_Click(object sender, EventArgs e)
        {

        }


        private void btAddCurriculmn_Click(object sender, EventArgs e)
        {

        }





        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbDivisionSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDivisionSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gbAddTeacher_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void btAddDivisioSizeAD_Click(object sender, EventArgs e)
        {
            int size = Int32.Parse(tbDivisionSize.Text);
            string dvname = cbDivision1.SelectedItem.ToString();
            int year = Int32.Parse(cbYear1.SelectedItem.ToString());
            int x = c.insertdivisionsize(dvname, year, size);
            if (x > 0)
            {
                tbDivisionSize.Text = "";
                cbDivision1.Text = "";
                cbYear1.Text = "";
            }
        }

        private void gbAddCurriculm_Enter(object sender, EventArgs e)
        {

        }
    }
}
