
namespace Diff_Tools
{
    partial class ControlTypeForm
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
            this.controlTypeLB = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // controlTypeLB
            // 
            this.controlTypeLB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlTypeLB.FormattingEnabled = true;
            this.controlTypeLB.Items.AddRange(new object[] {
            "P300SA (L)",
            "P300LA",
            "P300S (L)",
            "P300L",
            "P200LA",
            "P200L",
            "P100L",
            "P300SA (M)",
            "P300MA",
            "P300M (M)",
            "P200MA",
            "P200M",
            "P100M"});
            this.controlTypeLB.Location = new System.Drawing.Point(176, 89);
            this.controlTypeLB.Margin = new System.Windows.Forms.Padding(1);
            this.controlTypeLB.Name = "controlTypeLB";
            this.controlTypeLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.controlTypeLB.Size = new System.Drawing.Size(115, 147);
            this.controlTypeLB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select the control type:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 249);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 45);
            this.label2.TabIndex = 4;
            this.label2.Text = "At least 1 control type must be selected";
            // 
            // ControlTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(456, 364);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.controlTypeLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ControlTypeForm";
            this.Text = "Add New Rule Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox controlTypeLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}