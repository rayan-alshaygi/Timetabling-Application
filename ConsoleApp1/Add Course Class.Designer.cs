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
            this.label9 = new System.Windows.Forms.Label();
            this.tbClassDuration = new System.Windows.Forms.TextBox();
            this.chbLabInstrucctores = new System.Windows.Forms.CheckedListBox();
            this.chbTutorialInstructors = new System.Windows.Forms.CheckedListBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.chbLab = new System.Windows.Forms.CheckBox();
            this.btAddCourseAS = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbcode = new System.Windows.Forms.TextBox();
            this.chbLecture = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chbLectureInstructores = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(12, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 23);
            this.label9.TabIndex = 40;
            this.label9.Text = "class duration";
            // 
            // tbClassDuration
            // 
            this.tbClassDuration.Location = new System.Drawing.Point(372, 125);
            this.tbClassDuration.Name = "tbClassDuration";
            this.tbClassDuration.Size = new System.Drawing.Size(162, 20);
            this.tbClassDuration.TabIndex = 39;
            this.tbClassDuration.TextChanged += new System.EventHandler(this.tbClassDuration_TextChanged);
            this.tbClassDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbClassDuration_KeyPress);
            // 
            // chbLabInstrucctores
            // 
            this.chbLabInstrucctores.FormattingEnabled = true;
            this.chbLabInstrucctores.Location = new System.Drawing.Point(374, 167);
            this.chbLabInstrucctores.Name = "chbLabInstrucctores";
            this.chbLabInstrucctores.Size = new System.Drawing.Size(162, 34);
            this.chbLabInstrucctores.TabIndex = 38;
            // 
            // chbTutorialInstructors
            // 
            this.chbTutorialInstructors.FormattingEnabled = true;
            this.chbTutorialInstructors.Location = new System.Drawing.Point(374, 219);
            this.chbTutorialInstructors.Name = "chbTutorialInstructors";
            this.chbTutorialInstructors.Size = new System.Drawing.Size(162, 34);
            this.chbTutorialInstructors.TabIndex = 37;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.checkBox3.Location = new System.Drawing.Point(16, 229);
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
            this.chbLab.Location = new System.Drawing.Point(16, 174);
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
            this.btAddCourseAS.Location = new System.Drawing.Point(192, 279);
            this.btAddCourseAS.Name = "btAddCourseAS";
            this.btAddCourseAS.Size = new System.Drawing.Size(166, 63);
            this.btAddCourseAS.TabIndex = 43;
            this.btAddCourseAS.UseVisualStyleBackColor = true;
            this.btAddCourseAS.Click += new System.EventHandler(this.btAddCourseAS_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 23);
            this.label2.TabIndex = 45;
            this.label2.Text = "Course Code in English";
            // 
            // tbcode
            // 
            this.tbcode.Location = new System.Drawing.Point(374, 37);
            this.tbcode.Name = "tbcode";
            this.tbcode.Size = new System.Drawing.Size(162, 20);
            this.tbcode.TabIndex = 46;
            // 
            // chbLecture
            // 
            this.chbLecture.AutoSize = true;
            this.chbLecture.BackColor = System.Drawing.Color.Transparent;
            this.chbLecture.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.chbLecture.Location = new System.Drawing.Point(16, 81);
            this.chbLecture.Name = "chbLecture";
            this.chbLecture.Size = new System.Drawing.Size(95, 27);
            this.chbLecture.TabIndex = 47;
            this.chbLecture.Text = "lecture";
            this.chbLecture.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(188, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "Lecture instructor\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(214, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 23);
            this.label3.TabIndex = 49;
            this.label3.Text = "Lab instructor\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(187, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 23);
            this.label4.TabIndex = 50;
            this.label4.Text = "tutorial instructor\r\n";
            // 
            // chbLectureInstructores
            // 
            this.chbLectureInstructores.FormattingEnabled = true;
            this.chbLectureInstructores.Location = new System.Drawing.Point(374, 74);
            this.chbLectureInstructores.Margin = new System.Windows.Forms.Padding(2);
            this.chbLectureInstructores.Name = "chbLectureInstructores";
            this.chbLectureInstructores.Size = new System.Drawing.Size(162, 34);
            this.chbLectureInstructores.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(371, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "please enter digits only";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(540, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "*";
            // 
            // Add_Course_Class
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConsoleApp1.Properties.Resources.background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(565, 366);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chbLectureInstructores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbLecture);
            this.Controls.Add(this.tbcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btAddCourseAS);
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbClassDuration;
        private System.Windows.Forms.CheckedListBox chbLabInstrucctores;
        private System.Windows.Forms.CheckedListBox chbTutorialInstructors;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox chbLab;
        private System.Windows.Forms.Button btAddCourseAS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbcode;
        private System.Windows.Forms.CheckBox chbLecture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chbLectureInstructores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}