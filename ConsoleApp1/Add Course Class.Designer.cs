namespace ConsoleApp1
{
    partial class Add_Course_Class
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
            this.cbLectureInstructor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbClassDuration = new System.Windows.Forms.TextBox();
            this.chbLabInstrucctores = new System.Windows.Forms.CheckedListBox();
            this.chbTutorialInstructors = new System.Windows.Forms.CheckedListBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.chbLab = new System.Windows.Forms.CheckBox();
            this.btAddCourseAS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbLectureInstructor
            // 
            this.cbLectureInstructor.FormattingEnabled = true;
            this.cbLectureInstructor.Location = new System.Drawing.Point(236, 61);
            this.cbLectureInstructor.Name = "cbLectureInstructor";
            this.cbLectureInstructor.Size = new System.Drawing.Size(138, 21);
            this.cbLectureInstructor.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(12, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 23);
            this.label9.TabIndex = 40;
            this.label9.Text = "class duration";
            // 
            // tbClassDuration
            // 
            this.tbClassDuration.Location = new System.Drawing.Point(236, 106);
            this.tbClassDuration.Name = "tbClassDuration";
            this.tbClassDuration.Size = new System.Drawing.Size(138, 20);
            this.tbClassDuration.TabIndex = 39;
            // 
            // chbLabInstrucctores
            // 
            this.chbLabInstrucctores.FormattingEnabled = true;
            this.chbLabInstrucctores.Location = new System.Drawing.Point(185, 151);
            this.chbLabInstrucctores.Name = "chbLabInstrucctores";
            this.chbLabInstrucctores.Size = new System.Drawing.Size(189, 34);
            this.chbLabInstrucctores.TabIndex = 38;
            // 
            // chbTutorialInstructors
            // 
            this.chbTutorialInstructors.FormattingEnabled = true;
            this.chbTutorialInstructors.Location = new System.Drawing.Point(185, 202);
            this.chbTutorialInstructors.Name = "chbTutorialInstructors";
            this.chbTutorialInstructors.Size = new System.Drawing.Size(189, 34);
            this.chbTutorialInstructors.TabIndex = 37;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.checkBox3.Location = new System.Drawing.Point(16, 194);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(104, 27);
            this.checkBox3.TabIndex = 36;
            this.checkBox3.Text = "Tutorial";
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // chbLab
            // 
            this.chbLab.AutoSize = true;
            this.chbLab.BackColor = System.Drawing.Color.Transparent;
            this.chbLab.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.chbLab.Location = new System.Drawing.Point(16, 143);
            this.chbLab.Name = "chbLab";
            this.chbLab.Size = new System.Drawing.Size(63, 27);
            this.chbLab.TabIndex = 35;
            this.chbLab.Text = "Lab";
            this.chbLab.UseVisualStyleBackColor = false;
            this.chbLab.CheckedChanged += new System.EventHandler(this.chbLab_CheckedChanged);
            // 
            // btAddCourseAS
            // 
            this.btAddCourseAS.BackgroundImage = global::ConsoleApp1.Properties.Resources.add2;
            this.btAddCourseAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddCourseAS.Location = new System.Drawing.Point(108, 243);
            this.btAddCourseAS.Name = "btAddCourseAS";
            this.btAddCourseAS.Size = new System.Drawing.Size(166, 63);
            this.btAddCourseAS.TabIndex = 43;
            this.btAddCourseAS.UseVisualStyleBackColor = true;
            this.btAddCourseAS.Click += new System.EventHandler(this.btAddCourseAS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 23);
            this.label1.TabIndex = 44;
            this.label1.Text = "lecture instructor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(1, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 23);
            this.label2.TabIndex = 45;
            this.label2.Text = "Course Code in English";
            // 
            // tbcode
            // 
            this.tbcode.Location = new System.Drawing.Point(238, 23);
            this.tbcode.Name = "tbcode";
            this.tbcode.Size = new System.Drawing.Size(136, 20);
            this.tbcode.TabIndex = 46;
            // 
            // Add_Course_Class
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConsoleApp1.Properties.Resources.background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(386, 332);
            this.Controls.Add(this.tbcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAddCourseAS);
            this.Controls.Add(this.cbLectureInstructor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbClassDuration);
            this.Controls.Add(this.chbLabInstrucctores);
            this.Controls.Add(this.chbTutorialInstructors);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.chbLab);
            this.DoubleBuffered = true;
            this.Name = "Add_Course_Class";
            this.Text = "Add_Course_Class";
            this.Load += new System.EventHandler(this.Add_Course_Class_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLectureInstructor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbClassDuration;
        private System.Windows.Forms.CheckedListBox chbLabInstrucctores;
        private System.Windows.Forms.CheckedListBox chbTutorialInstructors;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox chbLab;
        private System.Windows.Forms.Button btAddCourseAS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbcode;
    }
}