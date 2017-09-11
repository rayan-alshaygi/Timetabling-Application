namespace ConsoleApp1
{
    partial class Add_Cource
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
            this.label13 = new System.Windows.Forms.Label();
            this.tbCourseCodeArabic = new System.Windows.Forms.TextBox();
            this.tbCourseCodeEnglish = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbNumberOfLevels = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btAddLevel = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbOneLevel = new System.Windows.Forms.GroupBox();
            this.btAddLevelAS = new System.Windows.Forms.Button();
            this.cbYears = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clbDivisions = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbTwoLevels = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbyears1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clbDivisions2 = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbyears2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.clbDivisions1 = new System.Windows.Forms.CheckedListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gbOneLevel.SuspendLayout();
            this.gbTwoLevels.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(34, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(220, 23);
            this.label13.TabIndex = 45;
            this.label13.Text = "Course Code in Arabic";
            // 
            // tbCourseCodeArabic
            // 
            this.tbCourseCodeArabic.Location = new System.Drawing.Point(305, 83);
            this.tbCourseCodeArabic.Name = "tbCourseCodeArabic";
            this.tbCourseCodeArabic.Size = new System.Drawing.Size(181, 20);
            this.tbCourseCodeArabic.TabIndex = 44;
            // 
            // tbCourseCodeEnglish
            // 
            this.tbCourseCodeEnglish.Location = new System.Drawing.Point(305, 49);
            this.tbCourseCodeEnglish.Name = "tbCourseCodeEnglish";
            this.tbCourseCodeEnglish.Size = new System.Drawing.Size(181, 20);
            this.tbCourseCodeEnglish.TabIndex = 43;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(34, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 23);
            this.label11.TabIndex = 42;
            this.label11.Text = "Course Code";
            // 
            // cbNumberOfLevels
            // 
            this.cbNumberOfLevels.FormattingEnabled = true;
            this.cbNumberOfLevels.Location = new System.Drawing.Point(305, 122);
            this.cbNumberOfLevels.Name = "cbNumberOfLevels";
            this.cbNumberOfLevels.Size = new System.Drawing.Size(181, 21);
            this.cbNumberOfLevels.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(36, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 23);
            this.label10.TabIndex = 40;
            this.label10.Text = "Number Of Levels";
            // 
            // btAddLevel
            // 
            this.btAddLevel.BackgroundImage = global::ConsoleApp1.Properties.Resources.add_level1;
            this.btAddLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddLevel.Location = new System.Drawing.Point(166, 154);
            this.btAddLevel.Name = "btAddLevel";
            this.btAddLevel.Size = new System.Drawing.Size(212, 63);
            this.btAddLevel.TabIndex = 39;
            this.btAddLevel.UseVisualStyleBackColor = true;
            this.btAddLevel.Click += new System.EventHandler(this.btAddLevel_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(305, 21);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(181, 20);
            this.tbName.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "Name";
            // 
            // gbOneLevel
            // 
            this.gbOneLevel.BackColor = System.Drawing.Color.Transparent;
            this.gbOneLevel.Controls.Add(this.btAddLevelAS);
            this.gbOneLevel.Controls.Add(this.cbYears);
            this.gbOneLevel.Controls.Add(this.label3);
            this.gbOneLevel.Controls.Add(this.clbDivisions);
            this.gbOneLevel.Controls.Add(this.label4);
            this.gbOneLevel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.gbOneLevel.Location = new System.Drawing.Point(75, 223);
            this.gbOneLevel.Name = "gbOneLevel";
            this.gbOneLevel.Size = new System.Drawing.Size(303, 280);
            this.gbOneLevel.TabIndex = 46;
            this.gbOneLevel.TabStop = false;
            this.gbOneLevel.Text = "Level";
            // 
            // btAddLevelAS
            // 
            this.btAddLevelAS.BackgroundImage = global::ConsoleApp1.Properties.Resources.add2;
            this.btAddLevelAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddLevelAS.Location = new System.Drawing.Point(63, 203);
            this.btAddLevelAS.Name = "btAddLevelAS";
            this.btAddLevelAS.Size = new System.Drawing.Size(164, 61);
            this.btAddLevelAS.TabIndex = 20;
            this.btAddLevelAS.UseVisualStyleBackColor = true;
            // 
            // cbYears
            // 
            this.cbYears.FormattingEnabled = true;
            this.cbYears.Location = new System.Drawing.Point(129, 44);
            this.cbYears.Name = "cbYears";
            this.cbYears.Size = new System.Drawing.Size(159, 31);
            this.cbYears.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(19, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "year";
            // 
            // clbDivisions
            // 
            this.clbDivisions.FormattingEnabled = true;
            this.clbDivisions.Location = new System.Drawing.Point(129, 80);
            this.clbDivisions.Name = "clbDivisions";
            this.clbDivisions.Size = new System.Drawing.Size(159, 104);
            this.clbDivisions.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(19, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "divisions";
            // 
            // gbTwoLevels
            // 
            this.gbTwoLevels.BackColor = System.Drawing.Color.Transparent;
            this.gbTwoLevels.Controls.Add(this.button2);
            this.gbTwoLevels.Controls.Add(this.cbyears1);
            this.gbTwoLevels.Controls.Add(this.label2);
            this.gbTwoLevels.Controls.Add(this.clbDivisions2);
            this.gbTwoLevels.Controls.Add(this.label8);
            this.gbTwoLevels.Controls.Add(this.cbyears2);
            this.gbTwoLevels.Controls.Add(this.label9);
            this.gbTwoLevels.Controls.Add(this.clbDivisions1);
            this.gbTwoLevels.Controls.Add(this.label14);
            this.gbTwoLevels.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.gbTwoLevels.Location = new System.Drawing.Point(12, 223);
            this.gbTwoLevels.Name = "gbTwoLevels";
            this.gbTwoLevels.Size = new System.Drawing.Size(538, 368);
            this.gbTwoLevels.TabIndex = 47;
            this.gbTwoLevels.TabStop = false;
            this.gbTwoLevels.Text = "Level";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::ConsoleApp1.Properties.Resources.add2;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(183, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 52);
            this.button2.TabIndex = 21;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbyears1
            // 
            this.cbyears1.FormattingEnabled = true;
            this.cbyears1.Location = new System.Drawing.Point(77, 24);
            this.cbyears1.Name = "cbyears1";
            this.cbyears1.Size = new System.Drawing.Size(121, 31);
            this.cbyears1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Year2";
            // 
            // clbDivisions2
            // 
            this.clbDivisions2.FormattingEnabled = true;
            this.clbDivisions2.Location = new System.Drawing.Point(319, 175);
            this.clbDivisions2.Name = "clbDivisions2";
            this.clbDivisions2.Size = new System.Drawing.Size(188, 129);
            this.clbDivisions2.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(198, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "Divisions 2";
            // 
            // cbyears2
            // 
            this.cbyears2.FormattingEnabled = true;
            this.cbyears2.Location = new System.Drawing.Point(71, 177);
            this.cbyears2.Name = "cbyears2";
            this.cbyears2.Size = new System.Drawing.Size(121, 31);
            this.cbyears2.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 23);
            this.label9.TabIndex = 4;
            this.label9.Text = "Year1";
            // 
            // clbDivisions1
            // 
            this.clbDivisions1.FormattingEnabled = true;
            this.clbDivisions1.Location = new System.Drawing.Point(319, 24);
            this.clbDivisions1.Name = "clbDivisions1";
            this.clbDivisions1.Size = new System.Drawing.Size(188, 129);
            this.clbDivisions1.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(203, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 23);
            this.label14.TabIndex = 6;
            this.label14.Text = "Divisions 1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::ConsoleApp1.Properties.Resources.add_level2;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(166, 597);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 91);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add_Cource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConsoleApp1.Properties.Resources.background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(562, 698);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbTwoLevels);
            this.Controls.Add(this.gbOneLevel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbCourseCodeArabic);
            this.Controls.Add(this.tbCourseCodeEnglish);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbNumberOfLevels);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btAddLevel);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Add_Cource";
            this.Text = "Add_Cource";
            this.Load += new System.EventHandler(this.Add_Cource_Load);
            this.gbOneLevel.ResumeLayout(false);
            this.gbOneLevel.PerformLayout();
            this.gbTwoLevels.ResumeLayout(false);
            this.gbTwoLevels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbCourseCodeArabic;
        private System.Windows.Forms.TextBox tbCourseCodeEnglish;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbNumberOfLevels;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btAddLevel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbOneLevel;
        private System.Windows.Forms.Button btAddLevelAS;
        private System.Windows.Forms.ComboBox cbYears;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox clbDivisions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbTwoLevels;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbyears1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbDivisions2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbyears2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox clbDivisions1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
    }
}