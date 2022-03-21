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
        private bool listaFileExists = false;
        private bool dmcFileExists = false;
        private bool isLathe = false;

        private List<string> NC1 = new List<string>();
        private List<string> NCB1 = new List<string>();
        private List<string> NCB2 = new List<string>();
        private List<string> PLC1 = new List<string>();
        private List<string> PLC2 = new List<string>();
        private List<string> PLC3 = new List<string>();
        private List<string> specSepIndex = new List<string>();
        private List<string> origFileContents = new List<string>();
        private List<string> origDMCFileContents = new List<string>();
        private static readonly Regex regex = new Regex("[^a-zA-Z0-9.-]");
        private List<string> dmcLabel = new List<string> {"/(OSPN)", "/(MCN)", "/(BNO)", "/(PCG3)", "/(PCGA)", "/(CD1S)", "/(PCGN)", "/(NC1)", "/(NCB1)", "/(PLC1)",
                                                           "/(PLC2)"};

        public List<string> GetSpecSepIndex()
        {
            return specSepIndex;
        }

        public string GetSpecSepIndex(int index)
        {
            return specSepIndex[index];
        }
        public string getOrigDMCFileContents(int index)
        {
            return origDMCFileContents[index];
        }
        public void addOrigDMCFileContents(string value)
        {
            origDMCFileContents.Add(value);
        }
        public List<string> getNC1()
        {
            return NC1;
        }
        public string getNC1(int index)
        {
            return NC1[index];
        }

        public void addNC1(string value)
        {
            NC1.Add(value);
        }

        public List<string> getNCB1()
        {
            return NCB1;
        }
        public string getNCB1(int index)
        {
            return NCB1[index];
        }

        public void addNCB1(string value)
        {
            NCB1.Add(value);
        }

        public List<string> getNCB2()
        {
            return NCB2;
        }
        public string getNCB2(int index)
        {
            return NCB2[index];
        }

        public void addNCB2(string value)
        {
            NCB2.Add(value);
        }

        public List<string> getPLC1()
        {
            return PLC1;
        }
        public string getPLC1(int index)
        {
            return PLC1[index];
        }

        public void addPLC1(string value)
        {
            PLC1.Add(value);
        }

        public List<string> getPLC2()
        {
            return PLC2;
        }
        public string getPLC2(int index)
        {
            return PLC2[index];
        }

        public void addPLC2(string value)
        {
            PLC2.Add(value);
        }

        public List<string> getPLC3()
        {
            return PLC3;
        }
        public string getPLC3(int index)
        {
            return PLC3[index];
        }

        public void addPLC3(string value)
        {
            PLC3.Add(value);
        }

        public void FillSpecCodeList()
        {
            //grab NC spec code data
            int startIndex = origDMCFileContents.IndexOf("===========================[ NC-SPEC CODE No.1 ]==============================");
            for (var i = startIndex + 6;i <= startIndex + 80; i++)
            {
                NC1.Add(origDMCFileContents[i]);
            }

            startIndex = origDMCFileContents.IndexOf("===========================[ NC-SPEC CODE No.2 ]==============================");
            for (var i = startIndex + 6;i <= startIndex + 80; i++)
            {
                NCB1.Add(origDMCFileContents[i]);
            }

            startIndex = origDMCFileContents.IndexOf("===========================[ NC-SPEC CODE No.3 ]==============================");
            for (var i = startIndex + 6;i <= startIndex + 80; i++)
            {
                NCB2.Add(origDMCFileContents[i]);
            }

            startIndex = origDMCFileContents.IndexOf("===========================[ PLC-SPEC CODE No.1 ]=============================");
            for (var i = startIndex + 6;i <= startIndex + 80; i++)
            {
                PLC1.Add(origDMCFileContents[i]);
            }

            startIndex = origDMCFileContents.IndexOf("===========================[ PLC-SPEC CODE No.2 ]===========================");
            for (var i = startIndex + 6; i <= startIndex + 80; i++)
            {
                PLC2.Add(origDMCFileContents[i]);
            }

            startIndex = origDMCFileContents.IndexOf("===========================[ PLC-SPEC CODE No.3 ]===========================");
            for (var i = startIndex + 6; i <= startIndex + 80; i++)
            {
                PLC3.Add(origDMCFileContents[i]);
            }

            for (var i = 0; i <= NC1.Count - 1; i++)
            {
                if (NC1[i] == "==================  ==================  ==================  ==================" || NC1[i] == "------------------  ------------------  ------------------  ------------------")
                {
                    specSepIndex.Add(i.ToString());

                }
            }


        }
        public void fillClassVar()
        {
            bool varExist = true;
            int index;
            //if (FileLocation != "" && FileLocation != null  && ListaFileExists)
            //{
                for (var i = 0;i < dmcLabel.Count() - 2; i++)
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
                        dmcLabel.Add("/(NCB2)");
                        dmcLabel.Add("/(PLC3)");
                            isLathe = true;
                        }
                    }
                    else if (OSPType.EndsWith("M") || OSPType.EndsWith("MA") || OSPType.EndsWith("S") || OSPType.EndsWith("SA"))
                    {
                        if (origFileContents[origFileContents.IndexOf(dmcLabel[3]) + 2].StartsWith("MNC")) {
                            dmcLabel.Remove("/(PCGM)");
                            //dmcLabel.Remove("/(PLC3)");
                            fillClassVarMC();
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
                    NC1Hex = regex.Replace(origFileContents[index + 3] +"-"+ origFileContents[index + 5], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[8]);
                    NCB1Hex = regex.Replace(origFileContents[index + 3] + "-" + origFileContents[index + 5], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[9]);
                    PLC1Hex = regex.Replace(origFileContents[index + 3] + "-" + origFileContents[index + 5], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[10]);
                    PLC2Hex = regex.Replace(origFileContents[index + 3] + "-" + origFileContents[index + 5], string.Empty);
                    
                if(isLathe == true)
                {
                    index = origFileContents.IndexOf(dmcLabel[11]);
                    NCB2Hex = regex.Replace(origFileContents[index + 3] + "-" + origFileContents[index + 5], string.Empty);
                    index = origFileContents.IndexOf(dmcLabel[12]);
                    PLC3Hex = regex.Replace(origFileContents[index + 3] + "-" + origFileContents[index + 5], string.Empty);
                }
                }
                
            //}
        }
        public void fillClassVarMC()
        {
            int index = origFileContents.IndexOf("/(PBU-DAT)") + 2;
            while (origFileContents[index] != "*")
            {
                if (origFileContents[index].StartsWith("C:\\PBU-DAT\\PLCUF"))
                {
                    PLCUF = origFileContents[index].Substring(11, (origFileContents[index].Length - 4) - 11);
                } else if (origFileContents[index].StartsWith("C:\\PBU-DAT\\MPRM"))
                {
                    MPRM = origFileContents[index].Substring(11, (origFileContents[index].Length - 4) - 11);
                }

                index += 1;
            }

            index = origFileContents.IndexOf("/(CNS-DAT)") + 2;
            while (origFileContents[index] != "*")
            {
                if (origFileContents[index].StartsWith("C:\\OSP-P\\CNS-DAT\\PLTUA"))
                {
                    PLTUA = origFileContents[index].Substring(17, (origFileContents[index].Length - 4) - 17);
                }
                index += 1;
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

        public string PLC3Hex
        { get; set; }
        public string PLC2Hex
        { get; set; }
        public string PLC1Hex
        { get; set; }
        public string NCB2Hex
        { get; set; }
        public string NC1Hex
        {
            get; set;
        }

        public string NCB1Hex
        { get; set; }

        public string PLTUA  //ATC Logic File
        { get; set; }

        public string MPRM //Low speed backup file
        { get; set; }
        public string PLCUF //User PLC Spec
        { get; set; }
        public string WinVersion
        { get; set; }
        public string OSPType
        { get; set; }
        public string MachineType
        { get; set; }
        public bool ListaFileExists
        { get; set; }
        public bool DMCFileExists
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
