namespace ConsoleApp1
{
    partial class Rooms
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
            this.gbAddRoom = new System.Windows.Forms.GroupBox();
            this.chbLab = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSeats = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.btAddRoomAS = new System.Windows.Forms.Button();
            this.gbAddRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAddRoom
            // 
            this.gbAddRoom.BackColor = System.Drawing.Color.White;
            this.gbAddRoom.Controls.Add(this.chbLab);
            this.gbAddRoom.Controls.Add(this.label7);
            this.gbAddRoom.Controls.Add(this.tbSeats);
            this.gbAddRoom.Controls.Add(this.btAddRoomAS);
            this.gbAddRoom.Controls.Add(this.label4);
            this.gbAddRoom.Controls.Add(this.tbRoomName);
            this.gbAddRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAddRoom.Location = new System.Drawing.Point(0, 0);
            this.gbAddRoom.Margin = new System.Windows.Forms.Padding(6);
            this.gbAddRoom.Name = "gbAddRoom";
            this.gbAddRoom.Padding = new System.Windows.Forms.Padding(6);
            this.gbAddRoom.Size = new System.Drawing.Size(527, 364);
            this.gbAddRoom.TabIndex = 25;
            this.gbAddRoom.TabStop = false;
            this.gbAddRoom.Text = "Add Room";
            // 
            // chbLab
            // 
            this.chbLab.AutoSize = true;
            this.chbLab.Location = new System.Drawing.Point(49, 238);
            this.chbLab.Margin = new System.Windows.Forms.Padding(6);
            this.chbLab.Name = "chbLab";
            this.chbLab.Size = new System.Drawing.Size(80, 29);
            this.chbLab.TabIndex = 6;
            this.chbLab.Text = "Lab";
            this.chbLab.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Seats No:";
            // 
            // tbSeats
            // 
            this.tbSeats.Location = new System.Drawing.Point(188, 152);
            this.tbSeats.Margin = new System.Windows.Forms.Padding(6);
            this.tbSeats.Name = "tbSeats";
            this.tbSeats.Size = new System.Drawing.Size(187, 31);
            this.tbSeats.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name:";
            // 
            // tbRoomName
            // 
            this.tbRoomName.Location = new System.Drawing.Point(188, 58);
            this.tbRoomName.Margin = new System.Windows.Forms.Padding(6);
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.Size = new System.Drawing.Size(187, 31);
            this.tbRoomName.TabIndex = 0;
            // 
            // btAddRoomAS
            // 
            this.btAddRoomAS.BackColor = System.Drawing.Color.White;
            this.btAddRoomAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddRoomAS.Image = global::ConsoleApp1.Properties.Resources.add_icon;
            this.btAddRoomAS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddRoomAS.Location = new System.Drawing.Point(188, 238);
            this.btAddRoomAS.Margin = new System.Windows.Forms.Padding(6);
            this.btAddRoomAS.Name = "btAddRoomAS";
            this.btAddRoomAS.Size = new System.Drawing.Size(113, 51);
            this.btAddRoomAS.TabIndex = 2;
            this.btAddRoomAS.Text = "Add";
            this.btAddRoomAS.UseVisualStyleBackColor = false;
            // 
            // Rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 364);
            this.Controls.Add(this.gbAddRoom);
            this.Name = "Rooms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rooms";
            this.gbAddRoom.ResumeLayout(false);
            this.gbAddRoom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAddRoom;
        private System.Windows.Forms.CheckBox chbLab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSeats;
        private System.Windows.Forms.Button btAddRoomAS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRoomName;
    }
}