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
            this.btAddRoomAS = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.gbAddRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAddRoom
            // 
            this.gbAddRoom.BackColor = System.Drawing.Color.Transparent;
            this.gbAddRoom.Controls.Add(this.chbLab);
            this.gbAddRoom.Controls.Add(this.label7);
            this.gbAddRoom.Controls.Add(this.tbSeats);
            this.gbAddRoom.Controls.Add(this.btAddRoomAS);
            this.gbAddRoom.Controls.Add(this.label4);
            this.gbAddRoom.Controls.Add(this.tbRoomName);
            this.gbAddRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAddRoom.Location = new System.Drawing.Point(0, 0);
            this.gbAddRoom.Name = "gbAddRoom";
            this.gbAddRoom.Size = new System.Drawing.Size(356, 180);
            this.gbAddRoom.TabIndex = 25;
            this.gbAddRoom.TabStop = false;
            this.gbAddRoom.Enter += new System.EventHandler(this.gbAddRoom_Enter);
            // 
            // chbLab
            // 
            this.chbLab.AutoSize = true;
            this.chbLab.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.chbLab.Location = new System.Drawing.Point(145, 91);
            this.chbLab.Name = "chbLab";
            this.chbLab.Size = new System.Drawing.Size(63, 27);
            this.chbLab.TabIndex = 6;
            this.chbLab.Text = "Lab";
            this.chbLab.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(20, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 23);
            this.label7.TabIndex = 4;
            this.label7.Text = "Seats No:";
            // 
            // tbSeats
            // 
            this.tbSeats.Location = new System.Drawing.Point(145, 55);
            this.tbSeats.Name = "tbSeats";
            this.tbSeats.Size = new System.Drawing.Size(154, 20);
            this.tbSeats.TabIndex = 3;
            this.tbSeats.TextChanged += new System.EventHandler(this.tbSeats_TextChanged);
            this.tbSeats.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSeats_KeyPress);
            // 
            // btAddRoomAS
            // 
            this.btAddRoomAS.BackColor = System.Drawing.Color.White;
            this.btAddRoomAS.BackgroundImage = global::ConsoleApp1.Properties.Resources.add2;
            this.btAddRoomAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddRoomAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddRoomAS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddRoomAS.Location = new System.Drawing.Point(112, 124);
            this.btAddRoomAS.Name = "btAddRoomAS";
            this.btAddRoomAS.Size = new System.Drawing.Size(96, 44);
            this.btAddRoomAS.TabIndex = 2;
            this.btAddRoomAS.UseVisualStyleBackColor = false;
            this.btAddRoomAS.Click += new System.EventHandler(this.btAddRoomAS_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name:";
            // 
            // tbRoomName
            // 
            this.tbRoomName.Location = new System.Drawing.Point(145, 16);
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.Size = new System.Drawing.Size(154, 20);
            this.tbRoomName.TabIndex = 0;
            // 
            // Rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConsoleApp1.Properties.Resources.background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(356, 180);
            this.Controls.Add(this.gbAddRoom);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Rooms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Room";
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