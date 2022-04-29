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
    public partial class ExistingForm : Form
    {
        DataSet ruleDS = new DataSet();
        public ExistingForm(DataSet inputDS)
        {
            ruleDS = inputDS;
            InitializeComponent();
        }
 
        public void ExistingForm_Load(object sender, EventArgs e)
        {
            ruleDGV.DataSource = "";
            ruleDGV.DataSource = ruleDS.Tables[0];
        }
    }
}
