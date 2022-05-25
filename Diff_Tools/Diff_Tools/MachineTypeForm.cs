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
    public partial class MachineTypeForm : Form
    {
        private string[] p300SL = {"ANY", "MACT250", "MACT350", "MACT550", "MULT200", "MULT300", "MULT400", "MULT550", "MULT750", "MULT_U3000", "MULT_U4000", "VTM-100", "VTM-200", "VTM-65", "VTM-80YB", "VTM-120YB", "VTM-200YB", "VTM-1200YB", "VTM-2000YB", "VTR-160A", "VTR-350A" };
        private string[] p300SM = {"ANY", "MU-4000V", "MU-5000V", "MU-6300V", "MU-8000V" };
        private DataSet machineDataSet = new DataSet();
        private DataTable machineDataTable = new DataTable();
        public MachineTypeForm()
        {
            InitializeComponent();
        }


        
        private void ReadMachineXML()
        {
            machineDataSet.ReadXml("\\\\nxfiler\\data05\\USR0\\Ospsoftw.are\\Diff_Tools\\MachineList_THINC.xml");
            //machineDataSet.ReadXml("C:\\Users\\corey\\Documents\\Okuma\\Diff_Tools\\MachineList_THINC.xml");
            machineDataTable = machineDataSet.Tables[0];
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void PopMachineList(string code)
        {
            DataRow[] foundRows;
            foundRows = machineDataSet.Tables[0].Select("type = '" + code + "'");
            machineTypeLB.Items.Add("ANY");
            for (var i = 0; i < foundRows.Count(); i++)
            {
                machineTypeLB.Items.Add(foundRows[i][0]);
            }
          
        }

        public bool IsFrmComplete()
        {

            if (machineTypeLB.SelectedItems.Count == 0)
            {
                return false;
            }
            return true;
        }

      

        public string ReturnFrmSelection()
        {
            string machineTypeValue = "";
            if (machineTypeLB.SelectedItems.Count == 1)
            {
                return machineTypeLB.SelectedItem.ToString();
            }

            for (var i = 0; i < machineTypeLB.SelectedItems.Count; i++)
            {
                if (i == machineTypeLB.SelectedItems.Count - 1)
                {
                    machineTypeValue += machineTypeLB.SelectedItems[i].ToString();
                    break;
                }
                machineTypeValue += machineTypeLB.SelectedItems[i].ToString() + ":";
            }

            return machineTypeValue;
        }
        private void machineTypeLB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MachineTypeForm_Load(object sender, EventArgs e)
        {
            machineTypeLB.Items.Clear();
            ReadMachineXML();
            if (WizardFrmParent.rule.Peek().EndsWith("(L)"))
            {
                machineTypeLB.Items.AddRange(p300SL);
            }
            else if (WizardFrmParent.rule.Peek().EndsWith("(M)"))
            {
                machineTypeLB.Items.AddRange(p300SM);
            }
            else
            {
                PopMachineList(WizardFrmParent.rule.Peek().Substring(4, 1));
            }
        }

        private void MachineTypeForm_Enter(object sender, EventArgs e)
        {
            machineTypeLB.Items.Clear();
            machineTypeLB.Items.Add("ANY");
            PopMachineList(WizardFrmParent.rule.Peek().Substring(4, 1));
        }

        private void MachineTypeForm_Shown(object sender, EventArgs e)
        {
            machineTypeLB.Items.Clear();
            machineTypeLB.Items.Add("ANY");
            PopMachineList(WizardFrmParent.rule.Peek().Substring(4, 1));
        }

        private void MachineTypeForm_Activated(object sender, EventArgs e)
        {
            machineTypeLB.Items.Clear();
            machineTypeLB.Items.Add("ANY");
            PopMachineList(WizardFrmParent.rule.Peek().Substring(4, 1));
        }
    }
   
}


