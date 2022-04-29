using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diff_Tools
{
    public partial class AdditionalRulesForm : Form
    {
        static string[] latheCriteria = { "LNC", "PLC", "SPEC CODE", "WIN VERSION", "VSYS" };
        static string[] mcCriteria = { "MNC", "PLC", "SPEC CODE", "WIN VERSION", "VSYS", "MPRM", "PLTUA", "PLCUF" };
        static string[] mcSpecType = { "NC1", "NCB1", "PLC1", "PLC2" };
        static string[] latheSpecType = { "NC1", "NCB1", "NCB2", "PLC1", "PLC2", "PLC3" };
        static string[] lathePLC = { "LU2", "LU3" };
        static string[] mcPLC = { "MA2", "MA3" };
        static string[] winVersionP100 = { "1.4.0.E" };
        static string[] winVersionP200 = { "2.4.0.E" };
        static string[] winVersionP200A = { "2.4.0.E", "5.0.0.E", "6.0.0.P", "6.0.0.U", "6.0.1.P", "6.0.1.U", "6.1.0.P", "6.1.0.U" };
        static string[] winVersionP300A = { "7.0.0.P", "7.0.0.U", "7.1.0.P", "7.1.0.U", "8.0.0.E" };
        static string[] winDescriptionP300A = { "Windows 7 Pro", "Windows 7 Ultimate", "Windows 7 Pro SP1", "Windows 7 Pro Ultimate", "Windows 10" };
        static ArrayList criteriaArrayList = new ArrayList();
        public AdditionalRulesForm()
        {
            InitializeComponent();
        }

        private void bitCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdditionalRulesForm_Load(object sender, EventArgs e)
        {
            HideRuleControls();
            PopulateCriteriaList(WizardFrmParent.currentRule.returnLOrM());
            PopulateWinVersionList(WizardFrmParent.currentRule.GetControlType());
        }

        private void PopulateWinVersionList(string controlType)
        {
            string temp = "";
            if(controlType.Length == 5)
            {
                temp = controlType.Substring(0, 4);
            }

            if(controlType.Length == 6)
            {
                temp = controlType.Substring(0, 4) + "A";
            }
            switch (temp)
            {
                case "P100":
                    winVersionCB.Items.AddRange(winVersionP100);
                    break;
                case "P200":
                    winVersionCB.Items.AddRange(winVersionP200);
                    break;
                case "P200A":
                    winVersionCB.Items.AddRange(winVersionP200A);
                    break;
                case "P300":
                    winVersionCB.Items.AddRange(winVersionP200A);
                    break;
                case "P300A":
                    winVersionCB.Items.AddRange(winVersionP300A);
                    break;
            }
        }

        private void noCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void ShowSelectedControls(string ruleType)
        {
            switch (ruleType)
            {
                case "LNC":
                    ClearLNCControls();
                    lncGB.Location = new Point(35, 100);
                    lncGB.Visible = true;
                    return;

                case "MNC":
                    ClearMNCControls();
                    mncGB.Location = new Point(35, 100);
                    mncGB.Visible = true;
                    return;
                case "PLC":
                    ClearPLCControls();
                    plcGB.Location = new Point(35, 100);
                    plcGB.Visible = true;
                    return;
                case "SPEC CODE":
                    ClearSpecCodeControls();
                    specCodeGB.Location = new Point(25, 100);
                    specCodeGB.Visible = true;
                    return;
                case "MPRM":
                    ClearMprmControls();
                    mprmGB.Location = new Point(35, 100);
                    mprmGB.Visible = true;
                    return;
                case "PLCUF":
                    ClearPlcufControls();
                    plcufGB.Location = new Point(35, 100);
                    plcufGB.Visible = true;
                    return;
                case "WIN VERSION":
                    ClearWinVersionControls();
                    winVersionGB.Location = new Point(35, 100);
                    winVersionGB.Visible = true;
                    return;
                
                
            }
            return;
        }

        private void HideRuleControls()
        {
             lncGB.Visible = false;
            mncGB.Visible = false;
             plcGB.Visible = false;
            mprmGB.Visible = false;
            specCodeGB.Visible = false;
            plcufGB.Visible = false;
            winVersionGB.Visible = false;
        }

        private void criteriaCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideRuleControls();
            if (criteriaCB.SelectedIndex == -1)
            {
                return;
            }
            ShowSelectedControls(criteriaCB.SelectedItem.ToString());
        }

        private void PopulateCriteriaList(string lOrMC)
        {
            plcCB.Items.Clear();
            if (lOrMC == "L")
            {
                criteriaCB.Items.AddRange(latheCriteria);
                specTypeCB.Items.AddRange(latheSpecType);
                plcCB.Items.AddRange(lathePLC);
              
            }

            if (lOrMC == "M")
            {
                criteriaCB.Items.AddRange(mcCriteria);
                specTypeCB.Items.AddRange(mcSpecType);
                plcCB.Items.AddRange(mcPLC);
            }
        }

        private void additionalRule_Click(object sender, EventArgs e)
        {
            //HideRuleControls();
            //currentCriteriaLB.Items.Add("test", true);
            AddCriteriaToLB();
            
        }
        
        private void AddCriteriaToLB()
        {
            switch (criteriaCB.SelectedItem.ToString())
            {
                case "LNC":
                    if (IsLNCInputCompleteSub() == true)
                    {
                        AddCriteriaLNCSub();
                        criteriaCB.SelectedIndex = -1;
                    }
                    break;
                case "MNC":
                    if (ISMNCInputCompleteSub() == true)
                    {
                        AddCriteriaMNCSub();
                        criteriaCB.SelectedIndex = -1;
                    }
                    break;
                case "PLC":
                    if (IsPLCInputCompleteSub() == true)
                    {
                        AddCriteriaPLCSub();
                        criteriaCB.SelectedIndex = -1;
                    }
                    break;
                case "SPEC CODE":
                    if (IsSPECCODEInputCompleteSub() == true)
                    {
                        AddCriteriaSpecCodeSub();
                        criteriaCB.SelectedIndex = -1;
                    }
                    break;
                case "MPRM":
                    if (IsMPRMInputCompleteSub() == true)
                    {
                        AddCriteriaMprmSub();
                        criteriaCB.SelectedIndex = -1;
                    }
                    break;
                case "PLCUF":
                    if (IsPLCUFInputCompleteSub() == true)
                    {
                        AddCriteriaPLCUFSub();
                        criteriaCB.SelectedIndex = -1;
                    }
                    break;
                case "WIN VERSION":
                    if (IsWinVersionInputCompleteSub() == true)
                    {
                        AddCriteriaWinVersionSub();
                        criteriaCB.SelectedIndex= -1; 
                    }
                    break;

            }
            
        }

        private void AddCriteriaLNCSub()
        {
            string tempArrayListRule = "";
            if (lOrHCB.Checked == false)
            {
                tempArrayListRule = "[NC]=LNC-" + ncTB.Text + "-" + ncControlTypeLbl.Text;
                criteriaArrayList.Add(tempArrayListRule);
                currentCriteriaLB.Items.Add(tempArrayListRule, CheckState.Checked);
                return;
            }
            string conditionalNC = conditionalNCcb.SelectedItem.ToString();
            tempArrayListRule = conditionalNC == "or higher" ? "[NC]≥LNC-" : "[NC]≤LNC-";
            tempArrayListRule += ncTB.Text + "-" + ncControlTypeLbl.Text;
            criteriaArrayList.Add(tempArrayListRule);
            currentCriteriaLB.Items.Add(tempArrayListRule, CheckState.Checked);
        }

        private void AddCriteriaMNCSub()
        {
            string tempArrayListRule = "";
            
            if (lOrHmncCB.Checked == false)
            {
                tempArrayListRule = "[NC]=MNC-" + mncVerTB.Text + "-" + mncCtrlTypeLbl.Text;
                tempArrayListRule += mncNoCB.SelectedIndex != -1 ? "-" + mncNoCB.SelectedItem.ToString() :"";
                criteriaArrayList.Add(tempArrayListRule);
                currentCriteriaLB.Items.Add(tempArrayListRule, CheckState.Checked);
                return;
            }
            string conditionalNC = conditionalMNCCB.SelectedItem.ToString();
            tempArrayListRule = conditionalNC == "or higher" ? "[NC]≥MNC-" : "[NC]≤MNC-";
            tempArrayListRule += mncVerTB.Text + "-" + mncCtrlTypeLbl.Text;
            tempArrayListRule += mncNoCB.SelectedIndex != -1 ? "-" + mncNoCB.SelectedItem.ToString() : "";
            criteriaArrayList.Add(tempArrayListRule);
            //tempRule = "NC : MNC-" + mncVerTB.Text + "-" + mncCtrlTypeLbl.Text;
            //tempRule += mncNoCB.SelectedIndex == -1 ? "-" +  
            currentCriteriaLB.Items.Add(tempArrayListRule, CheckState.Checked);
        }

        private void AddCriteriaPLCSub()
        {
            string tempArrayListRule = "";
            if (lOrHPLCCB.Checked == false)
            {
                tempArrayListRule = "[PLC]=" + plcCB.SelectedItem.ToString() + "-" + plcTB.Text;
                currentCriteriaLB.Items.Add(tempArrayListRule, CheckState.Checked);
                criteriaArrayList.Add(tempArrayListRule);
                return;
            }
            string conditionalPLC = conditionalPLCCB.SelectedItem.ToString();
            tempArrayListRule = conditionalPLC == "or higher" ? "[PLC]≥" : "[PLC]≤";
            tempArrayListRule += plcCB.SelectedItem.ToString() + "-" + plcTB.Text;
            currentCriteriaLB.Items.Add(tempArrayListRule, CheckState.Checked);
            criteriaArrayList.Add(tempArrayListRule);
        }

        private void AddCriteriaSpecCodeSub()
        {
            criteriaArrayList.Add("[SPEC CODE]=" + specTypeCB.SelectedItem.ToString() + ":" + noCB.SelectedItem.ToString() + ":" + bitCB.SelectedItem.ToString() + ":" + onOffCB.SelectedItem.ToString());
            currentCriteriaLB.Items.Add("[SPEC CODE] = " + specTypeCB.SelectedItem.ToString() + " : No. " + noCB.SelectedItem.ToString() + " : Bit " + bitCB.SelectedItem.ToString() + " : " + onOffCB.SelectedItem.ToString(), CheckState.Checked);
        }

        private void AddCriteriaMprmSub()
        {
            criteriaArrayList.Add("[MPRM]=" + mprmCB.SelectedItem.ToString() + "-" + mprmTB.Text + ".PBU");
            currentCriteriaLB.Items.Add ("[MPRM] = " + mprmCB.SelectedItem.ToString() + "-" + mprmTB.Text + ".PBU", CheckState.Checked);
        }
        private void AddCriteriaWinVersionSub()
        {
            criteriaArrayList.Add("[WINVERSION] =" + winVersionCB.SelectedItem.ToString());
            currentCriteriaLB.Items.Add("[WINVERSION] = " + winVersionCB.SelectedItem.ToString(), CheckState.Checked);
        }
        private void AddCriteriaPLCUFSub()
        {
            criteriaArrayList.Add("[PLCUF]=PLCUF11-" + plcufVerCB.SelectedItem.ToString() + ".PBU");
        }

        private bool IsLNCInputCompleteSub()
        {
            if (ncTB.Text == "")
            {
                return false;
            }

            if (lOrHCB.Checked == true)
            {
                if (conditionalNCcb.SelectedIndex == -1 || conditionalNCcb.SelectedIndex == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ISMNCInputCompleteSub()
        {
            if (mncVerTB.Text == "")
            {
                return false;
            }

            if (lOrHmncCB.Checked == true)
            {
                if (conditionalMNCCB.SelectedIndex == -1 || conditionalMNCCB.SelectedIndex == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsPLCInputCompleteSub()
        {
            if (plcCB.SelectedIndex == -1)
            {
                return false;
            }

            if (plcTB.Text == "")
            {
                return false;
            }

            if (lOrHPLCCB.Checked == true)
            {
                if (conditionalPLCCB.SelectedIndex == -1 || conditionalPLCCB.SelectedIndex == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSPECCODEInputCompleteSub()
        {
            if (specTypeCB.SelectedIndex == -1)
            {
                return false;
            }

            if (noCB.SelectedIndex == -1)
            {
                return false;
            }

            if (bitCB.SelectedIndex == -1)
            {
                return false;
            }

            if (onOffCB.SelectedIndex == -1)
            {
                return false;
            }

            return true;
        }

        private bool IsPLCUFInputCompleteSub()
        {
            if (plcufVerCB.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private bool IsMPRMInputCompleteSub()
        {
            if (mprmCB.SelectedIndex == -1)
            {
                return false;
            }

            if (mprmTB.Text == "")
            {
                return false;
            }
            return true;
        }

        private bool IsWinVersionInputCompleteSub()
        {
            if (winVersionCB.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private void ClearWinVersionControls()
        {
            winVersionCB.SelectedIndex = -1;
            winTypeLbl.Text = "";
        }
        private void ClearLNCControls()
        {
            ncTB.Text = "";
            lOrHCB.CheckState = CheckState.Unchecked;
            conditionalNCcb.SelectedIndex = -1;
        }
        private void ClearMNCControls()
        {
            mncVerTB.Text = "";
            mncNoCB.SelectedIndex = -1;
            lOrHmncCB.CheckState = CheckState.Unchecked;
            conditionalMNCCB.SelectedIndex = -1;
        }

        private void ClearPLCControls()
        {
            plcCB.SelectedIndex = -1;
            plcTB.Text = "";
            lOrHPLCCB.Checked = false;
            conditionalPLCCB.SelectedIndex = -1;
        }

        private void ClearSpecCodeControls()
        {
            specTypeCB.SelectedIndex = -1;
            noCB.SelectedIndex = -1;
            bitCB.SelectedIndex = -1;
            onOffCB.SelectedIndex = -1;
        }

        private void ClearMprmControls()
        {
            mprmCB.SelectedIndex = -1;
            mprmTB.Text = "";
        }

        private void ClearPlcufControls()
        {
            plcufVerCB.SelectedIndex = -1;
        }

        public string ReturnFrmSelection()
        {
            string tempRule = "";
            if (currentCriteriaLB.Items.Count == 1)
            {

                return criteriaArrayList[0].ToString();
                
            }
            for (var i = 0; i < criteriaArrayList.Count; i++)
            {
                if ( i == criteriaArrayList.Count - 1)
                {
                    tempRule += criteriaArrayList[i].ToString();
                    return tempRule;
                }
                tempRule += criteriaArrayList[i].ToString() + "|";
            }
            return "";
        }
        private void mncGB_Enter(object sender, EventArgs e)
        {

        }

        public bool isFrmComplete()
        {
            if (currentCriteriaLB.CheckedItems.Count == 0)
            {
                return false;
            }
            // WizardFrmParent.rule.Push(OutputCriteriaToRule());
            return true;
        }

        private void winVersionCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (winVersionCB.SelectedIndex != -1)
            {
                switch (winVersionCB.SelectedItem.ToString())
                {
                    case "1.4.0.E":
                        winTypeLbl.Text = "Windows XP SP3";
                        break;
                    case "2.4.0.E":
                        winTypeLbl.Text = "Windows XP SP3";
                        break;
                    case "5.0.0.E":
                        winTypeLbl.Text = "Windows XP SP3";
                        break;
                    case "6.0.0.P":
                        winTypeLbl.Text = "Windows 7 Pro";
                        break;
                    case "6.0.0.U":
                        winTypeLbl.Text = "Windows 7 Ultimate";
                        break;
                    case "6.0.1.U":
                        winTypeLbl.Text = " Win 7 Ultimate - Wanna Cry";
                        break;
                    case "6.0.1.P":
                        winTypeLbl.Text = "Win 7 Pro - Wanna Cry";
                        break;
                    case "6.1.0.U":
                        winTypeLbl.Text = "Windows 7 Ultimate SP1";
                        break;
                    case "6.1.0.P":
                        winTypeLbl.Text = "Windows 7 Pro SP1";
                        break;
                    case "7.0.0.P":
                        winTypeLbl.Text = "Windows 7 Pro";
                        break;
                    case "7.0.0.U":
                        winTypeLbl.Text = "Windows 7 Ultimate";
                        break;
                    case "7.1.0.U":
                        winTypeLbl.Text = "Windows 7 Ultimate SP1";
                        break;
                    case "7.1.0.P":
                        winTypeLbl.Text = "Windows 7 Pro SP1";
                        break;
                    case "8.0.0.E":
                        winTypeLbl.Text = "Windows 10";
                        break;
                }
            }
        }

        private void lOrHCB_CheckedChanged(object sender, EventArgs e)
        {

        }
        //private void AddCriteriaToLB()
        //{
        //    switch (criteriaCB.SelectedItem.ToString())
        //    {
        //        case "NC":
        //            if (lOrHCB.Checked == false)
        //            {
        //                WizardFrmParent.rule.Push("[NC]=" + ncLbl.Text + "-" + ncTB.Text + "-" + ncControlTypeLbl.Text + "|");
        //                return;
        //            }

        //            if (conditionalNCcb.SelectedItem.ToString() == "or higher")
        //            {
        //                WizardFrmParent.rule.Push("[NC]≥" + ncLbl.Text + "-" + ncTB.Text + "-" + ncControlTypeLbl.Text + "|");
        //            }
        //        case "PLC":
        //            return;
        //        case "SPEC CODE":

        //            return;
        //        case "MPRM":
        //            return;
        //        case "PLCUF":
        //            return;
        //        case "PLTUA":
        //            return;
        //    }
        //}
    }
}
