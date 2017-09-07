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
            this.label1 = new System.Windows.Forms.Label();
            this.btAddDivisionSize = new System.Windows.Forms.Button();
            this.btAddRoom = new System.Windows.Forms.Button();
            this.btSeeSchedule = new System.Windows.Forms.Button();
            this.btMakeSchedule = new System.Windows.Forms.Button();
            this.btAddCourse = new System.Windows.Forms.Button();
            this.btAddTeacher = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(675, 879);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btAddDivisionSize);
            this.groupBox1.Controls.Add(this.btAddRoom);
            this.groupBox1.Controls.Add(this.btSeeSchedule);
            this.groupBox1.Controls.Add(this.btMakeSchedule);
            this.groupBox1.Controls.Add(this.btAddCourse);
            this.groupBox1.Controls.Add(this.btAddTeacher);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 873);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(24, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 63);
            this.label1.TabIndex = 20;
            this.label1.Text = "Class Scheduling System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btAddDivisionSize
            // 
            this.btAddDivisionSize.BackColor = System.Drawing.Color.White;
            this.btAddDivisionSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddDivisionSize.Location = new System.Drawing.Point(158, 280);
            this.btAddDivisionSize.Margin = new System.Windows.Forms.Padding(6);
            this.btAddDivisionSize.Name = "btAddDivisionSize";
            this.btAddDivisionSize.Size = new System.Drawing.Size(354, 79);
            this.btAddDivisionSize.TabIndex = 32;
            this.btAddDivisionSize.Text = "Add division size";
            this.btAddDivisionSize.UseVisualStyleBackColor = false;
            this.btAddDivisionSize.Click += new System.EventHandler(this.btAddDivisionSize_Click);
            // 
            // btAddRoom
            // 
            this.btAddRoom.BackColor = System.Drawing.Color.White;
            this.btAddRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddRoom.Location = new System.Drawing.Point(158, 510);
            this.btAddRoom.Margin = new System.Windows.Forms.Padding(6);
            this.btAddRoom.Name = "btAddRoom";
            this.btAddRoom.Size = new System.Drawing.Size(354, 79);
            this.btAddRoom.TabIndex = 31;
            this.btAddRoom.Text = "Add Room";
            this.btAddRoom.UseVisualStyleBackColor = false;
            this.btAddRoom.Click += new System.EventHandler(this.btAddRoom_Click);
            // 
            // btSeeSchedule
            // 
            this.btSeeSchedule.BackColor = System.Drawing.Color.White;
            this.btSeeSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSeeSchedule.Location = new System.Drawing.Point(158, 740);
            this.btSeeSchedule.Margin = new System.Windows.Forms.Padding(6);
            this.btSeeSchedule.Name = "btSeeSchedule";
            this.btSeeSchedule.Size = new System.Drawing.Size(354, 79);
            this.btSeeSchedule.TabIndex = 30;
            this.btSeeSchedule.Text = "See Schedule";
            this.btSeeSchedule.UseVisualStyleBackColor = false;
            // 
            // btMakeSchedule
            // 
            this.btMakeSchedule.BackColor = System.Drawing.Color.White;
            this.btMakeSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMakeSchedule.Location = new System.Drawing.Point(158, 625);
            this.btMakeSchedule.Margin = new System.Windows.Forms.Padding(6);
            this.btMakeSchedule.Name = "btMakeSchedule";
            this.btMakeSchedule.Size = new System.Drawing.Size(354, 79);
            this.btMakeSchedule.TabIndex = 29;
            this.btMakeSchedule.Text = "Make Schedule";
            this.btMakeSchedule.UseVisualStyleBackColor = false;
            this.btMakeSchedule.Click += new System.EventHandler(this.btMakeSchedule_Click);
            // 
            // btAddCourse
            // 
            this.btAddCourse.BackColor = System.Drawing.Color.White;
            this.btAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddCourse.Location = new System.Drawing.Point(158, 395);
            this.btAddCourse.Margin = new System.Windows.Forms.Padding(6);
            this.btAddCourse.Name = "btAddCourse";
            this.btAddCourse.Size = new System.Drawing.Size(354, 79);
            this.btAddCourse.TabIndex = 28;
            this.btAddCourse.Text = "Add Course";
            this.btAddCourse.UseVisualStyleBackColor = false;
            // 
            // btAddTeacher
            // 
            this.btAddTeacher.BackColor = System.Drawing.Color.White;
            this.btAddTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddTeacher.Location = new System.Drawing.Point(158, 165);
            this.btAddTeacher.Margin = new System.Windows.Forms.Padding(6);
            this.btAddTeacher.Name = "btAddTeacher";
            this.btAddTeacher.Size = new System.Drawing.Size(354, 79);
            this.btAddTeacher.TabIndex = 27;
            this.btAddTeacher.Text = "Add Teacher";
            this.btAddTeacher.UseVisualStyleBackColor = false;
            this.btAddTeacher.Click += new System.EventHandler(this.btAddTeacher_Click_1);
            // 
            // SchedulingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 879);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SchedulingSystem";
            this.Text = "SchedulingSystem";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}