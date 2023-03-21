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
using System.Net;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;


namespace Diff_Tools
{
       
    public partial class mainForm : Form
    {
        int numTicks;
        private Diff diff;
        private DMC dmc;
        private List<Action> checks;
        static  private DataTable apiDT;
        static private DataSet apiDS;
        static public DataSet rulesDS;
        static public DataTable rulesDT;
        private static readonly Regex regex = new Regex("[^a-zA-Z0-9]");
        //public ControlTypeForm controlTypeForm = new ControlTypeForm();
        public mainForm()
        {
            InitializeComponent();
        }

        // Form event handlers
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            // Clear RTB, LB, and LV of MainForm
            ResetForm();

            // Create instance of Diff and DMC class
            diff = new Diff();
            dmc = new DMC();
            checks = new List<Action>();

            // Get path of drag/drop file
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length == 1)   // If number of files drag/drop is one
            {
                if (Path.GetExtension(files[0]) == ".DAT")  // If file extension is DAT
                {
                    diff.FileLocation = files[0];
                    dmc.FileLocation = Path.GetDirectoryName(diff.FileLocation);
                    ReadFileData();
                    diff.SetTrimFileContents(TrimBeginEnd(diff.GetOrigFileContents()));
                    diff.SetHexIndex(GetHexIndex(diff.GetTrimFileContents()));
                    ProcessDiff();
                    CheckAgainstRulesDB();
                    ChangeFlagColor();
                    outputToLog(CreateOutputRecord());
                }
                else
                {
                    MessageBox.Show("Only files with a .DAT extension are supported!!!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Only drag and drop 1 file!!!");
                return;
            }
        }

