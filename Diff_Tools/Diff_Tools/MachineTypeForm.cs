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
        private DataSet machineDataSet = new DataSet();
        private DataTable machineDataTable = new DataTable();
        public MachineTypeForm()
        {
            InitializeComponent();
        }


        
        private void ReadMachineXML()
        {
            machineDataSet.ReadXml("C:\\Program Files\\Okuma\\Diff_Tools\\MachineList_THINC.xml");
            machineDataTable = machineDataSet.Tables[0];
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {

        }

        public void PopMachineList(string code)
        {
            DataRow[] foundRows;
            foundRows = machineDataSet.Tables[0].Select("type = '" + code + "'");  
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
            ReadMachineXML();
            PopMachineList(WizardFrmParent.rule.Peek().Substring(4,1));
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


