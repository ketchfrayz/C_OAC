﻿namespace Diff_Tools
{
    partial class RuleDescriptionForm
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
            this.ruleDescRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ruleDescRichTextBox
            // 
            this.ruleDescRichTextBox.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruleDescRichTextBox.Location = new System.Drawing.Point(43, 116);
            this.ruleDescRichTextBox.Name = "ruleDescRichTextBox";
            this.ruleDescRichTextBox.Size = new System.Drawing.Size(294, 96);
            this.ruleDescRichTextBox.TabIndex = 0;
            this.ruleDescRichTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the text that should show when this rule is detected:";
            // 
            // RuleDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(476, 386);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ruleDescRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RuleDescriptionForm";
            this.Text = "RuleDescriptionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ruleDescRichTextBox;
        private System.Windows.Forms.Label label1;
    }
}