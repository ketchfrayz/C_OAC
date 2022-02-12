
namespace Diff_Tools
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            this.ioRevLbl = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.rollbackLbl = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.displayRTB = new System.Windows.Forms.RichTextBox();
            this.apiLB = new System.Windows.Forms.ListBox();
            this.rollBackLV = new System.Windows.Forms.ListView();
            this.addFileLV = new System.Windows.Forms.ListView();
            this.servoLV = new System.Windows.Forms.ListView();
            this.piodLV = new System.Windows.Forms.ListView();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ioRevLbl
            // 
            this.ioRevLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ioRevLbl.Location = new System.Drawing.Point(533, 581);
            this.ioRevLbl.Name = "ioRevLbl";
            this.ioRevLbl.Size = new System.Drawing.Size(300, 61);
            this.ioRevLbl.TabIndex = 20;
            this.ioRevLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ioRevLbl.Visible = false;
            // 
            // Timer1
            // 
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(28, 101);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(62, 13);
            this.Label7.TabIndex = 7;
            this.Label7.Text = "Servo Data";
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.DodgerBlue;
            this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label6.Location = new System.Drawing.Point(6, 99);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(16, 15);
            this.Label6.TabIndex = 6;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(28, 73);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(63, 13);
            this.Label5.TabIndex = 5;
            this.Label5.Text = "PIOD/SIOD";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Chocolate;
            this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label4.Location = new System.Drawing.Point(6, 71);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(16, 15);
            this.Label4.TabIndex = 4;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(28, 45);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(70, 13);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "File Add/Del";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Orange;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2.Location = new System.Drawing.Point(6, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(16, 15);
            this.Label2.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(28, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(85, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "File rolled back";
            // 
            // rollbackLbl
            // 
            this.rollbackLbl.BackColor = System.Drawing.Color.Red;
            this.rollbackLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rollbackLbl.Location = new System.Drawing.Point(6, 16);
            this.rollbackLbl.Name = "rollbackLbl";
            this.rollbackLbl.Size = new System.Drawing.Size(16, 15);
            this.rollbackLbl.TabIndex = 0;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.rollbackLbl);
            this.GroupBox1.Location = new System.Drawing.Point(12, 452);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(190, 134);
            this.GroupBox1.TabIndex = 18;
            this.GroupBox1.TabStop = false;
            // 
            // displayRTB
            // 
            this.displayRTB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayRTB.Location = new System.Drawing.Point(12, 7);
            this.displayRTB.Name = "displayRTB";
            this.displayRTB.ReadOnly = true;
            this.displayRTB.Size = new System.Drawing.Size(518, 439);
            this.displayRTB.TabIndex = 13;
            this.displayRTB.Text = "";
            this.displayRTB.WordWrap = false;
            // 
            // apiLB
            // 
            this.apiLB.BackColor = System.Drawing.SystemColors.Control;
            this.apiLB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiLB.FormattingEnabled = true;
            this.apiLB.HorizontalScrollbar = true;
            this.apiLB.Location = new System.Drawing.Point(536, 470);
            this.apiLB.Name = "apiLB";
            this.apiLB.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.apiLB.Size = new System.Drawing.Size(300, 82);
            this.apiLB.TabIndex = 21;
            // 
            // rollBackLV
            // 
            this.rollBackLV.BackColor = System.Drawing.SystemColors.Control;
            this.rollBackLV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.rollBackLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.rollBackLV.HideSelection = false;
            this.rollBackLV.Location = new System.Drawing.Point(536, 7);
            this.rollBackLV.MultiSelect = false;
            this.rollBackLV.Name = "rollBackLV";
            this.rollBackLV.Size = new System.Drawing.Size(300, 95);
            this.rollBackLV.TabIndex = 22;
            this.rollBackLV.UseCompatibleStateImageBehavior = false;
            this.rollBackLV.View = System.Windows.Forms.View.Details;
            this.rollBackLV.SelectedIndexChanged += new System.EventHandler(this.RollBackLV_SelectedIndexChanged);
            // 
            // addFileLV
            // 
            this.addFileLV.BackColor = System.Drawing.SystemColors.Control;
            this.addFileLV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.addFileLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.addFileLV.HideSelection = false;
            this.addFileLV.Location = new System.Drawing.Point(536, 121);
            this.addFileLV.MultiSelect = false;
            this.addFileLV.Name = "addFileLV";
            this.addFileLV.Size = new System.Drawing.Size(300, 95);
            this.addFileLV.TabIndex = 23;
            this.addFileLV.UseCompatibleStateImageBehavior = false;
            this.addFileLV.View = System.Windows.Forms.View.Details;
            this.addFileLV.SelectedIndexChanged += new System.EventHandler(this.AddFileLV_SelectedIndexChanged);
            // 
            // servoLV
            // 
            this.servoLV.BackColor = System.Drawing.SystemColors.Control;
            this.servoLV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.servoLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.servoLV.HideSelection = false;
            this.servoLV.Location = new System.Drawing.Point(536, 236);
            this.servoLV.MultiSelect = false;
            this.servoLV.Name = "servoLV";
            this.servoLV.Size = new System.Drawing.Size(300, 95);
            this.servoLV.TabIndex = 24;
            this.servoLV.UseCompatibleStateImageBehavior = false;
            this.servoLV.View = System.Windows.Forms.View.Details;
            this.servoLV.SelectedIndexChanged += new System.EventHandler(this.ServoLV_SelectedIndexChanged);
            // 
            // piodLV
            // 
            this.piodLV.BackColor = System.Drawing.SystemColors.Control;
            this.piodLV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.piodLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.piodLV.HideSelection = false;
            this.piodLV.Location = new System.Drawing.Point(536, 351);
            this.piodLV.MultiSelect = false;
            this.piodLV.Name = "piodLV";
            this.piodLV.Size = new System.Drawing.Size(300, 95);
            this.piodLV.TabIndex = 25;
            this.piodLV.UseCompatibleStateImageBehavior = false;
            this.piodLV.View = System.Windows.Forms.View.Details;
            this.piodLV.SelectedIndexChanged += new System.EventHandler(this.PiodLV_SelectedIndexChanged);
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 643);
            this.Controls.Add(this.piodLV);
            this.Controls.Add(this.servoLV);
            this.Controls.Add(this.addFileLV);
            this.Controls.Add(this.rollBackLV);
            this.Controls.Add(this.apiLB);
            this.Controls.Add(this.ioRevLbl);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.displayRTB);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label ioRevLbl;
        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label rollbackLbl;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.RichTextBox displayRTB;
        internal System.Windows.Forms.ListBox apiLB;
        private System.Windows.Forms.ListView rollBackLV;
        private System.Windows.Forms.ListView addFileLV;
        private System.Windows.Forms.ListView servoLV;
        private System.Windows.Forms.ListView piodLV;
    }
}

