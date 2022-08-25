
namespace Diff_Tools
{
    partial class ExistingForm
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
            this.ruleDGV = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ruleDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ruleDGV
            // 
            this.ruleDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ruleDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ruleDGV.Location = new System.Drawing.Point(12, 12);
            this.ruleDGV.MultiSelect = false;
            this.ruleDGV.Name = "ruleDGV";
            this.ruleDGV.ReadOnly = true;
            this.ruleDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ruleDGV.Size = new System.Drawing.Size(483, 276);
            this.ruleDGV.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ExistingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 334);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ruleDGV);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExistingForm";
            this.Text = "ExistingForm";
            this.Load += new System.EventHandler(this.ExistingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ruleDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ruleDGV;
        private System.Windows.Forms.Button button2;
    }
}