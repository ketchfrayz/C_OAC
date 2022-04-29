
namespace Diff_Tools
{
    partial class AdditionalRulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdditionalRulesForm));
            this.criteriaCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.specTypeCB = new System.Windows.Forms.ComboBox();
            this.noCB = new System.Windows.Forms.ComboBox();
            this.bitCB = new System.Windows.Forms.ComboBox();
            this.onOffCB = new System.Windows.Forms.ComboBox();
            this.specTypeLbl = new System.Windows.Forms.Label();
            this.specNoLbl = new System.Windows.Forms.Label();
            this.specBitLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ncLbl = new System.Windows.Forms.Label();
            this.ncTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ncControlTypeLbl = new System.Windows.Forms.Label();
            this.plcCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.plcTB = new System.Windows.Forms.TextBox();
            this.mprmCB = new System.Windows.Forms.ComboBox();
            this.mprmTB = new System.Windows.Forms.TextBox();
            this.specCodeGB = new System.Windows.Forms.GroupBox();
            this.lncGB = new System.Windows.Forms.GroupBox();
            this.conditionalNCcb = new System.Windows.Forms.ComboBox();
            this.lOrHCB = new System.Windows.Forms.CheckBox();
            this.mprmGB = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.plcGB = new System.Windows.Forms.GroupBox();
            this.conditionalPLCCB = new System.Windows.Forms.ComboBox();
            this.lOrHPLCCB = new System.Windows.Forms.CheckBox();
            this.additionalRule = new System.Windows.Forms.Button();
            this.currentCriteriaLB = new System.Windows.Forms.CheckedListBox();
            this.plcufGB = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.plcufVerCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mncGB = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mncNoCB = new System.Windows.Forms.ComboBox();
            this.conditionalMNCCB = new System.Windows.Forms.ComboBox();
            this.lOrHmncCB = new System.Windows.Forms.CheckBox();
            this.mncCtrlTypeLbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mncVerTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.winVersionCB = new System.Windows.Forms.ComboBox();
            this.winVersionGB = new System.Windows.Forms.GroupBox();
            this.winTypeLbl = new System.Windows.Forms.Label();
            this.vsysGB = new System.Windows.Forms.GroupBox();
            this.specCodeGB.SuspendLayout();
            this.lncGB.SuspendLayout();
            this.mprmGB.SuspendLayout();
            this.plcGB.SuspendLayout();
            this.plcufGB.SuspendLayout();
            this.mncGB.SuspendLayout();
            this.winVersionGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // criteriaCB
            // 
            this.criteriaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.criteriaCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaCB.FormattingEnabled = true;
            this.criteriaCB.Location = new System.Drawing.Point(165, 42);
            this.criteriaCB.Name = "criteriaCB";
            this.criteriaCB.Size = new System.Drawing.Size(121, 21);
            this.criteriaCB.TabIndex = 0;
            this.criteriaCB.SelectedIndexChanged += new System.EventHandler(this.criteriaCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select criteria type:";
            // 
            // specTypeCB
            // 
            this.specTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specTypeCB.FormattingEnabled = true;
            this.specTypeCB.Location = new System.Drawing.Point(39, 19);
            this.specTypeCB.Name = "specTypeCB";
            this.specTypeCB.Size = new System.Drawing.Size(57, 21);
            this.specTypeCB.TabIndex = 12;
            // 
            // noCB
            // 
            this.noCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.noCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noCB.FormattingEnabled = true;
            this.noCB.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32"});
            this.noCB.Location = new System.Drawing.Point(121, 19);
            this.noCB.Name = "noCB";
            this.noCB.Size = new System.Drawing.Size(50, 21);
            this.noCB.TabIndex = 13;
            this.noCB.SelectedIndexChanged += new System.EventHandler(this.noCB_SelectedIndexChanged);
            // 
            // bitCB
            // 
            this.bitCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bitCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bitCB.FormattingEnabled = true;
            this.bitCB.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.bitCB.Location = new System.Drawing.Point(210, 19);
            this.bitCB.Name = "bitCB";
            this.bitCB.Size = new System.Drawing.Size(50, 21);
            this.bitCB.TabIndex = 14;
            this.bitCB.SelectedIndexChanged += new System.EventHandler(this.bitCB_SelectedIndexChanged);
            // 
            // onOffCB
            // 
            this.onOffCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.onOffCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onOffCB.FormattingEnabled = true;
            this.onOffCB.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this.onOffCB.Location = new System.Drawing.Point(300, 19);
            this.onOffCB.Name = "onOffCB";
            this.onOffCB.Size = new System.Drawing.Size(50, 21);
            this.onOffCB.TabIndex = 15;
            this.onOffCB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // specTypeLbl
            // 
            this.specTypeLbl.AutoSize = true;
            this.specTypeLbl.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specTypeLbl.Location = new System.Drawing.Point(4, 22);
            this.specTypeLbl.Name = "specTypeLbl";
            this.specTypeLbl.Size = new System.Drawing.Size(34, 13);
            this.specTypeLbl.TabIndex = 16;
            this.specTypeLbl.Text = "Type:";
            // 
            // specNoLbl
            // 
            this.specNoLbl.AutoSize = true;
            this.specNoLbl.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specNoLbl.Location = new System.Drawing.Point(97, 22);
            this.specNoLbl.Name = "specNoLbl";
            this.specNoLbl.Size = new System.Drawing.Size(24, 13);
            this.specNoLbl.TabIndex = 17;
            this.specNoLbl.Text = "No.";
            // 
            // specBitLbl
            // 
            this.specBitLbl.AutoSize = true;
            this.specBitLbl.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specBitLbl.Location = new System.Drawing.Point(187, 22);
            this.specBitLbl.Name = "specBitLbl";
            this.specBitLbl.Size = new System.Drawing.Size(24, 13);
            this.specBitLbl.TabIndex = 18;
            this.specBitLbl.Text = "Bit:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(265, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "State:";
            // 
            // ncLbl
            // 
            this.ncLbl.AutoSize = true;
            this.ncLbl.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ncLbl.Location = new System.Drawing.Point(8, 16);
            this.ncLbl.Name = "ncLbl";
            this.ncLbl.Size = new System.Drawing.Size(34, 13);
            this.ncLbl.TabIndex = 20;
            this.ncLbl.Text = "LNC -";
            // 
            // ncTB
            // 
            this.ncTB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ncTB.Location = new System.Drawing.Point(48, 13);
            this.ncTB.Name = "ncTB";
            this.ncTB.Size = new System.Drawing.Size(54, 21);
            this.ncTB.TabIndex = 21;
            this.ncTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(102, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "-";
            // 
            // ncControlTypeLbl
            // 
            this.ncControlTypeLbl.AutoSize = true;
            this.ncControlTypeLbl.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ncControlTypeLbl.Location = new System.Drawing.Point(118, 16);
            this.ncControlTypeLbl.Name = "ncControlTypeLbl";
            this.ncControlTypeLbl.Size = new System.Drawing.Size(39, 13);
            this.ncControlTypeLbl.TabIndex = 23;
            this.ncControlTypeLbl.Text = "P300A";
            // 
            // plcCB
            // 
            this.plcCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plcCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plcCB.FormattingEnabled = true;
            this.plcCB.Items.AddRange(new object[] {
            "LU2",
            "LU3"});
            this.plcCB.Location = new System.Drawing.Point(17, 17);
            this.plcCB.Name = "plcCB";
            this.plcCB.Size = new System.Drawing.Size(57, 21);
            this.plcCB.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "-";
            // 
            // plcTB
            // 
            this.plcTB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plcTB.Location = new System.Drawing.Point(92, 17);
            this.plcTB.Name = "plcTB";
            this.plcTB.Size = new System.Drawing.Size(54, 21);
            this.plcTB.TabIndex = 26;
            this.plcTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mprmCB
            // 
            this.mprmCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mprmCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mprmCB.FormattingEnabled = true;
            this.mprmCB.Items.AddRange(new object[] {
            "MPRM01A",
            "MPRM02A"});
            this.mprmCB.Location = new System.Drawing.Point(6, 13);
            this.mprmCB.Name = "mprmCB";
            this.mprmCB.Size = new System.Drawing.Size(73, 21);
            this.mprmCB.TabIndex = 27;
            // 
            // mprmTB
            // 
            this.mprmTB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mprmTB.Location = new System.Drawing.Point(100, 13);
            this.mprmTB.Name = "mprmTB";
            this.mprmTB.Size = new System.Drawing.Size(46, 21);
            this.mprmTB.TabIndex = 28;
            this.mprmTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // specCodeGB
            // 
            this.specCodeGB.Controls.Add(this.bitCB);
            this.specCodeGB.Controls.Add(this.specTypeCB);
            this.specCodeGB.Controls.Add(this.noCB);
            this.specCodeGB.Controls.Add(this.onOffCB);
            this.specCodeGB.Controls.Add(this.specTypeLbl);
            this.specCodeGB.Controls.Add(this.specNoLbl);
            this.specCodeGB.Controls.Add(this.specBitLbl);
            this.specCodeGB.Controls.Add(this.label5);
            this.specCodeGB.Location = new System.Drawing.Point(8, 100);
            this.specCodeGB.Name = "specCodeGB";
            this.specCodeGB.Size = new System.Drawing.Size(355, 51);
            this.specCodeGB.TabIndex = 29;
            this.specCodeGB.TabStop = false;
            // 
            // lncGB
            // 
            this.lncGB.Controls.Add(this.conditionalNCcb);
            this.lncGB.Controls.Add(this.lOrHCB);
            this.lncGB.Controls.Add(this.ncControlTypeLbl);
            this.lncGB.Controls.Add(this.ncLbl);
            this.lncGB.Controls.Add(this.ncTB);
            this.lncGB.Controls.Add(this.label2);
            this.lncGB.Location = new System.Drawing.Point(6, 154);
            this.lncGB.Name = "lncGB";
            this.lncGB.Size = new System.Drawing.Size(273, 46);
            this.lncGB.TabIndex = 30;
            this.lncGB.TabStop = false;
            // 
            // conditionalNCcb
            // 
            this.conditionalNCcb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conditionalNCcb.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conditionalNCcb.FormattingEnabled = true;
            this.conditionalNCcb.Items.AddRange(new object[] {
            "",
            "or higher",
            "or lower"});
            this.conditionalNCcb.Location = new System.Drawing.Point(184, 13);
            this.conditionalNCcb.Name = "conditionalNCcb";
            this.conditionalNCcb.Size = new System.Drawing.Size(82, 21);
            this.conditionalNCcb.TabIndex = 31;
            // 
            // lOrHCB
            // 
            this.lOrHCB.AutoSize = true;
            this.lOrHCB.Location = new System.Drawing.Point(163, 16);
            this.lOrHCB.Name = "lOrHCB";
            this.lOrHCB.Size = new System.Drawing.Size(15, 14);
            this.lOrHCB.TabIndex = 31;
            this.lOrHCB.UseVisualStyleBackColor = true;
            this.lOrHCB.CheckedChanged += new System.EventHandler(this.lOrHCB_CheckedChanged);
            // 
            // mprmGB
            // 
            this.mprmGB.Controls.Add(this.label12);
            this.mprmGB.Controls.Add(this.label6);
            this.mprmGB.Controls.Add(this.mprmCB);
            this.mprmGB.Controls.Add(this.mprmTB);
            this.mprmGB.Location = new System.Drawing.Point(35, 328);
            this.mprmGB.Name = "mprmGB";
            this.mprmGB.Size = new System.Drawing.Size(185, 40);
            this.mprmGB.TabIndex = 31;
            this.mprmGB.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(147, 17);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = ".PBU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(84, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "-";
            // 
            // plcGB
            // 
            this.plcGB.Controls.Add(this.conditionalPLCCB);
            this.plcGB.Controls.Add(this.lOrHPLCCB);
            this.plcGB.Controls.Add(this.plcTB);
            this.plcGB.Controls.Add(this.plcCB);
            this.plcGB.Controls.Add(this.label4);
            this.plcGB.Location = new System.Drawing.Point(6, 69);
            this.plcGB.Name = "plcGB";
            this.plcGB.Size = new System.Drawing.Size(259, 43);
            this.plcGB.TabIndex = 32;
            this.plcGB.TabStop = false;
            // 
            // conditionalPLCCB
            // 
            this.conditionalPLCCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conditionalPLCCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conditionalPLCCB.FormattingEnabled = true;
            this.conditionalPLCCB.Items.AddRange(new object[] {
            "",
            "or higher",
            "or lower"});
            this.conditionalPLCCB.Location = new System.Drawing.Point(171, 17);
            this.conditionalPLCCB.Name = "conditionalPLCCB";
            this.conditionalPLCCB.Size = new System.Drawing.Size(82, 21);
            this.conditionalPLCCB.TabIndex = 35;
            // 
            // lOrHPLCCB
            // 
            this.lOrHPLCCB.AutoSize = true;
            this.lOrHPLCCB.Location = new System.Drawing.Point(150, 20);
            this.lOrHPLCCB.Name = "lOrHPLCCB";
            this.lOrHPLCCB.Size = new System.Drawing.Size(15, 14);
            this.lOrHPLCCB.TabIndex = 36;
            this.lOrHPLCCB.UseVisualStyleBackColor = true;
            // 
            // additionalRule
            // 
            this.additionalRule.Image = ((System.Drawing.Image)(resources.GetObject("additionalRule.Image")));
            this.additionalRule.Location = new System.Drawing.Point(303, 33);
            this.additionalRule.Name = "additionalRule";
            this.additionalRule.Size = new System.Drawing.Size(39, 37);
            this.additionalRule.TabIndex = 33;
            this.additionalRule.UseVisualStyleBackColor = true;
            this.additionalRule.Click += new System.EventHandler(this.additionalRule_Click);
            // 
            // currentCriteriaLB
            // 
            this.currentCriteriaLB.CheckOnClick = true;
            this.currentCriteriaLB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCriteriaLB.FormattingEnabled = true;
            this.currentCriteriaLB.Location = new System.Drawing.Point(31, 249);
            this.currentCriteriaLB.Name = "currentCriteriaLB";
            this.currentCriteriaLB.Size = new System.Drawing.Size(323, 52);
            this.currentCriteriaLB.TabIndex = 34;
            // 
            // plcufGB
            // 
            this.plcufGB.Controls.Add(this.label8);
            this.plcufGB.Controls.Add(this.label7);
            this.plcufGB.Controls.Add(this.plcufVerCB);
            this.plcufGB.Controls.Add(this.label3);
            this.plcufGB.Location = new System.Drawing.Point(224, 328);
            this.plcufGB.Margin = new System.Windows.Forms.Padding(1);
            this.plcufGB.Name = "plcufGB";
            this.plcufGB.Padding = new System.Windows.Forms.Padding(1);
            this.plcufGB.Size = new System.Drawing.Size(246, 42);
            this.plcufGB.TabIndex = 35;
            this.plcufGB.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(32, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "PLCUF11";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(171, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = ".PBU";
            // 
            // plcufVerCB
            // 
            this.plcufVerCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plcufVerCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plcufVerCB.FormattingEnabled = true;
            this.plcufVerCB.Items.AddRange(new object[] {
            "*",
            "MA001A"});
            this.plcufVerCB.Location = new System.Drawing.Point(97, 17);
            this.plcufVerCB.Name = "plcufVerCB";
            this.plcufVerCB.Size = new System.Drawing.Size(73, 21);
            this.plcufVerCB.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "-";
            // 
            // mncGB
            // 
            this.mncGB.Controls.Add(this.label9);
            this.mncGB.Controls.Add(this.mncNoCB);
            this.mncGB.Controls.Add(this.conditionalMNCCB);
            this.mncGB.Controls.Add(this.lOrHmncCB);
            this.mncGB.Controls.Add(this.mncCtrlTypeLbl);
            this.mncGB.Controls.Add(this.label10);
            this.mncGB.Controls.Add(this.mncVerTB);
            this.mncGB.Controls.Add(this.label11);
            this.mncGB.Location = new System.Drawing.Point(5, 201);
            this.mncGB.Name = "mncGB";
            this.mncGB.Size = new System.Drawing.Size(308, 42);
            this.mncGB.TabIndex = 36;
            this.mncGB.TabStop = false;
            this.mncGB.Visible = false;
            this.mncGB.Enter += new System.EventHandler(this.mncGB_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(145, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "-";
            // 
            // mncNoCB
            // 
            this.mncNoCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mncNoCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mncNoCB.FormattingEnabled = true;
            this.mncNoCB.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45"});
            this.mncNoCB.Location = new System.Drawing.Point(156, 11);
            this.mncNoCB.Name = "mncNoCB";
            this.mncNoCB.Size = new System.Drawing.Size(59, 21);
            this.mncNoCB.TabIndex = 38;
            // 
            // conditionalMNCCB
            // 
            this.conditionalMNCCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conditionalMNCCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conditionalMNCCB.FormattingEnabled = true;
            this.conditionalMNCCB.Items.AddRange(new object[] {
            "",
            "or higher",
            "or lower"});
            this.conditionalMNCCB.Location = new System.Drawing.Point(239, 11);
            this.conditionalMNCCB.Name = "conditionalMNCCB";
            this.conditionalMNCCB.Size = new System.Drawing.Size(59, 21);
            this.conditionalMNCCB.TabIndex = 36;
            // 
            // lOrHmncCB
            // 
            this.lOrHmncCB.AutoSize = true;
            this.lOrHmncCB.Location = new System.Drawing.Point(222, 14);
            this.lOrHmncCB.Name = "lOrHmncCB";
            this.lOrHmncCB.Size = new System.Drawing.Size(15, 14);
            this.lOrHmncCB.TabIndex = 37;
            this.lOrHmncCB.UseVisualStyleBackColor = true;
            // 
            // mncCtrlTypeLbl
            // 
            this.mncCtrlTypeLbl.AutoSize = true;
            this.mncCtrlTypeLbl.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mncCtrlTypeLbl.Location = new System.Drawing.Point(106, 14);
            this.mncCtrlTypeLbl.Name = "mncCtrlTypeLbl";
            this.mncCtrlTypeLbl.Size = new System.Drawing.Size(39, 13);
            this.mncCtrlTypeLbl.TabIndex = 35;
            this.mncCtrlTypeLbl.Text = "P300A";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "MNC -";
            // 
            // mncVerTB
            // 
            this.mncVerTB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mncVerTB.Location = new System.Drawing.Point(40, 11);
            this.mncVerTB.Name = "mncVerTB";
            this.mncVerTB.Size = new System.Drawing.Size(54, 21);
            this.mncVerTB.TabIndex = 33;
            this.mncVerTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(96, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "-";
            // 
            // winVersionCB
            // 
            this.winVersionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.winVersionCB.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winVersionCB.FormattingEnabled = true;
            this.winVersionCB.Location = new System.Drawing.Point(7, 10);
            this.winVersionCB.Name = "winVersionCB";
            this.winVersionCB.Size = new System.Drawing.Size(73, 21);
            this.winVersionCB.TabIndex = 40;
            this.winVersionCB.SelectedIndexChanged += new System.EventHandler(this.winVersionCB_SelectedIndexChanged);
            // 
            // winVersionGB
            // 
            this.winVersionGB.Controls.Add(this.winTypeLbl);
            this.winVersionGB.Controls.Add(this.winVersionCB);
            this.winVersionGB.Location = new System.Drawing.Point(217, 298);
            this.winVersionGB.Name = "winVersionGB";
            this.winVersionGB.Size = new System.Drawing.Size(254, 37);
            this.winVersionGB.TabIndex = 41;
            this.winVersionGB.TabStop = false;
            this.winVersionGB.Visible = false;
            // 
            // winTypeLbl
            // 
            this.winTypeLbl.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winTypeLbl.Location = new System.Drawing.Point(86, 10);
            this.winTypeLbl.Name = "winTypeLbl";
            this.winTypeLbl.Size = new System.Drawing.Size(159, 21);
            this.winTypeLbl.TabIndex = 41;
            this.winTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vsysGB
            // 
            this.vsysGB.Location = new System.Drawing.Point(312, 167);
            this.vsysGB.Name = "vsysGB";
            this.vsysGB.Size = new System.Drawing.Size(150, 52);
            this.vsysGB.TabIndex = 42;
            this.vsysGB.TabStop = false;
            // 
            // AdditionalRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(476, 386);
            this.Controls.Add(this.vsysGB);
            this.Controls.Add(this.winVersionGB);
            this.Controls.Add(this.mncGB);
            this.Controls.Add(this.plcufGB);
            this.Controls.Add(this.currentCriteriaLB);
            this.Controls.Add(this.additionalRule);
            this.Controls.Add(this.plcGB);
            this.Controls.Add(this.mprmGB);
            this.Controls.Add(this.lncGB);
            this.Controls.Add(this.specCodeGB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.criteriaCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdditionalRulesForm";
            this.Text = "Add New Rule Wizard";
            this.Load += new System.EventHandler(this.AdditionalRulesForm_Load);
            this.specCodeGB.ResumeLayout(false);
            this.specCodeGB.PerformLayout();
            this.lncGB.ResumeLayout(false);
            this.lncGB.PerformLayout();
            this.mprmGB.ResumeLayout(false);
            this.mprmGB.PerformLayout();
            this.plcGB.ResumeLayout(false);
            this.plcGB.PerformLayout();
            this.plcufGB.ResumeLayout(false);
            this.plcufGB.PerformLayout();
            this.mncGB.ResumeLayout(false);
            this.mncGB.PerformLayout();
            this.winVersionGB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox criteriaCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox specTypeCB;
        private System.Windows.Forms.ComboBox noCB;
        private System.Windows.Forms.ComboBox bitCB;
        private System.Windows.Forms.ComboBox onOffCB;
        private System.Windows.Forms.Label specTypeLbl;
        private System.Windows.Forms.Label specNoLbl;
        private System.Windows.Forms.Label specBitLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ncLbl;
        private System.Windows.Forms.TextBox ncTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ncControlTypeLbl;
        private System.Windows.Forms.ComboBox plcCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox plcTB;
        private System.Windows.Forms.ComboBox mprmCB;
        private System.Windows.Forms.TextBox mprmTB;
        private System.Windows.Forms.GroupBox specCodeGB;
        private System.Windows.Forms.GroupBox lncGB;
        private System.Windows.Forms.ComboBox conditionalNCcb;
        private System.Windows.Forms.CheckBox lOrHCB;
        private System.Windows.Forms.GroupBox mprmGB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox plcGB;
        private System.Windows.Forms.Button additionalRule;
        private System.Windows.Forms.CheckedListBox currentCriteriaLB;
        private System.Windows.Forms.ComboBox conditionalPLCCB;
        private System.Windows.Forms.CheckBox lOrHPLCCB;
        private System.Windows.Forms.GroupBox plcufGB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox plcufVerCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox mncGB;
        private System.Windows.Forms.ComboBox mncNoCB;
        private System.Windows.Forms.ComboBox conditionalMNCCB;
        private System.Windows.Forms.CheckBox lOrHmncCB;
        private System.Windows.Forms.Label mncCtrlTypeLbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox mncVerTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox winVersionCB;
        private System.Windows.Forms.GroupBox winVersionGB;
        private System.Windows.Forms.Label winTypeLbl;
        private System.Windows.Forms.GroupBox vsysGB;
    }
}