using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Diff_Tools
{
    public partial class WizardFrmParent : Form
    {
        static ControlTypeForm ctrlTypFrm;
        static MachineTypeForm mchTypFrm;
        static AdditionalRulesForm addRlFrm;
        static RuleDescriptionForm ruleDescFrm;
        static Form[] frm;
        string[] frmDescription = { "Select the Control Type(s) for the new rule: ", "Select the Machine Type(s) for the new rule: ", "Select Additional Criteria for the new rule: ", "Add a description for the new rule:"};
        int top = 0;
        int count;
        public static Rule currentRule;
        public static Stack<string> rule;
        public WizardFrmParent()
        {
            ctrlTypFrm = new ControlTypeForm();
            mchTypFrm = new MachineTypeForm();
            addRlFrm = new AdditionalRulesForm();
            ruleDescFrm = new RuleDescriptionForm(); 
            currentRule = new Rule();
            rule = new Stack<string>();
            frm = new Form[4] { ctrlTypFrm, mchTypFrm, addRlFrm, ruleDescFrm };
            count = frm.Count();
            InitializeComponent();
        }

        public void LoadNewForm()
        {            
            frm[top].TopLevel = false;
            frm[top].Dock = DockStyle.Fill;
            this.pnlContent.Controls.Clear();
            this.pnlContent.Controls.Add(frm[top]);
            frm[top].Show();
           
            frmDescriptionLbl.Text = frmDescription[top];
            wizardBackBtn.Enabled = false;
            wizardBackBtn.Visible = false;
            
        }

        public void LoadNextForm()
        {
            frm[top].TopLevel = false;
            frm[top].Dock = DockStyle.Fill;
            this.pnlContent.Controls.Clear();
            this.pnlContent.Controls.Add(frm[top]);
            frmDescriptionLbl.Text = frmDescription[top];
            frm[top].Show();
            //ruleWizardProgressBar.Step = 1;
            //ruleWizardProgressBar.PerformStep();
        }
        
        private void Next()
        {
            if (!CheckFrmsComplete(top))
            {
                return;
            }
            rule.Push(GetFrmsSelections(top));
            top++;
            if (top == 1) { currentRule.CalcLOrM(rule); }
            if (top >= count)
            {
                ruleWizardProgressBar.Step = 1;
                ruleWizardProgressBar.PerformStep();
                string displayRule;
                currentRule.SetRuleWizard(rule);
                currentRule.CreateRuleFromStack();
                displayRule = currentRule.CreateDisplayRule();
                var result = MessageBox.Show(displayRule, "Confirm Rule Add", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    AppendRuleToCSVFile();
                }
                return;
            }
            else
            {
                EnableBackButton();
                EnableNextButton();
                LoadNextForm();
                ruleWizardProgressBar.Step = 1;
                ruleWizardProgressBar.PerformStep();
                if (top + 1 == count)
                {
                    //wizardNextBtn.Enabled = false;
                    //wizardNextBtn.Visible = false;
                    EnableUploadButton();
                }
            }
            if (top <= 0)
            {
                //wizardBackBtn.Enabled = false;
            }
            
        }

        //private void Next()
        //{
        //    top++;
        //    if (top >= count)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        MessageBox.Show(ctrlTypFrm.ReturnFrmSelection());
        //        wizardBackBtn.Enabled = true;
        //        wizardNextBtn.Enabled = true;
        //        LoadNextForm();
        //        if (top + 1 == count)
        //        {
        //            wizardNextBtn.Enabled = false;
        //        }
        //    }
        //    if ( top <= 0)
        //    {
        //        wizardBackBtn.Enabled = false;
        //    }
        //}
        private void EnableUploadButton()
        {
            wizardNextBtn.Visible = false;
            uploadBtn.Visible = true;
            uploadBtn.Location = new Point(425, 10);
        }

        private void EnableNextButton()
        {
            uploadBtn.Visible = false;
            wizardNextBtn.Visible = true;
            wizardNextBtn.Enabled = true;
        }

        private void EnableBackButton()
        {
            wizardBackBtn.Visible = true;
            wizardBackBtn.Enabled = true;
        }

        private void DisableBackButton()
        {
            wizardBackBtn.Visible = false;
            wizardBackBtn.Enabled = false;
        }
        private void Back()
        {
            
            top--;
            if (top <= -1)
            {
                return;
            }
            else
            {
                EnableBackButton();
                EnableNextButton();
                rule.Pop();
                LoadNextForm();
                ruleWizardProgressBar.Step = -1;
                ruleWizardProgressBar.PerformStep();
                if (top - 1 <= -1)
                {
                    DisableBackButton();
                }
            }
            if (top >= count)
            {
                wizardNextBtn.Enabled = false;
                wizardBackBtn.Visible = false;
            }
        }

        private void AppendRuleToCSVFile()
        {
            string filePath = "C:\\Users\\corey\\Documents\\Okuma\\Diff_Tools\\rules.csv";
            File.AppendAllText(filePath, Environment.NewLine + currentRule.GetCompleteRule());
        }
        private bool IsCurrentFormComplete()
        {
            switch (top)
            {
                case 0:
                    if (!ctrlTypFrm.IsFrmComplete())
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        private void WizardFrmParent_Load(object sender, EventArgs e)
        {
            ctrlTypFrm = new ControlTypeForm();
            mchTypFrm = new MachineTypeForm();
            addRlFrm = new AdditionalRulesForm();
            ruleDescFrm = new RuleDescriptionForm();
            frm = new Form[4] { ctrlTypFrm, mchTypFrm, addRlFrm, ruleDescFrm };
            currentRule = new Rule();
            LoadNewForm();
            //Next();
        }

        private void wizardNextBtn_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void wizardBackBtn_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void wizardExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckFrmsComplete(int index) //Need to add conditions for MachineTypeForm and AdditionalRulesForm
        {
            switch (index)
            {
                case 0:
                    return ctrlTypFrm.IsFrmComplete();
                case 1:
                    return mchTypFrm.IsFrmComplete();
                case 2:
                    return addRlFrm.isFrmComplete();
                case 3:
                    return ruleDescFrm.IsFrmComplete();
            }
            return true;
        }

        private string GetFrmsSelections(int index)
        {
            switch (index)
            {
                case 0:
                    return ctrlTypFrm.ReturnFrmSelection();

                case 1:
                    return mchTypFrm.ReturnFrmSelection();
                case 2:
                    return addRlFrm.ReturnFrmSelection();
                case 3:
                    return ruleDescFrm.ReturnFrmSelection();
            }
            return "";
        }

        private void WizardFrmParent_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Dispose();
        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDescriptionLbl_Click(object sender, EventArgs e)
        {

        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            Next();
        }
    }
}
