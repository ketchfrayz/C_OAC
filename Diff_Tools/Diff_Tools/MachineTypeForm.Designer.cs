
namespace Diff_Tools
{
    partial class MachineTypeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.machineTypeLB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select the machine type:";
            // 
            // machineTypeLB
            // 
            this.machineTypeLB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.machineTypeLB.FormattingEnabled = true;
            this.machineTypeLB.Items.AddRange(new object[] {
            "ANY"});
            this.machineTypeLB.Location = new System.Drawing.Point(176, 89);
            this.machineTypeLB.Margin = new System.Windows.Forms.Padding(1);
            this.machineTypeLB.Name = "machineTypeLB";
            this.machineTypeLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.machineTypeLB.Size = new System.Drawing.Size(115, 147);
            this.machineTypeLB.TabIndex = 5;
            this.machineTypeLB.SelectedIndexChanged += new System.EventHandler(this.machineTypeLB_SelectedIndexChanged);
            // 
            // MachineTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(456, 364);
            this.Controls.Add(this.machineTypeLB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MachineTypeForm";
            this.Text = "Add New Rule Wizard";
            this.Activated += new System.EventHandler(this.MachineTypeForm_Activated);
            this.Load += new System.EventHandler(this.MachineTypeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox machineTypeLB;
    }
}