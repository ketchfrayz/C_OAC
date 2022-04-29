
namespace Diff_Tools
{
    partial class WizardFrmParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardFrmParent));
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.wizardNextBtn = new System.Windows.Forms.Button();
            this.wizardExitBtn = new System.Windows.Forms.Button();
            this.wizardBackBtn = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.frmDescriptionLbl = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.ruleWizardProgressBar = new System.Windows.Forms.ProgressBar();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.pnlNavigation.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNavigation.Controls.Add(this.uploadBtn);
            this.pnlNavigation.Controls.Add(this.wizardNextBtn);
            this.pnlNavigation.Controls.Add(this.wizardExitBtn);
            this.pnlNavigation.Controls.Add(this.wizardBackBtn);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 332);
            this.pnlNavigation.Margin = new System.Windows.Forms.Padding(1);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(486, 63);
            this.pnlNavigation.TabIndex = 0;
            // 
            // wizardNextBtn
            // 
            this.wizardNextBtn.Image = ((System.Drawing.Image)(resources.GetObject("wizardNextBtn.Image")));
            this.wizardNextBtn.Location = new System.Drawing.Point(425, 15);
            this.wizardNextBtn.Margin = new System.Windows.Forms.Padding(1);
            this.wizardNextBtn.Name = "wizardNextBtn";
            this.wizardNextBtn.Size = new System.Drawing.Size(51, 29);
            this.wizardNextBtn.TabIndex = 2;
            this.wizardNextBtn.UseVisualStyleBackColor = true;
            this.wizardNextBtn.Click += new System.EventHandler(this.wizardNextBtn_Click);
            // 
            // wizardExitBtn
            // 
            this.wizardExitBtn.Image = ((System.Drawing.Image)(resources.GetObject("wizardExitBtn.Image")));
            this.wizardExitBtn.Location = new System.Drawing.Point(225, 15);
            this.wizardExitBtn.Margin = new System.Windows.Forms.Padding(1);
            this.wizardExitBtn.Name = "wizardExitBtn";
            this.wizardExitBtn.Size = new System.Drawing.Size(51, 29);
            this.wizardExitBtn.TabIndex = 1;
            this.wizardExitBtn.UseVisualStyleBackColor = true;
            this.wizardExitBtn.Click += new System.EventHandler(this.wizardExitBtn_Click);
            // 
            // wizardBackBtn
            // 
            this.wizardBackBtn.Image = ((System.Drawing.Image)(resources.GetObject("wizardBackBtn.Image")));
            this.wizardBackBtn.Location = new System.Drawing.Point(10, 15);
            this.wizardBackBtn.Margin = new System.Windows.Forms.Padding(1);
            this.wizardBackBtn.Name = "wizardBackBtn";
            this.wizardBackBtn.Size = new System.Drawing.Size(51, 29);
            this.wizardBackBtn.TabIndex = 0;
            this.wizardBackBtn.UseVisualStyleBackColor = true;
            this.wizardBackBtn.Click += new System.EventHandler(this.wizardBackBtn_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.ruleWizardProgressBar);
            this.pnlLeft.Controls.Add(this.pictureBox1);
            this.pnlLeft.Controls.Add(this.frmDescriptionLbl);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(1);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(99, 332);
            this.pnlLeft.TabIndex = 1;
            this.pnlLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLeft_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 94);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmDescriptionLbl
            // 
            this.frmDescriptionLbl.Location = new System.Drawing.Point(4, 217);
            this.frmDescriptionLbl.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.frmDescriptionLbl.Name = "frmDescriptionLbl";
            this.frmDescriptionLbl.Size = new System.Drawing.Size(88, 67);
            this.frmDescriptionLbl.TabIndex = 0;
            this.frmDescriptionLbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.frmDescriptionLbl.Click += new System.EventHandler(this.frmDescriptionLbl_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(99, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(1);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(387, 332);
            this.pnlContent.TabIndex = 2;
            // 
            // ruleWizardProgressBar
            // 
            this.ruleWizardProgressBar.Enabled = false;
            this.ruleWizardProgressBar.Location = new System.Drawing.Point(2, 292);
            this.ruleWizardProgressBar.MarqueeAnimationSpeed = 0;
            this.ruleWizardProgressBar.Maximum = 4;
            this.ruleWizardProgressBar.Name = "ruleWizardProgressBar";
            this.ruleWizardProgressBar.Size = new System.Drawing.Size(94, 23);
            this.ruleWizardProgressBar.Step = 1;
            this.ruleWizardProgressBar.TabIndex = 3;
            // 
            // uploadBtn
            // 
            this.uploadBtn.Image = ((System.Drawing.Image)(resources.GetObject("uploadBtn.Image")));
            this.uploadBtn.Location = new System.Drawing.Point(322, 10);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(36, 40);
            this.uploadBtn.TabIndex = 3;
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Visible = false;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // WizardFrmParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 395);
            this.ControlBox = false;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlNavigation);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "WizardFrmParent";
            this.Text = "WizardFrmParent";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WizardFrmParent_FormClosed);
            this.Load += new System.EventHandler(this.WizardFrmParent_Load);
            this.pnlNavigation.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button wizardNextBtn;
        private System.Windows.Forms.Button wizardExitBtn;
        private System.Windows.Forms.Button wizardBackBtn;
        private System.Windows.Forms.Label frmDescriptionLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar ruleWizardProgressBar;
        private System.Windows.Forms.Button uploadBtn;
    }
}