        private void AddFileLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection addFile = addFileLV.SelectedItems;
            if (addFile.Count > 0)
            {
                if (addFile[0].Text != "---" || addFile[0].Text != "==========" || addFile[0].Text != "")
                {
                    FindEntry(addFile[0].Text);
                }
            }
        }

        private void RollBackLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection rollBack = rollBackLV.SelectedItems;
            if (rollBack.Count > 0)
            {
                if (rollBack[0].Text != "---" && rollBack[0].Text != "==========" && rollBack[0].Text != "")
                {
                    FindEntry(rollBack[0].Text);
                }
            }
        }

        private void ServoLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection servo = servoLV.SelectedItems;
            if (servo.Count > 0)
            {

                if (servo[0].Text != "---" && servo[0].Text != "==========" && servo[0].Text != "")
                {
                    FindEntry(servo[0].Text);
                }
            }
        }

        private void PiodLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection ioFile = piodLV.SelectedItems;
            if (ioFile.Count > 0)
            {

                if (ioFile[0].Text != "---" && ioFile[0].Text != "==========" && ioFile[0].Text != "")
                {
                    FindEntry(ioFile[0].Text);
                }
            }
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            PopAPIDT();
            PopRulesDT();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (numTicks < 10)
            {
                ChangeIOColor();
                numTicks += 1;
            }
            else
            {
                Timer1.Stop();
            }
        }

        private void addNewRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WizardFrmParent wizardFrmParent = new WizardFrmParent();
            wizardFrmParent.ShowDialog();
            //controlTypeForm.ShowDialog();
        }

        private void viewExistingRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopRulesDT();
            ExistingForm exform = new ExistingForm(rulesDS);
            exform.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void PopRulesDT()
        {
            rulesDS = new DataSet();
            //string filePath = "\\\\nxfiler\\data05\\USR0\\Ospsoftw.are\\Diff_Tools\\rules.CSV";
            string filePath = "C:\\Users\\corey\\Documents\\Okuma\\Diff_Tools\\rules.CSV";
            string fullText;
            rulesDT = new DataTable("Rules");
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        fullText = sr.ReadToEnd().ToString();
                        string[] rows = fullText.Split('\n');
                        for (var i = 0; i < rows.Count(); i++)
                        {
                            string[] rowValues = rows[i].Split(',');
                            if (i == 0)
                            {
                                for (var j = 0; j < rowValues.Count(); j++)
                                {
                                    rulesDT.Columns.Add(rowValues[j]);
                                }
                            }
                            else
                            {
                                DataRow dr = rulesDT.NewRow();
                                for (var k = 0; k < rowValues.Count(); k++)
                                {
                                    dr[k] = rowValues[k].ToString();
                                }
                                rulesDT.Rows.Add(dr);
                            }
                        }
                    }
                }
                rulesDS.Tables.Add(rulesDT);
            }

        }
        private void PopAPIDT()
        {
            apiDS = new DataSet();
            //string filePath = "\\\\nxfiler\\data05\\USR0\\Ospsoftw.are\\Diff_Tools\\API_Version.CSV";
            string filePath = "C:\\Users\\corey\\Documents\\Okuma\\Diff_Tools\\API_Version.CSV";
            string fullText;
            apiDT = new DataTable("APIVersion");
            if (File.Exists(filePath)) 
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        fullText = sr.ReadToEnd().ToString();
                        string[] rows = fullText.Split('\n');
                        for (var i = 0; i < rows.Count(); i++)
                        {
                            string[] rowValues = rows[i].Split(',');
                            if (i == 0)
                            {
                                for (var j = 0; j < rowValues.Count(); j++)
                                {
                                    apiDT.Columns.Add(rowValues[j]);
                                } 
                                
                            } else
                            {
                                DataRow dr = apiDT.NewRow();
                                for (var k = 0; k < rowValues.Count(); k++)
                                {
                                    dr[k] = rowValues[k].ToString();
                                }
                                apiDT.Rows.Add(dr);
                            }
                        }
                    }
                }
                apiDS.Tables.Add(apiDT);
            }
        }
        private bool CheckAPIDS(DMC iDmc)
        {
            if (iDmc.OSPType == "P300M" && iDmc.WinVersion == "5.0.0.E")
            {
                if (iDmc.ApiVer == "1.23.1.0" || iDmc.ApiVer == "1.23.0.0")
                {
                    int ncCompResult = string.Compare("MNC-310K-P300-4", iDmc.NcVer, StringComparison.Ordinal);
                    int libCompResult = string.Compare("MCAPI-003S", iDmc.ApiLibVer, StringComparison.Ordinal);
                    if (ncCompResult < 0)
                    {
                        //DMC API library higher than required API library version
                        if (libCompResult < 0)
                        {
                            return true;
                        }
                        //DMC API library lower than required API library version
                        else if (libCompResult > 0)
                        {
                            apiLB.Items.Add(iDmc.ApiVer + " Library required: " + "MCAPI-003S" + " | " + iDmc.SerialNumber + " Library : " + iDmc.ApiLibVer);
                            apiLB.Items.Add("==========");
                            return false;
                        }

                    }
                    else if (ncCompResult > 0)
                    {
                        apiLB.Items.Add(iDmc.ApiVer + " NC required: " + "MNC-310K-P300-4" + " | " + iDmc.SerialNumber + " NC : " + iDmc.NcVer);
                        //DMC API library higher than required API library version
                        if (libCompResult < 0)
                        {

                        }
                        //DMC API library lower than required API library version
                        else if (libCompResult > 0)
                        {
                            apiLB.Items.Add(iDmc.ApiVer + " Library required: " + "MCAPI-003S" + " | " + iDmc.SerialNumber + " Library : " + iDmc.ApiLibVer);
                            apiLB.Items.Add("==========");
                        }
                        return false;
                    }
                }

            }
            else
            {
                int colIndex;
                colIndex = apiDS.Tables[0].Columns.IndexOf(iDmc.OSPType);
                if (colIndex != -1)
                {
                    string expression = "API = '" + iDmc.ApiVer + "'";
                    DataRow[] foundRows = apiDS.Tables[0].Select(expression);
                    if (foundRows.Length == 1)
                    {

                        string[] result = foundRows[0][colIndex].ToString().Split('|');
                        string reqNC = result[0];
                        string reqLib = result[1];
                        int ncCompResult = string.Compare(reqNC, iDmc.NcVer, StringComparison.Ordinal);
                        int libCompResult = string.Compare(reqLib, iDmc.ApiLibVer, StringComparison.Ordinal);

                        //DMC NC version higher than required API NC version
                        if (ncCompResult < 0)
                        {
                            //DMC API library higher than required API library version
                            if (libCompResult < 0)
                            {
                                return true;
                            }
                            //DMC API library lower than required API library version
                            else if (libCompResult > 0)
                            {
                                apiLB.Items.Add(iDmc.ApiVer + " Library required: " + reqLib + " | " + iDmc.SerialNumber + " Library : " + iDmc.ApiLibVer);
                                apiLB.Items.Add("==========");
                                return false;
                            }

                        }
                        //DMC NC version lower than required API NC version
                        else if (ncCompResult > 0)
                        {
                            apiLB.Items.Add(iDmc.ApiVer + " NC required: " + reqNC + " | " + iDmc.SerialNumber + " NC : " + iDmc.NcVer);
                            apiLB.Items.Add("==========");
                            //DMC API library higher than required API library version
                            if (libCompResult < 0)
                            {

                            }
                            //DMC API library lower than required API library version
                            else if (libCompResult > 0)
                            {
                                apiLB.Items.Add(iDmc.ApiVer + " Library required: " + reqLib + " | " + iDmc.SerialNumber + " Library : " + iDmc.ApiLibVer);
                                apiLB.Items.Add("==========");
                            }
                            return false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("API version " + dmc.ApiVer + " not found in API datatable");
                        return false;
                    }
                }
            
            }
            return false;
        }
        private void CheckDupETC(DMC iDmc)
        {
            var result = iDmc.GetETC().Intersect(iDmc.GetPBUDAT()); // check to see if any files in ETC exist in PBU-DAT
            if (result.Count() != 0)
            {
                for (var i = 0; i < result.Count(); i++)
                { 
                    rulesLB.Items.Add(result.ToList()[i] + " exists in ETC and PBU-DAT"); // add duplicate file to apiLB
                    rulesLB.Items.Add("==========");
                }
            }
            result = iDmc.GetETC().Intersect(iDmc.GetPBUDAT());     // check to see if any files in ETC exist in CNS-DAT
            if (result.Count() != 0)
            {
                for (var i = 0; i < result.Count(); i++)
                {
                    rulesLB.Items.Add(result.ToList()[i] + " exists in ETC and CNS-DAT"); // add duplicate file to apiLB
                    rulesLB.Items.Add("==========");
                }
            }

            for (var i = 0; i < iDmc.GetETC().Count; i++)
            {
                for (var a = 0; a < iDmc.GetPBUDAT().Count; a++)
                {
                    if (iDmc.GetETC(i).Substring(0, 5) == iDmc.GetPBUDAT(a).Substring(0, 5))
                    {
                        rulesLB.Items.Add(iDmc.GetETC(i).Substring(0,4) + " exists in ETC and PBU-DAT");
                        rulesLB.Items.Add("==========");
                    }
                }

                for (var a = 0; a < iDmc.GetCNSDAT().Count; a++)
                {
                    if (iDmc.GetETC(i).Substring(0,5) == iDmc.GetCNSDAT(a).Substring(0, 5))
                    {
                        rulesLB.Items.Add(iDmc.GetETC(i).Substring(0,4) + " exists in ETC and CNS-DAT");
                        rulesLB.Items.Add("==========");
                    }
                }
            }
        }
        private void MoveEXE()
        {

        }
        private void CheckUpdate()
        {           
            if (!File.Exists("\\\\nxfiler\\data05\\USR0\\Ospsoftw.are\\Diff_Tools\\update\\DAU-ATLAS(alpha).EXE"))
            {
                return;
            }
           
        }
        private bool CheckMachineType(string dmcMachineType, string ruleMachineType)
        {
            if (ruleMachineType.Contains("|"))
            {
                string[] temp = ruleMachineType.Split('|');
                for ( var i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == dmcMachineType)
                    {
                        break;
                    }
                }
                return false;
            }

            if ( !ruleMachineType.Contains("|") && ruleMachineType != "ANY")
            {
                if (ruleMachineType != dmcMachineType)
                {
                    return false;
                }
            }

            return true;
        }
        private void CheckAgainstRulesDB()
        {
            DataRow[] ruleDataRow = CheckControlType(dmc);
            if (ruleDataRow.Count() == 0)
            {
                return;
            }

            for (var i = 0; i < ruleDataRow.Length; i++)
            {
                if(CheckMachineType(dmc.MachineType, ruleDataRow[i][1].ToString()) && CheckOptionalRule(ruleDataRow[i][2].ToString()))
                {
                    rulesLB.Items.Add(ruleDataRow[i][3]);
                    rulesLB.Items.Add("==========");
                }

            }
        }
        private DataRow[] CheckControlType(DMC iDmc) //Not Finished
        {

            if(iDmc.OSPType.EndsWith("S") || iDmc.OSPType.EndsWith("SA"))
            {
                iDmc.OSPType += iDmc.IsLathe(iDmc.OSPType) ? " (L)" : " (M)";
            }
            string expression = "controlType='" + iDmc.OSPType + "' OR controlType = 'ANY' OR controlType LIKE '%|" + iDmc.OSPType + "|%' OR controlType LIKE '*|" + iDmc.OSPType + "'" +
                                "OR controlType LIKE '" + iDmc.OSPType + "|*'";
           DataRow[] foundRows = rulesDS.Tables[0].Select(expression);
           return foundRows;    
        }
        public void CheckIORev(List<string> piodFiles)
        {

            char newPiodVer;
            char prevPiodVer;
            if (piodFiles.Count == 4)
            {
                newPiodVer = Convert.ToChar(piodFiles[1].Substring(piodFiles[1].Count() - 6, 1));
                char newSiodVer = Convert.ToChar(piodFiles[3].Substring(piodFiles[3].Count() - 5, 1));
                char prevSiodVer = Convert.ToChar(piodFiles[2].Substring(piodFiles[2].Count() - 5, 1));
                prevPiodVer = Convert.ToChar(piodFiles[0].Substring(piodFiles[0].Count() - 6, 1));
               if (newPiodVer == newSiodVer)
                {
                    if (newPiodVer - prevPiodVer > 1)
                    {
                        ioRevLbl.Text = "** PIOD/SIOD rev more than one version **";
                        Timer1.Enabled = true;
                        Timer1.Start();
                    } else if(newPiodVer - prevPiodVer < 1)
                    {
                        ioRevLbl.Text = "!! PIOD/SIOD version rolled back !!";
                        Timer1.Enabled = true;
                        Timer1.Start();
                    }
                } else if(newPiodVer != newSiodVer)
                {
                    ioRevLbl.Text = "!! PIOD/SIOD version doesn't match !!";
                    Timer1.Enabled = true;                    
                    Timer1.Start();
                }
            }else if (piodFiles.Count() == 2)
            {
                newPiodVer = Convert.ToChar(piodFiles[1].Substring(piodFiles[1].Count() - 6, 1));
                prevPiodVer = Convert.ToChar(piodFiles[0].Substring(piodFiles[0].Count() - 6, 1));
                if (newPiodVer - prevPiodVer > 1)
                {
                    ioRevLbl.Text = "** PIOD rev more than one version **";
                    Timer1.Enabled = true;
                    Timer1.Start();
                } else if( newPiodVer - prevPiodVer < 1)
                {
                    ioRevLbl.Text = "!! PIOD version rolled back !!";
                    Timer1.Enabled = true;
                    Timer1.Start();
                }
            }

        }
        private void ChangeIOColor()
        {
            ioRevLbl.Visible = true;
            if (ioRevLbl.Text.Contains("rolled back") || ioRevLbl.Text.Contains("doesn't match"))
            {
                if (piodLV.BackColor == Color.Chocolate)
                {
                    piodLV.BackColor = Color.Red;
                    ioRevLbl.ForeColor = Color.Red;
                }
                else if (piodLV.BackColor == Color.Red)
                {
                    piodLV.BackColor = Color.Chocolate;
                    ioRevLbl.ForeColor = Color.Black;
                }
            } else
            {
                if (piodLV.BackColor == Color.Chocolate)
                {
                    piodLV.BackColor = Color.Gold;
                    ioRevLbl.ForeColor = Color.Gold;
                }
                else if (piodLV.BackColor == Color.Gold)
                {
                    piodLV.BackColor = Color.Chocolate;
                    ioRevLbl.ForeColor = Color.Black;
                }
            }
        }
        

        public void FindEntry(string textLine)
        {
            int pos = 0;
            pos = displayRTB.Find(textLine, pos, RichTextBoxFinds.MatchCase);
            while (pos != -1)
            {
                if (displayRTB.SelectedText == textLine)
                {
                    displayRTB.SelectionLength = textLine.Length;
                    displayRTB.ScrollToCaret();
                }
                pos = displayRTB.Find(textLine, pos + 1, RichTextBoxFinds.MatchCase);
            }
        }


        public void CompareFiles(string prevFile, string newFile)
        {
            if (!(prevFile.StartsWith("< * cspsVer") && newFile.StartsWith("> * cspsVer")))
            {
                string trimPrevFile = prevFile;
                string trimNewFile = newFile;
                if (prevFile.EndsWith(".CNS") && newFile.EndsWith(".CNS"))
                {
                    trimPrevFile = prevFile.Replace(".CNS", "");
                    trimNewFile = newFile.Replace(".CNS", "");
                }
                trimPrevFile = regex.Replace(trimPrevFile, string.Empty);
                trimNewFile = regex.Replace(trimNewFile, string.Empty);
                int result = string.Compare(trimPrevFile, trimNewFile, StringComparison.Ordinal);

                if (result < 0)
                {

                }
                else if (result > 0)
                {
                    rollBackLV.Items.Add(prevFile);
                    rollBackLV.Items.Add("---");
                    rollBackLV.Items.Add(newFile);
                    rollBackLV.Items.Add("==========");
                    HighlightFlags(prevFile, newFile, 'r');
                }
                CheckSpecCond(prevFile, newFile);
            }
        }

        public void HighlightFlags(string prevFile, string newFile, char changeType)
        {
            int pos = 0;
            pos = displayRTB.Find(prevFile, pos, RichTextBoxFinds.MatchCase);
            while (pos != -1)
            {
                if (displayRTB.SelectedText == prevFile)
                {
                    switch (changeType)
                    {
                        //file rolled back
                        case 'r':
                            {
                                displayRTB.SelectionColor = Color.Firebrick;
                                break;
                            }
                        //servo data file changed
                        case 's':
                            {
                                displayRTB.SelectionColor = Color.CornflowerBlue;
                                break;
                            }
                        //PIOD/SIOD file changed
                        case 'p':
                            {
                                displayRTB.SelectionColor = Color.LightSalmon;
                                break;
                            }
                        //file added/deleted
                        case 'a':
                            {
                                displayRTB.SelectionColor = Color.DarkKhaki;
                                break;
                            }

                    }
                    pos = displayRTB.Find(prevFile, pos + 1, RichTextBoxFinds.MatchCase);
                }
            }
                pos = 0;
                pos = displayRTB.Find(newFile, pos, RichTextBoxFinds.MatchCase);
            while (pos != -1)
            {
                if (displayRTB.SelectedText == newFile)
                    {
                        switch (changeType)
                        {
                            //file rolled back
                            case 'r':
                                {
                                    displayRTB.SelectionColor = Color.Firebrick;
                                    break;
                                }
                            //servo data file changed
                            case 's':
                                {
                                    displayRTB.SelectionColor = Color.CornflowerBlue;
                                    break;
                                }
                            //PIOD/SIOD file changed
                            case 'p':
                                {
                                    displayRTB.SelectionColor = Color.LightSalmon;
                                    break;
                                }
                            //file added/deleted
                            case 'a':
                                {
                                    displayRTB.SelectionColor = Color.DarkKhaki;
                                    break;
                                }

                        }
                        pos = displayRTB.Find(newFile, pos + 1, RichTextBoxFinds.MatchCase);
                    }
            }
            //}
        }   
        public void HighlightFlags(string textLine, char changeType)
        {
            int pos = 0;
            pos = displayRTB.Find(textLine, pos, RichTextBoxFinds.MatchCase);
            while (pos != -1)
            {
                if (displayRTB.SelectedText == textLine)
                {
                    switch (changeType)
                    {
                        //file rolled back
                        case 'r':
                            {
                                displayRTB.SelectionColor = Color.Firebrick;
                                break;
                            }
                        case 's':
                            {
                                displayRTB.SelectionColor = Color.CornflowerBlue;
                                break;
                            }
                        case 'p':
                            {
                                displayRTB.SelectionColor = Color.LightSalmon;
                                break;
                            }
                        case 'a':
                            {
                                displayRTB.SelectionColor = Color.DarkKhaki;
                                break;
                            }

                    }
                    pos = displayRTB.Find(Text, pos + 1, RichTextBoxFinds.MatchCase);
                }
            }
        }
        
        public void ProcessDiff()
        {
            // Add column to form ListViews
            addFileLV.Columns.Add("MyColumn", -2);
            rollBackLV.Columns.Add("MyColumn", -2);
            servoLV.Columns.Add("MyColumn", -2);
            piodLV.Columns.Add("MyColumn", -2);
            int count = 0;
            int count2 = 0;
            int fsIntDiv;
            int fsModDiv;
            do
            {
                count2 = int.Parse(diff.GetHexIndex(count)) + 1;                                                        // Get hexindex for file section starting point
                do
                {
                    diff.AddFileSection(diff.GetTrimFileContents(count2));                                                  // Add FileContents[count2] to FileSection list
                    count2 += 1;
                } while (count2 != int.Parse(diff.GetHexIndex(count + 1)));                                             // Loop until index of next hexIndex
                
                fsIntDiv = diff.GetFileSection().Count/2;
                fsModDiv = diff.GetFileSection().Count % 2;                                                             // 0 = Even number of lines, 1 = Odd number of lines
                int mpIndex = diff.GetFileSection().IndexOf("---"); 
                if(mpIndex != -1) {                                                                                     // If file section contains "---"

                    if (fsIntDiv == mpIndex && fsModDiv == 1)                                                               //  
                    {
                        for (var i = 0; i < diff.GetFileSection().IndexOf("---"); i++)                                          // Loop fileSection by 1 until "---"
                        {
                            CompareFiles(diff.GetFileSection(i), diff.GetFileSection(i + 1 + (diff.GetFileSection().Count / 2)));   // Compare previous and new file
                        }
                    } else if(fsIntDiv != mpIndex || fsModDiv == 0)                                                     // If "---" isn't in middle of list
                    {
                        if ((mpIndex + 1) * 2 <= diff.GetFileSection().Count()){                                            // If file is added in file section

                            for (var i = 0; i < mpIndex; i++)                                                                   // Loop fileSection by 1 until "---" index
                            {
                                CompareFiles(diff.GetFileSection(i), diff.GetFileSection(i + 1 + (mpIndex)));                       // Compare previous and new file
                            }
                            for (var i = mpIndex + fsIntDiv; i < diff.GetFileSection().Count(); i++)                            // Loop through leftover fileSection until end
                            {
                                if (!(diff.GetFileSection(i).Contains("SAFETY")) && !(diff.GetFileSection(i).StartsWith("> *")))       // if current line doesn't equal "SAFETY" AND doesn't start with "> *"        
                                {
                                    addFileLV.Items.Add(diff.GetFileSection(i));                                                            // Add current line to addFileLV     
                                    addFileLV.Items.Add("==========");
                                    HighlightFlags(diff.GetFileSection(i), 'a');                                                            // Highlight file in displayRTB
                                    CheckSpecCond(diff.GetFileSection(i));
                                }
                            }
                        } else if((mpIndex + 1) * 2 > diff.GetFileSection().Count())    // If file is removed in file section
                        {
                            int startAdd = ((diff.GetFileSection().Count()) - (mpIndex + 1));
                            for (var i = startAdd; i < mpIndex; i++){
                                if (diff.GetFileSection(i) != "---")
                                {
                                    addFileLV.Items.Add(diff.GetFileSection(i));
                                    addFileLV.Items.Add("==========");
                                    HighlightFlags(diff.GetFileSection(i), 'a');
                                    CheckSpecCond(diff.GetFileSection(i));
                                }
                            }
                            for (var i = 0; i < startAdd; i++)
                            {
                                CompareFiles(diff.GetFileSection(i), diff.GetFileSection(i + 1 + mpIndex));
                            }
                        }
                    }
                } else if(mpIndex == -1)    // If file section doesn't contain "---" (Only add or remove)
                {
                    for (var i = 0; i <= diff.GetFileSection().Count() - 1; i++)
                    {
                        if (!(diff.GetFileSection().Contains("SAFETY")) && !(diff.GetFileSection(i).StartsWith("> *             ")))    // If file section doesn't contain SAFETY and file section[i] isn't prod comment
                        {
                            if (!diff.GetFileSection(i).StartsWith("> *"))
                            {
                                // Add FileSection[i] to mainFrm LV and highlight on Diff text
                                addFileLV.Items.Add(diff.GetFileSection(i));
                                addFileLV.Items.Add("==========");
                                HighlightFlags(diff.GetFileSection(i), 'a');
                                CheckSpecCond(diff.GetFileSection(i));
                            }
                        }
                        else
                        {
                            if (diff.SafetyFlag == false && diff.GetSafetyFiles().Count() == 0)
                            {
                                diff.SafetyFlag = true;
                                diff.AddSafetyFiles(diff.GetFileSection(i));
                            } else if (diff.SafetyFlag && diff.GetSafetyFiles().Count() == 1)
                            {
                                diff.AddSafetyFiles(diff.GetFileSection(i));
                            }
                        }
                    }

                }
                        
                
                diff.GetFileSection().Clear();
                count += 1;
            } while (count < diff.GetHexIndex().Count - 1);
            CheckDupETC(dmc);
            if (dmc.ApiVer != "NONE") { CheckAPIDS(dmc); }
            
            CheckIORev(diff.GetIOFiles());
        }

        public List<string> TrimBeginEnd(List<string> contentsList)
        {
            int startIndex = diff.GetOrigFileContents().IndexOf("################################################################################") +1;
            int stopIndex = diff.GetOrigFileContents().Contains("================================================================================") ? diff.GetOrigFileContents().IndexOf("================================================================================") - 1:diff.GetOrigFileContents().Count - 1;
            if (contentsList.Contains("================================================================================"))
            {
                for (var i = contentsList.Count - 1;i >= stopIndex; i--)
                {
                    contentsList.RemoveAt(i);
                }
            }
            for (var i = startIndex - 1; i >= 0; i--)
            {
                contentsList.RemoveAt(i);
            }
            contentsList.Add("4c4");
            contentsList.RemoveAll( string.IsNullOrWhiteSpace);
            return contentsList;
        }

        public void ReadFileData()
        {
            ReadDiffFile(diff.FileLocation);
            ReadLISTAFile(dmc.FileLocation + "\\LISTA.DAT");
            ReadDMCFile(dmc.FileLocation + "\\OSPMNGCD.CNC");
            if(diff.SerialNumber != dmc.SerialNumber)
            {
                MessageBox.Show("DIFF and LISTA serial numbers don't match!  Please correct and try again.");
            }
        }
        public void ReadDMCFile(string DMCFileLocation)
        {
            if (File.Exists(DMCFileLocation))
            {
                using (var sr = new StreamReader(DMCFileLocation))
                {
                    do
                    {
                        dmc.AddOrigDMCFileContents(sr.ReadLine());
                    } while (sr.Peek() != -1);
                }
                dmc.DMCFileExists = true;
                dmc.FillSpecCodeList();

            }
            else
            {
                dmc.DMCFileExists = false;
            }
        }

        public void ReadLISTAFile(string listaFileLocation)
        {
            if (File.Exists(listaFileLocation))
            {
                using (var sr = new StreamReader(listaFileLocation))
                {
                    do
                    {
                        dmc.AddOrigLISTAFileContents(sr.ReadLine());
                    } while (sr.Peek() != -1);
                }
                dmc.ListaFileExists = true;
                dmc.fillClassVar();
            }
            else
            {
                dmc.ListaFileExists = false;
                MessageBox.Show("OSPMNGCD.CNC or LISTA.DAT isn't in " + Path.GetDirectoryName(listaFileLocation) + "!  Checks will be limited, add these files and drag DIFF.DAT onto form.");
            }
        }
        public void ReadDiffFile(string diffFileLocation)
        {
            using (var sr = new StreamReader(diffFileLocation))
            {
                do
                {
                    diff.AddOrigFileContents(sr.ReadLine());
                } while (sr.Peek() != -1);
            }
            diff.FillSerialAndTypeVar();
            for (var i = 0; i < diff.GetOrigFileContents().Count; i++)
            {
                displayRTB.Text += diff.GetOrigFileContents(i) + System.Environment.NewLine;
            }
            
        }
        public List<string> GetHexIndex(List<string> fileList)
        {
            List<string> hexindex = new List<string>();

            for (var i = 0; i < fileList.Count; i++)
            {
                if (fileList[i].Contains(","))
                {
                    if (IsHex(fileList[i].Substring(0, fileList[i].IndexOf(","))))
                    {
                        hexindex.Add(i.ToString());
                    }
                }
                else
                {
                    if (IsHex(fileList[i]))
                    {
                        hexindex.Add(i.ToString());
                    }
                }
            }
            return hexindex;
        }
        public bool IsHex(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            Int32 i = 0;
            char c;

            if (str.IndexOf("0x") == 0)
                str = str.Substring(2);

            while (i < str.Length)
            {
                c = str[i];
                if (!(((c >= '0') && (c <= '9')) ||
                     ((c >= 'a') && (c <= 'f')) ||
                     ((c >= 'A') && (c <= 'F'))))
                {
                    return false;
                }
                else
                    i += 1;

                        
            }
            return true;
        }
        public void ResetForm()
        {
            ioRevLbl.Text = "";
            ioRevLbl.Visible = false;
            displayRTB.Text = "";
            rollBackLV.Clear();
            addFileLV.Clear();
            servoLV.Clear();
            piodLV.Clear();
            apiLB.Items.Clear();
            rulesLB.Items.Clear();
            rollBackLV.BackColor = SystemColors.Control;
            addFileLV.BackColor = SystemColors.Control;
            servoLV.BackColor = SystemColors.Control;
            piodLV.BackColor = SystemColors.Control;
            numTicks = 0;
        }
        public void CheckForServo(string prevFile, string newFile)
        {
            if ((prevFile.Contains("AXSP") && newFile.Contains("AXSP")) || (prevFile.Contains("SSMP") && newFile.Contains("SSMP")) || (prevFile.Contains("PFCPMN")) && newFile.Contains("PFCPMN"))
            {
                string[] prevResults = prevFile.Split('\\');
                string[] newResults = newFile.Split('\\');
                string modPrevFile = prevResults[prevResults.Length-1];
                string modNewFile = newResults[newResults.Length - 1];
                modPrevFile = modPrevFile.Substring(0, modPrevFile.IndexOf('.'));
                modNewFile = modNewFile.Substring(0, modNewFile.IndexOf('.'));
                prevResults = modPrevFile.Split('-');
                newResults = modNewFile.Split('-');
                ListViewItem lvi;
                Font fnt_font = new Font("Segoe UI", (float)8.25, FontStyle.Bold);
                if (modPrevFile.StartsWith("AXSPL") && modNewFile.StartsWith("AXSPL"))
                {
                    if (prevResults.Length - 1 == 2 && newResults.Length - 1 == 2)
                    {
                        for (var i = 0; i < prevResults.Length; i++)
                        {
                            if (prevResults[i] != newResults[i] && i < 2)
                            {
                                //base file version changed, add note to ticker
                                lvi = new ListViewItem();
                                lvi.Text = "SDF base version changed:";
                                lvi.ForeColor = Color.DarkRed;
                                lvi.Font = fnt_font;                                
                                servoLV.Items.Add(lvi);
                                //servoLV.Items.Add(prevFile);

                            }
                        }
                    } else if (prevResults.Length - 1 == 5 && newResults.Length - 1 == 5)
                    {
                        for (var i = 0; i < prevResults.Length; i++)
                        {
                            if(prevResults[i] != newResults[i] && i < 4)
                            {
                                //base file version changed, add note to ticker
                                lvi = new ListViewItem();
                                lvi.Text = "SDF base version changed:";
                                lvi.ForeColor = Color.DarkRed;
                                lvi.Font = fnt_font;
                                servoLV.Items.Add(lvi);
                            }
                        }
                    }
                    else
                    {
                        //SDF file section sizes don't match, add note to ticker
                    }
                            
                } else if (modPrevFile.StartsWith("SSMPL") && modNewFile.StartsWith("SSMPL"))
                {
                    if ( prevResults.Length - 1 == 3 && newResults.Length - 1 == 3)
                    {
                        for (var i = 0; i < prevResults.Length; i++)
                        {
                            if(prevResults[i] != newResults[i] && i < 3)
                            {
                                //base file version changed, add note to ticker
                                lvi = new ListViewItem();
                                lvi.Text = "SSMPL base version changed:";
                                lvi.ForeColor = Color.DarkRed;
                                lvi.Font = fnt_font;
                                servoLV.Items.Add(lvi);
                            }
                        }
                    }
                    else
                    {
                        //SSMPL file section sizes don't match, add note to ticker
                    }
                } else if (modPrevFile.StartsWith("AXSPM") && modNewFile.StartsWith("AXSPM"))
                {
                    if(prevResults.Length - 1 == 2 && newResults.Length - 1 == 2)
                    {
                        for (var i = 0; i < prevResults.Length; i++)
                        {
                            if(prevResults[i] != newResults[i] && i < 2)
                            {
                                //base file version changed, add note to ticker
                                lvi = new ListViewItem();
                                lvi.Text = "SDF base version changed:";
                                lvi.ForeColor = Color.DarkRed;
                                lvi.Font = fnt_font;
                                servoLV.Items.Add(lvi);
                            }
                        }
                    }
                } else if (modPrevFile.StartsWith("PFCPMN") && modNewFile.StartsWith("PFCPMN"))
                {
                    if(prevResults.Length - 1 == 2 && newResults.Length - 1 == 2)
                    {
                        for (var i = 0; i < prevResults.Length; i++)
                        {
                            if(prevResults[i] != newResults[i] && i < 2)
                            {
                                //base file version changed, add note to ticker
                                lvi = new ListViewItem();
                                lvi.Text = "PFC base version changed:";
                                lvi.ForeColor = Color.DarkRed;
                                lvi.Font = fnt_font;
                                servoLV.Items.Add(lvi);
                            }
                        }
                    }
                }
                if (servoLV.Items.Count != 0)
                {
                    if (servoLV.Items[servoLV.Items.Count - 1].ForeColor == Color.DarkRed)
                    {
                        lvi = new ListViewItem();
                        lvi.Text = prevFile;
                        lvi.ForeColor = Color.DarkRed;
                        lvi.Font = fnt_font;
                        servoLV.Items.Add(lvi);
                        servoLV.Items.Add("---");
                        lvi = new ListViewItem();
                        lvi.Text = newFile;
                        lvi.ForeColor = Color.DarkRed;
                        lvi.Font = fnt_font;
                        servoLV.Items.Add(lvi);
                        servoLV.Items.Add("==========");
                    }
                    else
                    {
                        servoLV.Items.Add(prevFile);
                        servoLV.Items.Add("---");
                        servoLV.Items.Add(newFile);
                        servoLV.Items.Add("==========");
                    }
                }
                else
                {
                    servoLV.Items.Add(prevFile);
                    servoLV.Items.Add("---");
                    servoLV.Items.Add(newFile);
                    servoLV.Items.Add("==========");
                }
                if (rollBackLV.FindItemWithText(prevFile) != null && rollBackLV.FindItemWithText(newFile) != null)
                {

                }
                else
                {
                    HighlightFlags(prevFile, newFile, 's');
                }
            }
        }
        public void CheckForServo(string file)
        {
            if (file.Contains("AXSP") || file.Contains("SSMP"))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "SDF added:";
                lvi.ForeColor = Color.Gold;
                servoLV.Items.Add(lvi);
                
                lvi = new ListViewItem();
                lvi.Text = file;
                lvi.ForeColor = Color.Gold;
                servoLV.Items.Add(lvi);
                if ((addFileLV.FindItemWithText(file) == null))
                {
                    HighlightFlags(file, 's');
                }
                servoLV.Items.Add("==========");
            }
        }
        public void CheckSpecCond(string prevFile, string newFile)
        {
            checks.Add(() => CheckForServo(prevFile, newFile));
            checks.Add(() => CheckForIO(prevFile, newFile));
            checks.Add(() => CheckForAPI(prevFile, newFile));
            foreach (var c in checks)
            {
                c();
            }
            checks.Clear();
        }
        public void CheckSpecCond(string file)
        {
            checks.Add(() => CheckForServo(file));
            checks.Add(() => CheckForIO(file));
            checks.Add(() => CheckForAPI(file));
            foreach (var c in checks)
            {
                c();
            }
            checks.Clear();
        }
        public void CheckForIO(string prevFile, string newFile)
        {
            if ((prevFile.Contains("PIOD") && newFile.Contains("PIOD")) || (prevFile.Contains("SIOD") && newFile.Contains("SIOD")))
            {
                piodLV.Items.Add(prevFile);
                piodLV.Items.Add("---");
                piodLV.Items.Add(newFile);
                piodLV.Items.Add("==========");
                diff.AddIOFiles(prevFile);
                diff.AddIOFiles(newFile);
                
                if ((rollBackLV.FindItemWithText(prevFile) == null) && (rollBackLV.FindItemWithText(newFile) == null))
                {
                    HighlightFlags(prevFile, newFile, 'p');
                }
            }
        }
        public void CheckForIO(string file)
        {
            if (file.Contains("PIOD") || file.Contains("SIOD"))
            {
                piodLV.Items.Add(file);
                piodLV.Items.Add("==========");
                diff.AddIOFiles(file);
                if ((addFileLV.FindItemWithText(file) == null))
                {
                    HighlightFlags(file, 'p');
                }
            }
        }
        public void CheckForAPI(string prevFile, string newFile)
        {
            if (prevFile.Contains("App_THINC_API") && newFile.Contains("App_THINC_API"))
            {
                diff.ApiFlag = true;
            }
        }
        public void CheckForAPI(string file)
        {
            if (file.Contains("App_THINC_API"))
            {
                diff.ApiFlag = true;
            }
        }
        public void ChangeFlagColor()
        {
            if (rollBackLV.Items.Count != 0)
            {
                rollBackLV.BackColor = Color.Firebrick;
            }
            else
            {
                rollBackLV.BackColor = Color.DarkSeaGreen;
            }
            if(addFileLV.Items.Count != 0)
            {
                addFileLV.BackColor = Color.DarkKhaki;
            }
            else
            {
                addFileLV.BackColor = Color.DarkSeaGreen;
            }
            if (servoLV.Items.Count != 0)
            {
                servoLV.BackColor = Color.CornflowerBlue;
            }
            else
            {
                servoLV.BackColor = Color.DarkSeaGreen;
            }
            if (piodLV.Items.Count != 0)
            {
                piodLV.BackColor = Color.LightSalmon;
            }
            else
            {
                piodLV.BackColor = Color.DarkSeaGreen;
            }
            if (apiLB.Items.Count != 0)
            {
                apiLB.BackColor = Color.Red;
            }
            else
            {
                apiLB.BackColor = Color.DarkSeaGreen;
            }
            if (rulesLB.Items.Count > 0)
            {
                rulesLB.BackColor = Color.Firebrick;
            }
            else
            {
                rulesLB.BackColor = Color.DarkSeaGreen;
            }

        }



        //public string GetSpecCodeLabel(string specLine, int colNum)
        //{
        //    string specCode;
        //    if (colNum == 0)
        //    {
        //        specCode = specLine.Substring(0, 18);
        //        return specCode;
        //    }
        //    else
        //    {
        //        specCode = specLine.Substring(colNum * 20, 18);
        //        return specCode;
        //    }
        //}
        public bool HasSpecCode(string specType, int specNum, int specBit)
        {
            
            string[] specCode = new string[0];
            List<string> specList = new List<string>();
            switch (specType)
            {
                case "NC1":
                    specCode = dmc.NC1Hex.Split('-');
                    specList = dmc.GetNC1();
                    break;
                case "NCB1":
                    specCode = dmc.NCB1Hex.Split('-');
                    specList = dmc.GetNCB1();
                    break;
                case "NCB2":
                    specCode = dmc.NCB2Hex.Split('-');
                    specList = dmc.GetNCB2();
                    break;
                case "PLC1":
                    specCode = dmc.PLC1Hex.Split('-');
                    specList = dmc.GetPLC1();
                    break;
                case "PLC2":
                    specCode = dmc.PLC2Hex.Split('-');
                    specList = dmc.GetPLC2();
                    break;
                case "PLC3":
                    specCode = dmc.PLC3Hex.Split('-');
                    specList = dmc.GetPLC3();
                    break;
            }
            int index = (specNum - 1) / 2;
            int indexRemainder = specNum % 2;
            int decimalVal = 0;
            string hexValue = "";
            if (indexRemainder == 1)
            {
                hexValue = specCode[index].Substring(0, 2);
                decimalVal = Convert.ToInt32(hexValue, 16);
            }
            else if (indexRemainder == 0)
            {
                hexValue = specCode[index].Substring(2, 2);
                decimalVal = Convert.ToInt32(hexValue, 16);
            }
            int bitVal = 0;

            for(var i = 0;i <= specBit; i++)
            {
                bitVal = decimalVal % 2;
                decimalVal /= 2;
            }
            decimalVal = Convert.ToInt32(hexValue, 16);

            index = specNum / 8;
            indexRemainder = specNum % 8;
            if (indexRemainder == 0)
            {
                index -= 1;
            }
            else
            {
                indexRemainder = 8 - indexRemainder;
            }
            Int32.TryParse(dmc.GetSpecSepIndex(indexRemainder),out int sepIndex);
            sepIndex += 1;
            if (bitVal == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }
    
        public bool CheckOptionalRule(string machineTypeRule)
        {
            string[] splitRule = machineTypeRule.Split('|');
            for (var i = 0; i < splitRule.Count(); i++)
            {
                int categoryEndIndex = splitRule[i].IndexOf("]") + 1;
                switch (splitRule[i].Substring(0, categoryEndIndex))
                {
                    case "[NC]":
                        if (!CompNCVerCriteria(splitRule[i].Substring(categoryEndIndex + 1), dmc.NcVer, splitRule[i].Substring(categoryEndIndex, 1)))
                        {
                            return false;
                        }
                        break;

                    case "[PLC]":
                        if(!CompPLCVerCriteria(splitRule[i].Substring(categoryEndIndex + 1), dmc.PlcVer, splitRule[i].Substring(categoryEndIndex, 1)))
                        {
                            return false;
                        }
                           
                        break;

                    case "[PLCS]":

                        break;

                    case "[MPRM]":
                        if (!CompMPRMCriteria(splitRule[i].Substring(categoryEndIndex + 1), dmc.MPRM))
                        {
                            return false;
                        }
                        break;

                    case "[PLCUF]":
                        if (!CompPLCUFCriteria(splitRule[i].Substring(categoryEndIndex + 1), dmc.PLCUF))
                        {
                            return false;
                        }
                        break;

                    case "[PLTUA]":

                        break;

                    case "[SPEC CODE]":
                        if (!CompSpecCodeCriteria(splitRule[i].Substring(categoryEndIndex + 1)))
                        {
                            return false;
                        }
                        break;
                    case "[WINVERSION]":
                        if (!CompWinVerCriteria(splitRule[i].Substring(categoryEndIndex + 1), dmc.WinVersion))
                        {
                            return false;
                        }
                        break;
                    case "[VSYS]":
                        if (!CompVSYSCriteria(splitRule[i].Substring(categoryEndIndex + 1), dmc.Vsys, splitRule[i].Substring(categoryEndIndex, 1)))
                        {
                            return false;
                        }
                        break;
                   default:
                        return false;
                }
            }
            return true;
        } 
        

        //Rule checker criteria 3 subfunctions
        public bool CompWinVerCriteria(string ruleWinVersion, string dmcWinVersion)
        {
            int result = string.Compare(dmcWinVersion, ruleWinVersion);
            if (result != 0)
            {
                return false;
            }
            return true;
        }
        public bool CompVSYSCriteria( string ruleVSYSVersion, string dmcVSYSVersion, string comparator)
        {
            int result = string.Compare(dmcVSYSVersion, ruleVSYSVersion);
            switch (comparator)
            {
                case "=":
                    if( result != 0)
                    {
                        return false;
                    }
                    break;
                case "≥":
                    if (result == -1)
                    {
                        return false;
                    }
                    break;
                case "≤":
                    if (result == 1)
                    {
                        return false;
                    }
                    break;
                case "≠":
                    if (result == 0)
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }
        public bool CompPLCVerCriteria(string rulePLCVersion, string dmcPLCVersion, string comparator)
        {
            int result = string.Compare(dmcPLCVersion, rulePLCVersion);
            switch (comparator)
            {
                case "=":
                    if (result != 0)
                    {
                        return false;
                    }
                    break;

                case "≥":
                    if (result == -1)
                    {
                        return false;
                    }
                    break;
                case "≤":
                    if (result == 1)
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        public bool CompNCVerCriteria(string ruleNCVersion, string dmcNCVersion, string comparator)
        {
            int result = string.Compare(dmcNCVersion, ruleNCVersion);
            switch (comparator)
            {
                case "=":
                    if (result != 0)
                    {
                        return false;
                    }
                    break;

                case "≥":
                    if (result == -1)
                    {
                        return false;
                    }
                    break;
                case "≤":
                    if (result == 1)
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }
        public bool CompMPRMCriteria(string ruleMPRMVersion, string dmcMPRMVersion)
        {
            
            if (!ruleMPRMVersion.Contains("*") && string.Compare(dmcMPRMVersion, ruleMPRMVersion) != 0)
            {
                return false;
            }

            if (ruleMPRMVersion.Contains("*"))
            {
                int ruleMPRMwildcardIndex = ruleMPRMVersion.IndexOf("*");
                string trimmedDMCMPRM = dmcMPRMVersion.Substring(0, ruleMPRMwildcardIndex) + "*.PBU"; //+ dmcMPRMVersion.Substring(dmcMPRMVersion.Length -((ruleMPRMVersion.Length - 1) - ruleMPRMwildcardIndex));
                if (string.Compare(trimmedDMCMPRM, ruleMPRMVersion) != 0)
                {
                    return false;
                }
            }

            return true;
        }
        public bool CompSpecCodeCriteria(string ruleSpecCode)
        {
            string[] seperatedRule = ruleSpecCode.Split(':');
            int no = Int32.Parse(seperatedRule[1]);
            int bit = Int32.Parse(seperatedRule[2]);
            if (seperatedRule[3] == "OFF" && HasSpecCode(seperatedRule[0], no, bit))
            {
                return false;
            }

            if (seperatedRule[3] == "ON" && !HasSpecCode(seperatedRule[0], no, bit))
            {
                return false;
            }
            return true;
        }
        public bool CompPLCUFCriteria(string rulePLCUFVersion, string dmcPLCUFVersion)
        {
            if (!rulePLCUFVersion.Contains("*") && string.Compare(dmcPLCUFVersion, rulePLCUFVersion) != 0)
            {
                return false;
            }

            if (rulePLCUFVersion.Contains("*"))
            {
                int rulePLCUFwildcardIndex = rulePLCUFVersion.IndexOf("*");
                string trimmedDMCPLCUF = dmcPLCUFVersion.Substring(0, rulePLCUFwildcardIndex) + "*" + dmcPLCUFVersion.Substring(dmcPLCUFVersion.Length - ((rulePLCUFVersion.Length - 1) - rulePLCUFwildcardIndex));
                if (string.Compare(trimmedDMCPLCUF, rulePLCUFVersion) != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CompPLTUACriteria(string rulePLTUAVersion, string dmcPLTUAVersion)
        {
            if (!rulePLTUAVersion.Contains("*") && string.Compare(dmcPLTUAVersion, rulePLTUAVersion) != 0)
            {
                return false;
            }

            if (rulePLTUAVersion.Contains("*"))
            {
                int rulePLTUAwildcardIndex = rulePLTUAVersion.IndexOf("*");
                string trimmedDMCPLTUA = dmcPLTUAVersion.Substring(0, rulePLTUAwildcardIndex) + "*" + dmcPLTUAVersion.Substring(dmcPLTUAVersion.Length - ((rulePLTUAVersion.Length - 1) - rulePLTUAwildcardIndex));
                if (string.Compare(trimmedDMCPLTUA, rulePLTUAVersion) != 0)
                {
                    return false;
                }
            }
            return true;
        } //NEED TO TEST


        
        // Output log
    
        public void outputToLog(string outputRecord)
        {
            //string outputRecord
            string filePath = "C:\\Users\\corey\\Documents\\Okuma\\Diff_Tools\\outputLog.CSV";
            //string filePath = "\\\\nxfiler\\data05\\USR0\\Ospsoftw.are\\Diff_Tools\\outputLog.CSV";
            if (!File.Exists(filePath))
            {
                using (var sw = File.CreateText(filePath))
                {
                    sw.WriteLine("date/time,userName,PC,controlType,machineType,serialNumber,rollback,added,sdf,piod,api,custRule");
                }
            }
            using (var sw = File.AppendText(filePath))
            {
                sw.WriteLine(outputRecord);
            }
        }

        public string CreateOutputRecord()
        {
            string outputRecord = DateTime.Now.ToString() + "," + Environment.UserName + "," + Environment.MachineName + ","+ dmc.OSPType + "," + dmc.MachineType + "," + dmc.SerialNumber + ",";
            outputRecord += AddRollBackRecord() + ",";
            outputRecord += AddAddedRecord() + ",";
            outputRecord += AddSDFRecord() + ",";
            outputRecord += AddPIODRecord() + ",";
            outputRecord += AddAPIRecord() + ",";
            outputRecord += AddCustRuleRecord();
            return outputRecord;
        }

        public string AddRollBackRecord()
        {
            string rollBackRecord = "";
            if (rollBackLV.Items.Count > 0)
            {
                for (var i = 0; i < rollBackLV.Items.Count - 1; i++)
                {
                    if (rollBackLV.Items[i].Text == "==========")
                    {
                        rollBackRecord += "|";
                    }
                    else
                    {
                        rollBackRecord += rollBackLV.Items[i].Text;
                    }
                }
            }
            return rollBackRecord;
        }
        
        public string AddAddedRecord ()
        {
            string addedRecord = "";
            if (addFileLV.Items.Count > 1)
            {
                for (var i = 0; i < addFileLV.Items.Count - 1; i++)
                {
                    if (addFileLV.Items[i].Text == "==========") 
                    {
                        addedRecord += "|";
                    }
                    else
                    {
                        addedRecord += addFileLV.Items[i].Text;
                    }
                    
                }
            }
            return addedRecord;
        }

        public string AddSDFRecord()
        {
            string sdfRecord = "";
            if (servoLV.Items.Count > 0)
            {
                for (var i = 0; i < servoLV.Items.Count-1; i++)
                {
                    if (servoLV.Items[i].Text == "==========")
                    {
                        sdfRecord += "|";
                    }
                    else
                    {
                        sdfRecord += servoLV.Items[i].Text;
                    }
                }
            }
            return sdfRecord;
        }

        public string AddPIODRecord()
        {
            string piodRecord = "";
            if (piodLV.Items.Count > 0)
            {
                for (var i = 0; i < piodLV.Items.Count - 1; i++)
                {
                    if(piodLV.Items[i].Text == "==========")
                    {
                        piodRecord += "|";
                    }
                    else
                    {
                        piodRecord += piodLV.Items[i].Text;
                    }
                }
            }
            return piodRecord;
        }

        public string AddAPIRecord()
        {
            string apiRecord = "";
            if (apiLB.Items.Count > 0)
            {
                for (var i = 0; i < apiLB.Items.Count - 1; i++)
                {
                    if (apiLB.Items[i].ToString() == "==========")
                    {
                        apiRecord += "|";
                    }
                    else
                    {
                        apiRecord += apiLB.Items[i].ToString();
                    }
                }

            }
            return apiRecord;
        }

        public string AddCustRuleRecord()
        {
            string customRecord = "";
            if (rulesLB.Items.Count > 0)
            {
                for (var i = 0; i < rulesLB.Items.Count - 1; i++)
                {
                    if (rulesLB.Items[i].ToString() == "==========")
                    {
                        customRecord += "|";
                    }
                    else
                    {
                        customRecord += rulesLB.Items[i].ToString();
                    }
                }
            }
            customRecord = customRecord.Replace("\r", "");
            return customRecord;
        }


    }

}
