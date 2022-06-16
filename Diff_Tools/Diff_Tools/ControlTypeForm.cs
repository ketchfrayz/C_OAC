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
    public partial class ControlTypeForm : Form
    {
        public ControlTypeForm()
        {
            InitializeComponent();
        }

        private void  NextBtn_Click(object sender, System.EventArgs e)
        {  
        }
        private void ExitBtn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        public bool IsFrmComplete()
        {

            if (controlTypeLB.SelectedItems.Count < 1)
            {
                MessageBox.Show("At least 1 Control Type must be selected to proceed!");
                return false;
            }

            if (controlTypeLB.SelectedItems.Count > 1)
            {
                string machineType = "";
                for (var i = 0; i < controlTypeLB.SelectedItems.Count; i++)
                {
                   
                    int compareResult;
                    if( i == 0)
                    {
                        machineType = controlTypeLB.SelectedItems[i].ToString().Length > 6 ? controlTypeLB.SelectedItems[i].ToString().Substring(controlTypeLB.SelectedItems[i].ToString().Length - 2, 1) : controlTypeLB.SelectedItems[i].ToString().Substring(4, 1);
                    }

                    if (i > 0)
                    {
                        string ctrlTypeChar = controlTypeLB.SelectedItems[i].ToString().Length > 6 ?  controlTypeLB.SelectedItems[i].ToString().Substring(controlTypeLB.SelectedItems[i].ToString().Length - 2, 1):controlTypeLB.SelectedItems[i].ToString().Substring(4,1);

                        compareResult = string.Compare(machineType, ctrlTypeChar);
                        if(compareResult != 0)
                        {
                            MessageBox.Show("Select all Machining Centers or all Lathes");
                            return false;
                        }
                    }
                }
            }

           
        
            return true;
        }

        public string ReturnFrmSelection()
        {
            string controlTypeValue = "";
            if (controlTypeLB.SelectedItems.Count == 1)
            {
                return controlTypeLB.SelectedItem.ToString();
            }

            for (var i = 0; i < controlTypeLB.SelectedItems.Count; i++)
            {
                if(i == controlTypeLB.SelectedItems.Count - 1)
                {
                    controlTypeValue += controlTypeLB.SelectedItems[i].ToString();
                    break;
                }
                controlTypeValue += controlTypeLB.SelectedItems[i].ToString() + "|";
                
            }
            return controlTypeValue;

        }
    }
}
