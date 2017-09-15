namespace ConsoleApp1
{
    partial class SchedulingSystem
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btAddDivisionSize = new System.Windows.Forms.Button();
            this.btAddRoom = new System.Windows.Forms.Button();
            this.btAddCourse = new System.Windows.Forms.Button();
            this.btAddTeacher = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btSeeSchedule = new System.Windows.Forms.Button();
            this.btMakeSchedule = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 628F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 628F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 628F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 628F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 628F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(829, 543);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImage = global::ConsoleApp1.Properties.Resources.background_1;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btSeeSchedule);
            this.groupBox1.Controls.Add(this.btMakeSchedule);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(825, 539);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btAddDivisionSize);
            this.groupBox2.Controls.Add(this.btAddRoom);
            this.groupBox2.Controls.Add(this.btAddCourse);
            this.groupBox2.Controls.Add(this.btAddTeacher);
            this.groupBox2.Location = new System.Drawing.Point(6, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 282);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateGray;
            this.button1.BackgroundImage = global::ConsoleApp1.Properties.Resources.add_course_class;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(409, 155);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 100);
            this.button1.TabIndex = 33;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btAddDivisionSize
            // 
            this.btAddDivisionSize.BackColor = System.Drawing.Color.SlateGray;
            this.btAddDivisionSize.BackgroundImage = global::ConsoleApp1.Properties.Resources.add_division1;
            this.btAddDivisionSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddDivisionSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddDivisionSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btAddDivisionSize.ForeColor = System.Drawing.Color.White;
            this.btAddDivisionSize.Location = new System.Drawing.Point(16, 19);
            this.btAddDivisionSize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btAddDivisionSize.Name = "btAddDivisionSize";
            this.btAddDivisionSize.Size = new System.Drawing.Size(250, 100);
            this.btAddDivisionSize.TabIndex = 32;
            this.btAddDivisionSize.UseVisualStyleBackColor = false;
            this.btAddDivisionSize.Click += new System.EventHandler(this.btAddDivisionSize_Click);
            // 
            // btAddRoom
            // 
            this.btAddRoom.BackColor = System.Drawing.Color.SlateGray;
            this.btAddRoom.BackgroundImage = global::ConsoleApp1.Properties.Resources.add_room2;
            this.btAddRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddRoom.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btAddRoom.ForeColor = System.Drawing.Color.White;
            this.btAddRoom.Location = new System.Drawing.Point(552, 19);
            this.btAddRoom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btAddRoom.Name = "btAddRoom";
            this.btAddRoom.Size = new System.Drawing.Size(250, 100);
            this.btAddRoom.TabIndex = 31;
            this.btAddRoom.UseVisualStyleBackColor = false;
            this.btAddRoom.Click += new System.EventHandler(this.btAddRoom_Click);
            // 
            // btAddCourse
            // 
            this.btAddCourse.BackColor = System.Drawing.Color.SlateGray;
            this.btAddCourse.BackgroundImage = global::ConsoleApp1.Properties.Resources.add_course;
            this.btAddCourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddCourse.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btAddCourse.ForeColor = System.Drawing.Color.White;
            this.btAddCourse.Location = new System.Drawing.Point(133, 155);
            this.btAddCourse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btAddCourse.Name = "btAddCourse";
            this.btAddCourse.Size = new System.Drawing.Size(250, 100);
            this.btAddCourse.TabIndex = 28;
            this.btAddCourse.UseVisualStyleBackColor = false;
            this.btAddCourse.Click += new System.EventHandler(this.btAddCourse_Click);
            // 
            // btAddTeacher
            // 
            this.btAddTeacher.BackColor = System.Drawing.Color.White;
            this.btAddTeacher.BackgroundImage = global::ConsoleApp1.Properties.Resources.add_teacher1;
            this.btAddTeacher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddTeacher.CausesValidation = false;
            this.btAddTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddTeacher.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btAddTeacher.ForeColor = System.Drawing.Color.White;
            this.btAddTeacher.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btAddTeacher.Location = new System.Drawing.Point(285, 19);
            this.btAddTeacher.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btAddTeacher.Name = "btAddTeacher";
            this.btAddTeacher.Size = new System.Drawing.Size(250, 100);
            this.btAddTeacher.TabIndex = 27;
            this.btAddTeacher.Text = "                   ";
            this.btAddTeacher.UseVisualStyleBackColor = false;
            this.btAddTeacher.Click += new System.EventHandler(this.btAddTeacher_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(132, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(502, 42);
            this.label1.TabIndex = 20;
            this.label1.Text = "Class Scheduling System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btSeeSchedule
            // 
            this.btSeeSchedule.BackColor = System.Drawing.Color.Teal;
            this.btSeeSchedule.BackgroundImage = global::ConsoleApp1.Properties.Resources.view1;
            this.btSeeSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSeeSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSeeSchedule.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btSeeSchedule.ForeColor = System.Drawing.Color.White;
            this.btSeeSchedule.Location = new System.Drawing.Point(415, 379);
            this.btSeeSchedule.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btSeeSchedule.Name = "btSeeSchedule";
            this.btSeeSchedule.Size = new System.Drawing.Size(250, 100);
            this.btSeeSchedule.TabIndex = 30;
            this.btSeeSchedule.UseVisualStyleBackColor = false;
            this.btSeeSchedule.Click += new System.EventHandler(this.btSeeSchedule_Click);
            // 
            // btMakeSchedule
            // 
            this.btMakeSchedule.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btMakeSchedule.BackgroundImage = global::ConsoleApp1.Properties.Resources.generate1;
            this.btMakeSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btMakeSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMakeSchedule.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btMakeSchedule.ForeColor = System.Drawing.Color.White;
            this.btMakeSchedule.Location = new System.Drawing.Point(139, 379);
            this.btMakeSchedule.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btMakeSchedule.Name = "btMakeSchedule";
            this.btMakeSchedule.Size = new System.Drawing.Size(250, 100);
            this.btMakeSchedule.TabIndex = 29;
            this.btMakeSchedule.UseVisualStyleBackColor = false;
            this.btMakeSchedule.Click += new System.EventHandler(this.btMakeSchedule_Click);
            // 
            // SchedulingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConsoleApp1.Properties.Resources.background_1;
            this.ClientSize = new System.Drawing.Size(829, 543);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SchedulingSystem";
            this.Text = "SchedulingSystem";
            this.Load += new System.EventHandler(this.SchedulingSystem_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAddDivisionSize;
        private System.Windows.Forms.Button btAddRoom;
        private System.Windows.Forms.Button btSeeSchedule;
        private System.Windows.Forms.Button btMakeSchedule;
        private System.Windows.Forms.Button btAddCourse;
        private System.Windows.Forms.Button btAddTeacher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
    }
}