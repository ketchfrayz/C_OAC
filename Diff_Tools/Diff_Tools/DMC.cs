using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Diff_Tools
{
    public class DMC
    {
        private string fileLocation = "";
        private bool fileExists = false;
        private bool isLathe = false;
        private string NC1;
        private string NCB1;
        private string NCB2;
        private string PLC1;
        private string PLC2;
        private string PLC3;
        private List<string> origFileContents = new List<string>();
        private static readonly Regex regex = new Regex("[^a-zA-Z0-9.-]");
        private List<string> dmcLabel = new List<string> {"/(OSPN)", "/(MCN)", "/(BNO)", "/(PCG3)", "/(PCGA)", "/(CD1S)", "/(PCGN)", "/(NC1)", "/(NCB1)", "/(NCB2)", "/(PLC1)",
                                                           "/(PLC2)", "/(PLC3)"};
        public void fillClassVar()
        {
            bool varExist = true;
            int index;
            if (FileLocation != "" && FileLocation != null  && FileExists)
            {
                for (var i = 0;i < dmcLabel.Count() - 1; i++)
                {
                    if (origFileContents.Contains(dmcLabel[i]) && varExist != false)
                    {
                        varExist = true;
                    }
                    else
                    {
                        varExist = false;
                    }
                }
                
                if (varExist == true)
                {
                    index = origFileContents.IndexOf(dmcLabel[0]);
                    OSPType = origFileContents[index + 2];
                    OSPType = OSPType.Replace("OSP-", "");
                    if (OSPType.EndsWith("-R"))
                    {
                        OSPType = OSPType.Replace("-R", "");
                    }
                    if (OSPType.EndsWith("L")  || OSPType.EndsWith("LA") || OSPType.EndsWith("S") || OSPType.EndsWith("SA"))
                    {
                        if (origFileContents[origFileContents.IndexOf(dmcLabel[3]) + 2].StartsWith("LNC"))
                        {
                            dmcLabel.Remove("/(PCGN)");
                            dmcLabel.Insert(6, "/(PCGM)");
                            isLathe = true;
                        }
                    }
                    else if (OSPType.EndsWith("M") || OSPType.EndsWith("MA") || OSPType.EndsWith("S") || OSPType.EndsWith("SA"))
                    {
                        if (origFileContents[origFileContents.IndexOf(dmcLabel[3]) + 2].StartsWith("MNC")) {
                            dmcLabel.Remove("/(PCGM)");
                            isLathe = false;
                        }
                    }
                    if (origFileContents.Contains("/(CDAD001)"))
                    {
                        index = origFileContents.IndexOf("/(CDAD001)");
                        ApiVer = regex.Replace(origFileContents[index + 1], string.Empty);
                        ApiVer = ApiVer.Substring(ApiVer.IndexOf("V") + 1);
                        ApiVer = ApiVer.Replace("P", "");
                        ApiVer = (ApiVer.Contains("-") ? ApiVer.Substring(0, ApiVer.IndexOf("-")).Replace("P", "") : ApiVer.Replace("P", ""));
                    }
                    else
                    {
                        ApiVer = "NONE";
                    }
                    index = origFileContents.IndexOf(dmcLabel[1]);
                    MachineType = regex.Replace(origFileContents[index + 2], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[2]);
                    SerialNumber = regex.Replace(origFileContents[index + 2], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[3]);
                    NcVer = regex.Replace(origFileContents[index + 2], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[4]);
                    PlcVer = regex.Replace(origFileContents[index + 2], string.Empty);                                       
                    index = origFileContents.IndexOf(dmcLabel[5]);
                    WinVersion = regex.Replace(origFileContents[index + 1], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[6]);
                    ApiLibVer = regex.Replace(origFileContents[index + 2],string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[7]);
                    NC1 = regex.Replace(origFileContents[index + 3] +"-"+ origFileContents[index + 5], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[8]);
                    NCB1 = regex.Replace(origFileContents[index + 3] + "-" + origFileContents[index + 5], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[9]);
                    NCB2 = regex.Replace(origFileContents[index + 3] + "-" + origFileContents[index + 5], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[10]);
                    PLC1 = regex.Replace(origFileContents[index + 3] + "-" + origFileContents[index + 5], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[11]);
                    PLC2 = regex.Replace(origFileContents[index + 3] + "-" + origFileContents[index + 5], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[12]);
                    PLC3 = regex.Replace(origFileContents[index + 3] + "-" + origFileContents[index + 5], string.Empty);
                }
                
            }
        }
        //public bool checkAPIVersion()
        //{
        //    if (isLathe && ApiVer.Contains("1.23.1.0"))
        //    {
        //        int apiCompare = string.Compare(ApiLibVer, "LCAPI-003Y", StringComparison.OrdinalIgnoreCase);
        //        int ncCompare = string.Compare()

                
        //    }              
            
        //}
        public string WinVersion
        { get; set; }
        public string OSPType
        { get; set; }
        public string MachineType
        { get; set; }
        public bool FileExists
        { get; set; }
        public string FileLocation
        { get; set; }

        public string SerialNumber
        { get; set; }

        public string NcVer
        { get; set; }

        public string PlcVer
        { get; set; }

        public string ApiVer
        { get; set; }

        public string ApiLibVer
        { get; set; }

        public string getOrigFileContents(int index)
        {
            return origFileContents[index];
        }

        public List<string> getOrigFileContents()
        {
            return origFileContents;
        }

        public void addOrigFileContents(string value)
        {
            origFileContents.Add(value);
        }

     

    }
}
