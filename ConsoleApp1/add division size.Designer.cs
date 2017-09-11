namespace ConsoleApp1
{
    partial class add_division_size
    {
        /// <summary>
        // Required designer variable.
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
            this.cbRooms = new System.Windows.Forms.ComboBox();
            this.btAddDivisioSizeAD = new System.Windows.Forms.Button();
            this.tbDivisionSize = new System.Windows.Forms.TextBox();
            this.cbYear1 = new System.Windows.Forms.ComboBox();
            this.cbDivision1 = new System.Windows.Forms.ComboBox();
            this.lblPRooms = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbRooms
            // 
            this.cbRooms.FormattingEnabled = true;
            this.cbRooms.Location = new System.Drawing.Point(229, 141);
            this.cbRooms.Name = "cbRooms";
            this.cbRooms.Size = new System.Drawing.Size(136, 21);
            this.cbRooms.TabIndex = 10;
            // 
            // btAddDivisioSizeAD
            // 
            this.btAddDivisioSizeAD.BackColor = System.Drawing.Color.White;
            this.btAddDivisioSizeAD.BackgroundImage = global::ConsoleApp1.Properties.Resources.add1;
            this.btAddDivisioSizeAD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddDivisioSizeAD.Location = new System.Drawing.Point(111, 187);
            this.btAddDivisioSizeAD.Margin = new System.Windows.Forms.Padding(0);
            this.btAddDivisioSizeAD.Name = "btAddDivisioSizeAD";
            this.btAddDivisioSizeAD.Size = new System.Drawing.Size(151, 67);
            this.btAddDivisioSizeAD.TabIndex = 6;
            this.btAddDivisioSizeAD.UseVisualStyleBackColor = false;
            this.btAddDivisioSizeAD.Click += new System.EventHandler(this.btAddDivisioSizeAD_Click);
            // 
            // tbDivisionSize
            // 
            this.tbDivisionSize.Location = new System.Drawing.Point(229, 105);
            this.tbDivisionSize.Name = "tbDivisionSize";
            this.tbDivisionSize.Size = new System.Drawing.Size(136, 20);
            this.tbDivisionSize.TabIndex = 4;
            // 
            // cbYear1
            // 
            this.cbYear1.FormattingEnabled = true;
            this.cbYear1.Location = new System.Drawing.Point(229, 72);
            this.cbYear1.Name = "cbYear1";
            this.cbYear1.Size = new System.Drawing.Size(136, 21);
            this.cbYear1.TabIndex = 3;
            // 
            // cbDivision1
            // 
            this.cbDivision1.FormattingEnabled = true;
            this.cbDivision1.Location = new System.Drawing.Point(229, 37);
            this.cbDivision1.Name = "cbDivision1";
            this.cbDivision1.Size = new System.Drawing.Size(136, 21);
            this.cbDivision1.TabIndex = 0;
            // 
            // lblPRooms
            // 
            this.lblPRooms.AutoSize = true;
            this.lblPRooms.BackColor = System.Drawing.Color.Transparent;
            this.lblPRooms.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblPRooms.Location = new System.Drawing.Point(27, 141);
            this.lblPRooms.Name = "lblPRooms";
            this.lblPRooms.Size = new System.Drawing.Size(192, 23);
            this.lblPRooms.TabIndex = 9;
            this.lblPRooms.Text = "Prefered Lab Room";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(27, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(27, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(27, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Division ";
            // 
            // add_division_size
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ConsoleApp1.Properties.Resources.background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(391, 272);
            this.Controls.Add(this.lblPRooms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbRooms);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btAddDivisioSizeAD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDivision1);
            this.Controls.Add(this.tbDivisionSize);
            this.Controls.Add(this.cbYear1);
            this.DoubleBuffered = true;
            this.Name = "add_division_size";
            this.Text = "Add Department Details";
            this.Load += new System.EventHandler(this.add_division_size_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRooms;
        private System.Windows.Forms.Button btAddDivisioSizeAD;
        private System.Windows.Forms.TextBox tbDivisionSize;
        private System.Windows.Forms.ComboBox cbYear1;
        private System.Windows.Forms.ComboBox cbDivision1;
        private System.Windows.Forms.Label lblPRooms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}