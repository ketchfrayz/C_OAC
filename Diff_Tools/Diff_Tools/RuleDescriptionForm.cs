using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diff_Tools
{
    public partial class RuleDescriptionForm : Form
    {
        public RuleDescriptionForm()
        {
            InitializeComponent();
        }

        public string ReturnFrmSelection()
        {
            return ruleDescRichTextBox.Text;
        }

        public bool IsFrmComplete()
        {
            if (ruleDescRichTextBox.Text == "") { return false; }

            return true;
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            string rule = "";
            string displayRule = "";
            if (IsFrmComplete())
            {

                WizardFrmParent.rule.Push(ruleDescRichTextBox.Text);
                WizardFrmParent.currentRule.SetRuleWizard(WizardFrmParent.rule);
                //rule = WizardFrmParent.currentRule.CreateRuleFromStack();
               // displayRule = WizardFrmParent.currentRule.CreateDisplayRule();
                MessageBox.Show("Do you want to submit the rule: " + Environment.NewLine + Environment.NewLine + displayRule, "Rule Confirmation", MessageBoxButtons.YesNo);
            }
        }
    }
}
