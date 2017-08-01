namespace ConsoleApp1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btAddTeacher = new System.Windows.Forms.Button();
            this.btAddCourse = new System.Windows.Forms.Button();
            this.btAddStudent = new System.Windows.Forms.Button();
            this.btMakeSchedule = new System.Windows.Forms.Button();
            this.btSeeSchedule = new System.Windows.Forms.Button();
            this.btLogout = new System.Windows.Forms.Button();
            this.btAddRoom = new System.Windows.Forms.Button();
            this.gbAddTeacher = new System.Windows.Forms.GroupBox();
            this.chBIsTA = new System.Windows.Forms.CheckBox();
            this.tbInstructorName = new System.Windows.Forms.TextBox();
            this.lblInstructorName = new System.Windows.Forms.Label();
            this.btInsertTeacher = new System.Windows.Forms.Button();
            this.gbAddStudent = new System.Windows.Forms.GroupBox();
            this.CBSelectYear = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btAddStudentAS = new System.Windows.Forms.Button();
            this.lblSelectYearAs = new System.Windows.Forms.Label();
            this.lblDivisionAS = new System.Windows.Forms.Label();
            this.CBSelectDivision = new System.Windows.Forms.ComboBox();
            this.gbMakeSchedule = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.generateSchedule = new System.Windows.Forms.Button();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tbInstructorNameMS = new System.Windows.Forms.TextBox();
            this.lblInstructorNameMS = new System.Windows.Forms.Label();
            this.btMakeScheduleMS = new System.Windows.Forms.Button();
            this.lblCourseNameMS = new System.Windows.Forms.Label();
            this.cbCourseName = new System.Windows.Forms.ComboBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btgotoform2 = new System.Windows.Forms.Button();
            this.btAddDivisionSize = new System.Windows.Forms.Button();
            this.btAddCurriculum = new System.Windows.Forms.Button();
            this.gbAddDivisionSize = new System.Windows.Forms.GroupBox();
            this.lblPRooms = new System.Windows.Forms.Label();
            this.cbRooms = new System.Windows.Forms.ComboBox();
            this.btAddDivisioSizeAD = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDivisionSize = new System.Windows.Forms.TextBox();
            this.cbYear1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDivision1 = new System.Windows.Forms.ComboBox();
            this.gbAddCurriculm = new System.Windows.Forms.GroupBox();
            this.lblCurriculmName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btAddCurriculmAs = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.gbAddRoom = new System.Windows.Forms.GroupBox();
            this.chbLab = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSeats = new System.Windows.Forms.TextBox();
            this.btAddRoomAS = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.gbAddTeacher.SuspendLayout();
            this.gbAddStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.gbMakeSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.gbAddDivisionSize.SuspendLayout();
            this.gbAddCurriculm.SuspendLayout();
            this.gbAddRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAddTeacher
            // 
            this.btAddTeacher.Location = new System.Drawing.Point(24, 79);
            this.btAddTeacher.Name = "btAddTeacher";
            this.btAddTeacher.Size = new System.Drawing.Size(177, 39);
            this.btAddTeacher.TabIndex = 0;
            this.btAddTeacher.Text = "Add Teacher";
            this.btAddTeacher.UseVisualStyleBackColor = true;
            this.btAddTeacher.Click += new System.EventHandler(this.btAddTeacher_Click);
            // 
            // btAddCourse
            // 
            this.btAddCourse.Location = new System.Drawing.Point(24, 210);
            this.btAddCourse.Name = "btAddCourse";
            this.btAddCourse.Size = new System.Drawing.Size(177, 39);
            this.btAddCourse.TabIndex = 1;
            this.btAddCourse.Text = "Add Course";
            this.btAddCourse.UseVisualStyleBackColor = true;
            this.btAddCourse.Click += new System.EventHandler(this.btAddCourse_Click);
            // 
            // btAddStudent
            // 
            this.btAddStudent.Location = new System.Drawing.Point(24, 255);
            this.btAddStudent.Name = "btAddStudent";
            this.btAddStudent.Size = new System.Drawing.Size(177, 39);
            this.btAddStudent.TabIndex = 2;
            this.btAddStudent.Text = "Add Student";
            this.btAddStudent.UseVisualStyleBackColor = true;
            this.btAddStudent.Click += new System.EventHandler(this.btAddStudent_Click);
            // 
            // btMakeSchedule
            // 
            this.btMakeSchedule.Location = new System.Drawing.Point(24, 344);
            this.btMakeSchedule.Name = "btMakeSchedule";
            this.btMakeSchedule.Size = new System.Drawing.Size(177, 39);
            this.btMakeSchedule.TabIndex = 3;
            this.btMakeSchedule.Text = "Make Schedule";
            this.btMakeSchedule.UseVisualStyleBackColor = true;
            this.btMakeSchedule.Click += new System.EventHandler(this.btMakeSchedule_Click);
            // 
            // btSeeSchedule
            // 
            this.btSeeSchedule.Location = new System.Drawing.Point(24, 389);
            this.btSeeSchedule.Name = "btSeeSchedule";
            this.btSeeSchedule.Size = new System.Drawing.Size(177, 39);
            this.btSeeSchedule.TabIndex = 4;
            this.btSeeSchedule.Text = "See Schedule";
            this.btSeeSchedule.UseVisualStyleBackColor = true;
            this.btSeeSchedule.Click += new System.EventHandler(this.btSeeSchedule_Click);
            // 
            // btLogout
            // 
            this.btLogout.Location = new System.Drawing.Point(24, 434);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(177, 39);
            this.btLogout.TabIndex = 5;
            this.btLogout.Text = "Logout";
            this.btLogout.UseVisualStyleBackColor = true;
            // 
            // btAddRoom
            // 
            this.btAddRoom.Location = new System.Drawing.Point(24, 300);
            this.btAddRoom.Name = "btAddRoom";
            this.btAddRoom.Size = new System.Drawing.Size(177, 39);
            this.btAddRoom.TabIndex = 6;
            this.btAddRoom.Text = "Add Room";
            this.btAddRoom.UseVisualStyleBackColor = true;
            this.btAddRoom.Click += new System.EventHandler(this.btAddRoom_Click);
            // 
            // gbAddTeacher
            // 
            this.gbAddTeacher.Controls.Add(this.chBIsTA);
            this.gbAddTeacher.Controls.Add(this.tbInstructorName);
            this.gbAddTeacher.Controls.Add(this.lblInstructorName);
            this.gbAddTeacher.Controls.Add(this.btInsertTeacher);
            this.gbAddTeacher.Location = new System.Drawing.Point(443, 19);
            this.gbAddTeacher.Name = "gbAddTeacher";
            this.gbAddTeacher.Size = new System.Drawing.Size(101, 46);
            this.gbAddTeacher.TabIndex = 7;
            this.gbAddTeacher.TabStop = false;
            this.gbAddTeacher.Text = "Add Teacher";
            this.gbAddTeacher.Visible = false;
            // 
            // chBIsTA
            // 
            this.chBIsTA.AutoSize = true;
            this.chBIsTA.Location = new System.Drawing.Point(142, 88);
            this.chBIsTA.Name = "chBIsTA";
            this.chBIsTA.Size = new System.Drawing.Size(40, 17);
            this.chBIsTA.TabIndex = 17;
            this.chBIsTA.Text = "TA";
            this.chBIsTA.UseVisualStyleBackColor = true;
            // 
            // tbInstructorName
            // 
            this.tbInstructorName.BackColor = System.Drawing.Color.White;
            this.tbInstructorName.ForeColor = System.Drawing.Color.Black;
            this.tbInstructorName.Location = new System.Drawing.Point(142, 46);
            this.tbInstructorName.Name = "tbInstructorName";
            this.tbInstructorName.Size = new System.Drawing.Size(215, 20);
            this.tbInstructorName.TabIndex = 15;
            // 
            // lblInstructorName
            // 
            this.lblInstructorName.AutoSize = true;
            this.lblInstructorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructorName.Location = new System.Drawing.Point(19, 46);
            this.lblInstructorName.Name = "lblInstructorName";
            this.lblInstructorName.Size = new System.Drawing.Size(117, 15);
            this.lblInstructorName.TabIndex = 14;
            this.lblInstructorName.Text = "Instructor Name :";
            // 
            // btInsertTeacher
            // 
            this.btInsertTeacher.BackColor = System.Drawing.Color.White;
            this.btInsertTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInsertTeacher.Location = new System.Drawing.Point(161, 125);
            this.btInsertTeacher.Name = "btInsertTeacher";
            this.btInsertTeacher.Size = new System.Drawing.Size(136, 43);
            this.btInsertTeacher.TabIndex = 12;
            this.btInsertTeacher.Text = "Insert Teacher";
            this.btInsertTeacher.UseVisualStyleBackColor = false;
            this.btInsertTeacher.Click += new System.EventHandler(this.btInsertTeacher_Click);
            // 
            // gbAddStudent
            // 
            this.gbAddStudent.Controls.Add(this.CBSelectYear);
            this.gbAddStudent.Controls.Add(this.dataGridView2);
            this.gbAddStudent.Controls.Add(this.btAddStudentAS);
            this.gbAddStudent.Controls.Add(this.lblSelectYearAs);
            this.gbAddStudent.Controls.Add(this.lblDivisionAS);
            this.gbAddStudent.Controls.Add(this.CBSelectDivision);
            this.gbAddStudent.Location = new System.Drawing.Point(602, 26);
            this.gbAddStudent.Name = "gbAddStudent";
            this.gbAddStudent.Size = new System.Drawing.Size(77, 39);
            this.gbAddStudent.TabIndex = 17;
            this.gbAddStudent.TabStop = false;
            this.gbAddStudent.Text = "Add Student";
            this.gbAddStudent.Visible = false;
            // 
            // CBSelectYear
            // 
            this.CBSelectYear.AllowDrop = true;
            this.CBSelectYear.BackColor = System.Drawing.Color.White;
            this.CBSelectYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSelectYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBSelectYear.ForeColor = System.Drawing.Color.Black;
            this.CBSelectYear.FormattingEnabled = true;
            this.CBSelectYear.Location = new System.Drawing.Point(139, 104);
            this.CBSelectYear.Name = "CBSelectYear";
            this.CBSelectYear.Size = new System.Drawing.Size(210, 21);
            this.CBSelectYear.TabIndex = 17;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(205, 149);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(41, 17);
            this.dataGridView2.TabIndex = 16;
            // 
            // btAddStudentAS
            // 
            this.btAddStudentAS.BackColor = System.Drawing.Color.White;
            this.btAddStudentAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddStudentAS.Location = new System.Drawing.Point(358, 74);
            this.btAddStudentAS.Name = "btAddStudentAS";
            this.btAddStudentAS.Size = new System.Drawing.Size(88, 43);
            this.btAddStudentAS.TabIndex = 12;
            this.btAddStudentAS.Text = "Add Student";
            this.btAddStudentAS.UseVisualStyleBackColor = false;
            // 
            // lblSelectYearAs
            // 
            this.lblSelectYearAs.AutoSize = true;
            this.lblSelectYearAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectYearAs.Location = new System.Drawing.Point(55, 110);
            this.lblSelectYearAs.Name = "lblSelectYearAs";
            this.lblSelectYearAs.Size = new System.Drawing.Size(78, 15);
            this.lblSelectYearAs.TabIndex = 14;
            this.lblSelectYearAs.Text = "Select year";
            // 
            // lblDivisionAS
            // 
            this.lblDivisionAS.AutoSize = true;
            this.lblDivisionAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDivisionAS.Location = new System.Drawing.Point(39, 49);
            this.lblDivisionAS.Name = "lblDivisionAS";
            this.lblDivisionAS.Size = new System.Drawing.Size(100, 15);
            this.lblDivisionAS.TabIndex = 13;
            this.lblDivisionAS.Text = "Select division";
            // 
            // CBSelectDivision
            // 
            this.CBSelectDivision.AllowDrop = true;
            this.CBSelectDivision.BackColor = System.Drawing.Color.White;
            this.CBSelectDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSelectDivision.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBSelectDivision.ForeColor = System.Drawing.Color.Black;
            this.CBSelectDivision.FormattingEnabled = true;
            this.CBSelectDivision.Location = new System.Drawing.Point(139, 47);
            this.CBSelectDivision.Name = "CBSelectDivision";
            this.CBSelectDivision.Size = new System.Drawing.Size(210, 21);
            this.CBSelectDivision.TabIndex = 11;
            // 
            // gbMakeSchedule
            // 
            this.gbMakeSchedule.Controls.Add(this.textBox2);
            this.gbMakeSchedule.Controls.Add(this.generateSchedule);
            this.gbMakeSchedule.Controls.Add(this.dataGridView5);
            this.gbMakeSchedule.Controls.Add(this.dataGridView4);
            this.gbMakeSchedule.Controls.Add(this.dataGridView3);
            this.gbMakeSchedule.Controls.Add(this.tbInstructorNameMS);
            this.gbMakeSchedule.Controls.Add(this.lblInstructorNameMS);
            this.gbMakeSchedule.Controls.Add(this.btMakeScheduleMS);
            this.gbMakeSchedule.Controls.Add(this.lblCourseNameMS);
            this.gbMakeSchedule.Controls.Add(this.cbCourseName);
            this.gbMakeSchedule.Location = new System.Drawing.Point(346, 19);
            this.gbMakeSchedule.Name = "gbMakeSchedule";
            this.gbMakeSchedule.Size = new System.Drawing.Size(70, 50);
            this.gbMakeSchedule.TabIndex = 17;
            this.gbMakeSchedule.TabStop = false;
            this.gbMakeSchedule.Text = "Make Schedule";
            this.gbMakeSchedule.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(204, 26);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 25;
            // 
            // generateSchedule
            // 
            this.generateSchedule.Location = new System.Drawing.Point(97, 24);
            this.generateSchedule.Name = "generateSchedule";
            this.generateSchedule.Size = new System.Drawing.Size(75, 35);
            this.generateSchedule.TabIndex = 24;
            this.generateSchedule.Text = "Generate Schedule";
            this.generateSchedule.UseVisualStyleBackColor = true;
            this.generateSchedule.Click += new System.EventHandler(this.generateSchedule_Click);
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(339, 165);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(49, 32);
            this.dataGridView5.TabIndex = 18;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(193, 165);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(49, 32);
            this.dataGridView4.TabIndex = 17;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(38, 165);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(49, 32);
            this.dataGridView3.TabIndex = 16;
            // 
            // tbInstructorNameMS
            // 
            this.tbInstructorNameMS.BackColor = System.Drawing.Color.White;
            this.tbInstructorNameMS.ForeColor = System.Drawing.Color.Black;
            this.tbInstructorNameMS.Location = new System.Drawing.Point(131, 112);
            this.tbInstructorNameMS.Name = "tbInstructorNameMS";
            this.tbInstructorNameMS.ReadOnly = true;
            this.tbInstructorNameMS.Size = new System.Drawing.Size(202, 20);
            this.tbInstructorNameMS.TabIndex = 15;
            // 
            // lblInstructorNameMS
            // 
            this.lblInstructorNameMS.AutoSize = true;
            this.lblInstructorNameMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructorNameMS.Location = new System.Drawing.Point(11, 115);
            this.lblInstructorNameMS.Name = "lblInstructorNameMS";
            this.lblInstructorNameMS.Size = new System.Drawing.Size(117, 15);
            this.lblInstructorNameMS.TabIndex = 14;
            this.lblInstructorNameMS.Text = "Instructor Name :";
            // 
            // btMakeScheduleMS
            // 
            this.btMakeScheduleMS.BackColor = System.Drawing.Color.White;
            this.btMakeScheduleMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMakeScheduleMS.Location = new System.Drawing.Point(359, 73);
            this.btMakeScheduleMS.Name = "btMakeScheduleMS";
            this.btMakeScheduleMS.Size = new System.Drawing.Size(85, 43);
            this.btMakeScheduleMS.TabIndex = 12;
            this.btMakeScheduleMS.Text = "Make Schedule";
            this.btMakeScheduleMS.UseVisualStyleBackColor = false;
            this.btMakeScheduleMS.Click += new System.EventHandler(this.btMakeScheduleMS_Click);
            // 
            // lblCourseNameMS
            // 
            this.lblCourseNameMS.AutoSize = true;
            this.lblCourseNameMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseNameMS.Location = new System.Drawing.Point(12, 74);
            this.lblCourseNameMS.Name = "lblCourseNameMS";
            this.lblCourseNameMS.Size = new System.Drawing.Size(94, 15);
            this.lblCourseNameMS.TabIndex = 13;
            this.lblCourseNameMS.Text = "Course Name";
            // 
            // cbCourseName
            // 
            this.cbCourseName.AllowDrop = true;
            this.cbCourseName.BackColor = System.Drawing.Color.White;
            this.cbCourseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCourseName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbCourseName.ForeColor = System.Drawing.Color.Black;
            this.cbCourseName.FormattingEnabled = true;
            this.cbCourseName.Location = new System.Drawing.Point(131, 73);
            this.cbCourseName.Name = "cbCourseName";
            this.cbCourseName.Size = new System.Drawing.Size(202, 21);
            this.cbCourseName.TabIndex = 11;
            this.cbCourseName.SelectedIndexChanged += new System.EventHandler(this.cbCourseName_SelectedIndexChanged);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.Black;
            this.lblHeading.Location = new System.Drawing.Point(320, 98);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(401, 37);
            this.lblHeading.TabIndex = 18;
            this.lblHeading.Text = "Class Scheduling System";
            // 
            // btgotoform2
            // 
            this.btgotoform2.Location = new System.Drawing.Point(24, 479);
            this.btgotoform2.Name = "btgotoform2";
            this.btgotoform2.Size = new System.Drawing.Size(177, 38);
            this.btgotoform2.TabIndex = 19;
            this.btgotoform2.Text = "instructorGV";
            this.btgotoform2.UseVisualStyleBackColor = true;
            this.btgotoform2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btAddDivisionSize
            // 
            this.btAddDivisionSize.Location = new System.Drawing.Point(24, 163);
            this.btAddDivisionSize.Name = "btAddDivisionSize";
            this.btAddDivisionSize.Size = new System.Drawing.Size(177, 41);
            this.btAddDivisionSize.TabIndex = 20;
            this.btAddDivisionSize.Text = "Add division size";
            this.btAddDivisionSize.UseVisualStyleBackColor = true;
            this.btAddDivisionSize.Click += new System.EventHandler(this.btAddDivisionSize_Click_1);
            // 
            // btAddCurriculum
            // 
            this.btAddCurriculum.Location = new System.Drawing.Point(24, 124);
            this.btAddCurriculum.Name = "btAddCurriculum";
            this.btAddCurriculum.Size = new System.Drawing.Size(177, 33);
            this.btAddCurriculum.TabIndex = 21;
            this.btAddCurriculum.Text = "Add Curriculum";
            this.btAddCurriculum.UseVisualStyleBackColor = true;
            this.btAddCurriculum.Click += new System.EventHandler(this.btAddCurriculum_Click);
            // 
            // gbAddDivisionSize
            // 
            this.gbAddDivisionSize.Controls.Add(this.lblPRooms);
            this.gbAddDivisionSize.Controls.Add(this.cbRooms);
            this.gbAddDivisionSize.Controls.Add(this.btAddDivisioSizeAD);
            this.gbAddDivisionSize.Controls.Add(this.label3);
            this.gbAddDivisionSize.Controls.Add(this.tbDivisionSize);
            this.gbAddDivisionSize.Controls.Add(this.cbYear1);
            this.gbAddDivisionSize.Controls.Add(this.label2);
            this.gbAddDivisionSize.Controls.Add(this.label1);
            this.gbAddDivisionSize.Controls.Add(this.cbDivision1);
            this.gbAddDivisionSize.Font = new System.Drawing.Font("Tahoma", 14F);
            this.gbAddDivisionSize.Location = new System.Drawing.Point(439, 184);
            this.gbAddDivisionSize.Name = "gbAddDivisionSize";
            this.gbAddDivisionSize.Size = new System.Drawing.Size(422, 255);
            this.gbAddDivisionSize.TabIndex = 22;
            this.gbAddDivisionSize.TabStop = false;
            this.gbAddDivisionSize.Text = "add division size";
            // 
            // lblPRooms
            // 
            this.lblPRooms.AutoSize = true;
            this.lblPRooms.Location = new System.Drawing.Point(6, 200);
            this.lblPRooms.Name = "lblPRooms";
            this.lblPRooms.Size = new System.Drawing.Size(166, 23);
            this.lblPRooms.TabIndex = 9;
            this.lblPRooms.Text = "Prefered lab Room";
            // 
            // cbRooms
            // 
            this.cbRooms.FormattingEnabled = true;
            this.cbRooms.Location = new System.Drawing.Point(181, 192);
            this.cbRooms.Name = "cbRooms";
            this.cbRooms.Size = new System.Drawing.Size(121, 31);
            this.cbRooms.TabIndex = 10;
            // 
            // btAddDivisioSizeAD
            // 
            this.btAddDivisioSizeAD.Location = new System.Drawing.Point(334, 95);
            this.btAddDivisioSizeAD.Name = "btAddDivisioSizeAD";
            this.btAddDivisioSizeAD.Size = new System.Drawing.Size(75, 41);
            this.btAddDivisioSizeAD.TabIndex = 6;
            this.btAddDivisioSizeAD.Text = "add";
            this.btAddDivisioSizeAD.UseVisualStyleBackColor = true;
            this.btAddDivisioSizeAD.Click += new System.EventHandler(this.btAddDivisioSizeAD_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label3.Location = new System.Drawing.Point(70, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "size";
            // 
            // tbDivisionSize
            // 
            this.tbDivisionSize.Location = new System.Drawing.Point(181, 145);
            this.tbDivisionSize.Name = "tbDivisionSize";
            this.tbDivisionSize.Size = new System.Drawing.Size(121, 30);
            this.tbDivisionSize.TabIndex = 4;
            this.tbDivisionSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDivisionSize_KeyPress);
            // 
            // cbYear1
            // 
            this.cbYear1.FormattingEnabled = true;
            this.cbYear1.Location = new System.Drawing.Point(181, 101);
            this.cbYear1.Name = "cbYear1";
            this.cbYear1.Size = new System.Drawing.Size(121, 31);
            this.cbYear1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label2.Location = new System.Drawing.Point(64, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label1.Location = new System.Drawing.Point(48, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "division ";
            // 
            // cbDivision1
            // 
            this.cbDivision1.FormattingEnabled = true;
            this.cbDivision1.Location = new System.Drawing.Point(178, 43);
            this.cbDivision1.Name = "cbDivision1";
            this.cbDivision1.Size = new System.Drawing.Size(124, 31);
            this.cbDivision1.TabIndex = 0;
            // 
            // gbAddCurriculm
            // 
            this.gbAddCurriculm.Controls.Add(this.lblCurriculmName);
            this.gbAddCurriculm.Controls.Add(this.textBox1);
            this.gbAddCurriculm.Controls.Add(this.btAddCurriculmAs);
            this.gbAddCurriculm.Controls.Add(this.comboBox1);
            this.gbAddCurriculm.Controls.Add(this.label5);
            this.gbAddCurriculm.Controls.Add(this.label6);
            this.gbAddCurriculm.Controls.Add(this.comboBox2);
            this.gbAddCurriculm.Font = new System.Drawing.Font("Tahoma", 14F);
            this.gbAddCurriculm.Location = new System.Drawing.Point(262, 19);
            this.gbAddCurriculm.Name = "gbAddCurriculm";
            this.gbAddCurriculm.Size = new System.Drawing.Size(62, 45);
            this.gbAddCurriculm.TabIndex = 23;
            this.gbAddCurriculm.TabStop = false;
            this.gbAddCurriculm.Text = "add curriculm";
            // 
            // lblCurriculmName
            // 
            this.lblCurriculmName.AutoSize = true;
            this.lblCurriculmName.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblCurriculmName.Location = new System.Drawing.Point(54, 38);
            this.lblCurriculmName.Name = "lblCurriculmName";
            this.lblCurriculmName.Size = new System.Drawing.Size(57, 23);
            this.lblCurriculmName.TabIndex = 8;
            this.lblCurriculmName.Text = "name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 30);
            this.textBox1.TabIndex = 7;
            // 
            // btAddCurriculmAs
            // 
            this.btAddCurriculmAs.Location = new System.Drawing.Point(290, 114);
            this.btAddCurriculmAs.Name = "btAddCurriculmAs";
            this.btAddCurriculmAs.Size = new System.Drawing.Size(75, 41);
            this.btAddCurriculmAs.TabIndex = 6;
            this.btAddCurriculmAs.Text = "add";
            this.btAddCurriculmAs.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(141, 155);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 31);
            this.comboBox1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label5.Location = new System.Drawing.Point(85, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label6.Location = new System.Drawing.Point(54, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "division ";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(138, 102);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 31);
            this.comboBox2.TabIndex = 0;
            // 
            // gbAddRoom
            // 
            this.gbAddRoom.Controls.Add(this.chbLab);
            this.gbAddRoom.Controls.Add(this.label7);
            this.gbAddRoom.Controls.Add(this.tbSeats);
            this.gbAddRoom.Controls.Add(this.btAddRoomAS);
            this.gbAddRoom.Controls.Add(this.label4);
            this.gbAddRoom.Controls.Add(this.tbRoomName);
            this.gbAddRoom.Location = new System.Drawing.Point(705, 26);
            this.gbAddRoom.Name = "gbAddRoom";
            this.gbAddRoom.Size = new System.Drawing.Size(60, 38);
            this.gbAddRoom.TabIndex = 24;
            this.gbAddRoom.TabStop = false;
            this.gbAddRoom.Text = "Add Room";
            // 
            // chbLab
            // 
            this.chbLab.AutoSize = true;
            this.chbLab.Location = new System.Drawing.Point(116, 133);
            this.chbLab.Name = "chbLab";
            this.chbLab.Size = new System.Drawing.Size(40, 17);
            this.chbLab.TabIndex = 6;
            this.chbLab.Text = "lab";
            this.chbLab.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "number of seats";
            // 
            // tbSeats
            // 
            this.tbSeats.Location = new System.Drawing.Point(100, 89);
            this.tbSeats.Name = "tbSeats";
            this.tbSeats.Size = new System.Drawing.Size(100, 20);
            this.tbSeats.TabIndex = 3;
            this.tbSeats.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSeats_KeyPress);
            // 
            // btAddRoomAS
            // 
            this.btAddRoomAS.Location = new System.Drawing.Point(216, 72);
            this.btAddRoomAS.Name = "btAddRoomAS";
            this.btAddRoomAS.Size = new System.Drawing.Size(75, 23);
            this.btAddRoomAS.TabIndex = 2;
            this.btAddRoomAS.Text = "Add";
            this.btAddRoomAS.UseVisualStyleBackColor = true;
            this.btAddRoomAS.Click += new System.EventHandler(this.btAddRoomAS_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "name";
            // 
            // tbRoomName
            // 
            this.tbRoomName.Location = new System.Drawing.Point(100, 44);
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.Size = new System.Drawing.Size(100, 20);
            this.tbRoomName.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 529);
            this.Controls.Add(this.gbAddRoom);
            this.Controls.Add(this.gbAddCurriculm);
            this.Controls.Add(this.gbAddDivisionSize);
            this.Controls.Add(this.btAddCurriculum);
            this.Controls.Add(this.btAddDivisionSize);
            this.Controls.Add(this.btgotoform2);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.gbMakeSchedule);
            this.Controls.Add(this.gbAddStudent);
            this.Controls.Add(this.gbAddTeacher);
            this.Controls.Add(this.btAddRoom);
            this.Controls.Add(this.btLogout);
            this.Controls.Add(this.btSeeSchedule);
            this.Controls.Add(this.btMakeSchedule);
            this.Controls.Add(this.btAddStudent);
            this.Controls.Add(this.btAddCourse);
            this.Controls.Add(this.btAddTeacher);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbAddTeacher.ResumeLayout(false);
            this.gbAddTeacher.PerformLayout();
            this.gbAddStudent.ResumeLayout(false);
            this.gbAddStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.gbMakeSchedule.ResumeLayout(false);
            this.gbMakeSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.gbAddDivisionSize.ResumeLayout(false);
            this.gbAddDivisionSize.PerformLayout();
            this.gbAddCurriculm.ResumeLayout(false);
            this.gbAddCurriculm.PerformLayout();
            this.gbAddRoom.ResumeLayout(false);
            this.gbAddRoom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddTeacher;
        private System.Windows.Forms.Button btAddCourse;
        private System.Windows.Forms.Button btAddStudent;
        private System.Windows.Forms.Button btMakeSchedule;
        private System.Windows.Forms.Button btSeeSchedule;
        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.Button btAddRoom;
        private System.Windows.Forms.GroupBox gbAddTeacher;
        private System.Windows.Forms.TextBox tbInstructorName;
        private System.Windows.Forms.Label lblInstructorName;
        private System.Windows.Forms.Button btInsertTeacher;
        private System.Windows.Forms.GroupBox gbAddStudent;
        private System.Windows.Forms.Label lblSelectYearAs;
        private System.Windows.Forms.Button btAddStudentAS;
        private System.Windows.Forms.Label lblDivisionAS;
        private System.Windows.Forms.ComboBox CBSelectDivision;
        private System.Windows.Forms.GroupBox gbMakeSchedule;
        private System.Windows.Forms.TextBox tbInstructorNameMS;
        private System.Windows.Forms.Label lblInstructorNameMS;
        private System.Windows.Forms.Button btMakeScheduleMS;
        private System.Windows.Forms.Label lblCourseNameMS;
        private System.Windows.Forms.ComboBox cbCourseName;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.Button btgotoform2;
        private System.Windows.Forms.ComboBox CBSelectYear;
        private System.Windows.Forms.Button btAddDivisionSize;
        private System.Windows.Forms.Button btAddCurriculum;
        private System.Windows.Forms.GroupBox gbAddDivisionSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDivision1;
        private System.Windows.Forms.Button btAddDivisioSizeAD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDivisionSize;
        private System.Windows.Forms.ComboBox cbYear1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbAddCurriculm;
        private System.Windows.Forms.Button btAddCurriculmAs;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblCurriculmName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button generateSchedule;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox gbAddRoom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSeats;
        private System.Windows.Forms.Button btAddRoomAS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRoomName;
        private System.Windows.Forms.CheckBox chbLab;
        private System.Windows.Forms.CheckBox chBIsTA;
        private System.Windows.Forms.Label lblPRooms;
        private System.Windows.Forms.ComboBox cbRooms;
    }
}