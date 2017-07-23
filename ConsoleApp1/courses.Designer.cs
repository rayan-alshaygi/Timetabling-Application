namespace ConsoleApp1
{
    partial class courses
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbOneLevel = new System.Windows.Forms.GroupBox();
            this.btAddLevelAS = new System.Windows.Forms.Button();
            this.cbYears = new System.Windows.Forms.ComboBox();
            this.clbDivisions = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btAddLevel = new System.Windows.Forms.Button();
            this.btAddCourseAS = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gbTowLevels = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbyears1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.clbDivisions2 = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbyears2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clbDivisions1 = new System.Windows.Forms.CheckedListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbNumberOfLevels = new System.Windows.Forms.ComboBox();
            this.chbLecture = new System.Windows.Forms.CheckBox();
            this.chbLab = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.chbTutorialInstructors = new System.Windows.Forms.CheckedListBox();
            this.chbLabInstrucctores = new System.Windows.Forms.CheckedListBox();
            this.tbClassDuration = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbLectureInstructor = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbClassName = new System.Windows.Forms.TextBox();
            this.gbOneLevel.SuspendLayout();
            this.gbTowLevels.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(127, 26);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "year";
            // 
            // gbOneLevel
            // 
            this.gbOneLevel.Controls.Add(this.btAddLevelAS);
            this.gbOneLevel.Controls.Add(this.cbYears);
            this.gbOneLevel.Controls.Add(this.label3);
            this.gbOneLevel.Controls.Add(this.clbDivisions);
            this.gbOneLevel.Controls.Add(this.label4);
            this.gbOneLevel.Location = new System.Drawing.Point(15, 236);
            this.gbOneLevel.Name = "gbOneLevel";
            this.gbOneLevel.Size = new System.Drawing.Size(212, 179);
            this.gbOneLevel.TabIndex = 5;
            this.gbOneLevel.TabStop = false;
            this.gbOneLevel.Text = "level";
            this.gbOneLevel.Enter += new System.EventHandler(this.gbOneLevel_Enter);
            // 
            // btAddLevelAS
            // 
            this.btAddLevelAS.Location = new System.Drawing.Point(61, 124);
            this.btAddLevelAS.Name = "btAddLevelAS";
            this.btAddLevelAS.Size = new System.Drawing.Size(75, 23);
            this.btAddLevelAS.TabIndex = 20;
            this.btAddLevelAS.Text = "ok";
            this.btAddLevelAS.UseVisualStyleBackColor = true;
            this.btAddLevelAS.Click += new System.EventHandler(this.btAddLevelAS_Click);
            // 
            // cbYears
            // 
            this.cbYears.FormattingEnabled = true;
            this.cbYears.Location = new System.Drawing.Point(71, 34);
            this.cbYears.Name = "cbYears";
            this.cbYears.Size = new System.Drawing.Size(121, 21);
            this.cbYears.TabIndex = 11;
            // 
            // clbDivisions
            // 
            this.clbDivisions.FormattingEnabled = true;
            this.clbDivisions.Location = new System.Drawing.Point(71, 65);
            this.clbDivisions.Name = "clbDivisions";
            this.clbDivisions.Size = new System.Drawing.Size(120, 49);
            this.clbDivisions.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "divisions";
            // 
            // btAddLevel
            // 
            this.btAddLevel.Location = new System.Drawing.Point(260, 205);
            this.btAddLevel.Name = "btAddLevel";
            this.btAddLevel.Size = new System.Drawing.Size(128, 23);
            this.btAddLevel.TabIndex = 6;
            this.btAddLevel.Text = "Add Level details";
            this.btAddLevel.UseVisualStyleBackColor = true;
            this.btAddLevel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btAddCourseAS
            // 
            this.btAddCourseAS.Location = new System.Drawing.Point(339, 470);
            this.btAddCourseAS.Name = "btAddCourseAS";
            this.btAddCourseAS.Size = new System.Drawing.Size(75, 23);
            this.btAddCourseAS.TabIndex = 7;
            this.btAddCourseAS.Text = "done";
            this.btAddCourseAS.UseVisualStyleBackColor = true;
            this.btAddCourseAS.Click += new System.EventHandler(this.btAddCourseAS_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "label8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(65, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "#of levels";
            // 
            // gbTowLevels
            // 
            this.gbTowLevels.Controls.Add(this.button1);
            this.gbTowLevels.Controls.Add(this.cbyears1);
            this.gbTowLevels.Controls.Add(this.label6);
            this.gbTowLevels.Controls.Add(this.clbDivisions2);
            this.gbTowLevels.Controls.Add(this.label7);
            this.gbTowLevels.Controls.Add(this.cbyears2);
            this.gbTowLevels.Controls.Add(this.label5);
            this.gbTowLevels.Controls.Add(this.clbDivisions1);
            this.gbTowLevels.Controls.Add(this.label12);
            this.gbTowLevels.Location = new System.Drawing.Point(239, 234);
            this.gbTowLevels.Name = "gbTowLevels";
            this.gbTowLevels.Size = new System.Drawing.Size(235, 230);
            this.gbTowLevels.TabIndex = 11;
            this.gbTowLevels.TabStop = false;
            this.gbTowLevels.Text = "level";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cbyears1
            // 
            this.cbyears1.FormattingEnabled = true;
            this.cbyears1.Location = new System.Drawing.Point(71, 117);
            this.cbyears1.Name = "cbyears1";
            this.cbyears1.Size = new System.Drawing.Size(121, 21);
            this.cbyears1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "year2";
            // 
            // clbDivisions2
            // 
            this.clbDivisions2.FormattingEnabled = true;
            this.clbDivisions2.Location = new System.Drawing.Point(71, 147);
            this.clbDivisions2.Name = "clbDivisions2";
            this.clbDivisions2.Size = new System.Drawing.Size(121, 34);
            this.clbDivisions2.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "divisions";
            // 
            // cbyears2
            // 
            this.cbyears2.FormattingEnabled = true;
            this.cbyears2.Location = new System.Drawing.Point(71, 34);
            this.cbyears2.Name = "cbyears2";
            this.cbyears2.Size = new System.Drawing.Size(121, 21);
            this.cbyears2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "year1";
            // 
            // clbDivisions1
            // 
            this.clbDivisions1.FormattingEnabled = true;
            this.clbDivisions1.Location = new System.Drawing.Point(71, 77);
            this.clbDivisions1.Name = "clbDivisions1";
            this.clbDivisions1.Size = new System.Drawing.Size(120, 34);
            this.clbDivisions1.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "divisions";
            // 
            // cbNumberOfLevels
            // 
            this.cbNumberOfLevels.FormattingEnabled = true;
            this.cbNumberOfLevels.Location = new System.Drawing.Point(127, 205);
            this.cbNumberOfLevels.Name = "cbNumberOfLevels";
            this.cbNumberOfLevels.Size = new System.Drawing.Size(106, 21);
            this.cbNumberOfLevels.TabIndex = 12;
            // 
            // chbLecture
            // 
            this.chbLecture.AutoSize = true;
            this.chbLecture.Location = new System.Drawing.Point(68, 52);
            this.chbLecture.Name = "chbLecture";
            this.chbLecture.Size = new System.Drawing.Size(62, 17);
            this.chbLecture.TabIndex = 14;
            this.chbLecture.Text = "Lecture";
            this.chbLecture.UseVisualStyleBackColor = true;
            // 
            // chbLab
            // 
            this.chbLab.AutoSize = true;
            this.chbLab.Location = new System.Drawing.Point(69, 92);
            this.chbLab.Name = "chbLab";
            this.chbLab.Size = new System.Drawing.Size(43, 17);
            this.chbLab.TabIndex = 15;
            this.chbLab.Text = "Lab";
            this.chbLab.UseVisualStyleBackColor = true;
            this.chbLab.CheckedChanged += new System.EventHandler(this.chbLab_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(68, 124);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(62, 17);
            this.checkBox3.TabIndex = 16;
            this.checkBox3.Text = "Tutorial";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // chbTutorialInstructors
            // 
            this.chbTutorialInstructors.FormattingEnabled = true;
            this.chbTutorialInstructors.Location = new System.Drawing.Point(127, 75);
            this.chbTutorialInstructors.Name = "chbTutorialInstructors";
            this.chbTutorialInstructors.Size = new System.Drawing.Size(138, 34);
            this.chbTutorialInstructors.TabIndex = 18;
            this.chbTutorialInstructors.SelectedIndexChanged += new System.EventHandler(this.chbTutorialInstructors_SelectedIndexChanged);
            // 
            // chbLabInstrucctores
            // 
            this.chbLabInstrucctores.FormattingEnabled = true;
            this.chbLabInstrucctores.Location = new System.Drawing.Point(127, 115);
            this.chbLabInstrucctores.Name = "chbLabInstrucctores";
            this.chbLabInstrucctores.Size = new System.Drawing.Size(138, 34);
            this.chbLabInstrucctores.TabIndex = 19;
            // 
            // tbClassDuration
            // 
            this.tbClassDuration.Location = new System.Drawing.Point(127, 155);
            this.tbClassDuration.Name = "tbClassDuration";
            this.tbClassDuration.Size = new System.Drawing.Size(106, 20);
            this.tbClassDuration.TabIndex = 20;
            this.tbClassDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbClassDuration_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "class duration";
            // 
            // cbLectureInstructor
            // 
            this.cbLectureInstructor.FormattingEnabled = true;
            this.cbLectureInstructor.Location = new System.Drawing.Point(127, 48);
            this.cbLectureInstructor.Name = "cbLectureInstructor";
            this.cbLectureInstructor.Size = new System.Drawing.Size(138, 21);
            this.cbLectureInstructor.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(66, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "class name";
            // 
            // tbClassName
            // 
            this.tbClassName.Location = new System.Drawing.Point(127, 182);
            this.tbClassName.Name = "tbClassName";
            this.tbClassName.Size = new System.Drawing.Size(100, 20);
            this.tbClassName.TabIndex = 24;
            // 
            // courses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 505);
            this.Controls.Add(this.tbClassName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbLectureInstructor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbClassDuration);
            this.Controls.Add(this.chbLabInstrucctores);
            this.Controls.Add(this.chbTutorialInstructors);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.chbLab);
            this.Controls.Add(this.chbLecture);
            this.Controls.Add(this.cbNumberOfLevels);
            this.Controls.Add(this.gbTowLevels);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btAddCourseAS);
            this.Controls.Add(this.btAddLevel);
            this.Controls.Add(this.gbOneLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Name = "courses";
            this.Text = "courses";
            this.Load += new System.EventHandler(this.courses_Load);
            this.gbOneLevel.ResumeLayout(false);
            this.gbOneLevel.PerformLayout();
            this.gbTowLevels.ResumeLayout(false);
            this.gbTowLevels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbOneLevel;
        private System.Windows.Forms.Button btAddLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbYears;
        private System.Windows.Forms.CheckedListBox clbDivisions;
        private System.Windows.Forms.Button btAddCourseAS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btAddLevelAS;
        private System.Windows.Forms.GroupBox gbTowLevels;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbyears1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox clbDivisions2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbyears2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox clbDivisions1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbNumberOfLevels;
        private System.Windows.Forms.CheckBox chbLecture;
        private System.Windows.Forms.CheckBox chbLab;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckedListBox chbTutorialInstructors;
        private System.Windows.Forms.CheckedListBox chbLabInstrucctores;
        private System.Windows.Forms.TextBox tbClassDuration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbLectureInstructor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbClassName;
    }
}