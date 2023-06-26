using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using iText.Kernel.Exceptions;

namespace Diff_Tools
{
    public class DMC
    {
       
        public List<string> NC1 { get; set; }
        public List<string> NCB1 { get; set; }
        public List<string> NCB2 { get; set; }
        public List<string> PLC1 { get; set; }
        public List<string> PLC2 { get; set; }
        public List<string> PLC3 { get; set; }
        public List<string> ETC { get; set; }
        public List<string> PBUDAT { get; set; }
        public List<string> CNSDAT { get; set; }
        public List<string> SpecSepIndex { get; set; }
        public List<string> OrigLISTAFileContents { get; set; }
        public List<string> OrigDMCFileContents { get; set; }
        private static readonly Regex regex = new Regex("[^a-zA-Z0-9.-]");
        private List<string> dmcLabel = new List<string> {"/(OSPN)", "/(MCN)", "/(BNO)", "/(PCG3)", "/(PCGA)", "/(CD1S)", "/(PCGN)", "/(NC1)", "/(NCB1)", "/(PLC1)",
                                                          "/(PLC2)", "/(PCG2)", "/(PBU-DAT)", "/(CNS-DAT)", "/(ETC)"};
        //private readonly string[] LatheLISTALabel =  { "/(PCGF)", "/(PCGJ)", "/(PCGL)", "/(PCGM)", "/(PCGS)", "/(PCGB)", "/(PCGK)", "/(PCGV)", "/(PCGW)", "/(PCG00)", "/(ETC)" };
        //private readonly string[] MCLISTALabel = { "/(PCGS)", "/(PCGT)", "/(PCGU)", "/(PCGH)", "/(PCGK)", "/(PCGM)", "/(PCGN)", "/(PCGX)", "/(PCGQ)", "/(PCGR)", "/(PCGL)", "/(PCGC)", "/(PCGD)", "/(PCG02)", "/(ETC)" };
        private string[] controlTypePattern = { "\\-H$", "\\-R$", "\\-E$" };
        private static readonly string[] latheMachineTypePattern = new string[] {"II$", "IIM$", "IIMY$", "IIMW$", "IIMYW$", "IIW$", "\\-e$", "\\-eE$", "\\-M$", "\\-MY$", "\\-MYW$","M$", "MY$", "MYW$",
                                                                                 "MW$", "W$", "\\-W$", "\\-eMYE$", "\\-eME$", "L$" };

        public DMC()    // DMC class constructor
        {
            NC1 = new List<string>();
            NCB1 = new List<string>();
            NCB2 = new List<string>();
            PLC1 = new List<string>();
            PLC2 = new List<string>();
            PLC3 = new List<string>();
            ETC = new List<string>();
            PBUDAT = new List<string>();
            CNSDAT = new List<string>();
            SpecSepIndex = new List<string>();
            OrigLISTAFileContents = new List<string>();
            OrigDMCFileContents = new List<string>();
        }
        public bool IsBSpecPLC(string plcVer)
        {

            if (plcVer == "")
            {
                return false;
            }
            if(plcVer.Substring(4,1) != "Z")
            {
                return false;
            }
            return true;
        }

        public bool IsBSpecNC(string ncVer)
        {
            string[] splitNCVer = ncVer.Split('-');
            if (splitNCVer[0] == "LNC") { 

                if( splitNCVer.Count() < 4)
                {
                    return false;
                }
                if (!splitNCVer[3].StartsWith("Z"))
                {
                    return false;
                }
            }

            if (splitNCVer[0] == "MNC")
            {
                if (!splitNCVer[2].StartsWith("Z"))
                {
                    return false;
                }
            }
            return true;
        }

        private string TrimMachineType(string machineType)
        {
            if (machineType == "L400II" || machineType == "L250II" || machineType == "MB-5000HII" || machineType == "MA-500HII" || machineType == "MA-600HII" || machineType == "V80L" || machineType == "V100L" || machineType == "LB35II" || machineType == "LB35III" || machineType == "LB45II" || machineType == "LB45III")
            {
                return machineType;
            }
            string outputMT = "";
            for (var i = 0; i < latheMachineTypePattern.Length; i++)
            {
                Regex machineTypeReg = new Regex(latheMachineTypePattern[i], RegexOptions.IgnoreCase);
                if (machineTypeReg.IsMatch(machineType))
                {
                    outputMT = Regex.Replace(machineType, latheMachineTypePattern[i], "");
                    break;
                }
            }
            if (outputMT != "") 
            { 

                return outputMT;
            }
            else
            {
                return machineType;
            }
        }
        public List<string> GetNC1()
        {
            return NC1;
        }

        public List<string> GetNCB1()
        {
            return NCB1;
        }

        public string GetPBUDAT(int index)
        {
            return PBUDAT[index];
        }

        public List<string> GetPBUDAT()
        {
            return PBUDAT;
        }

        public List<string> GetCNSDAT()
        {
            return CNSDAT;
        }

        public string GetCNSDAT(int index)
        {
            return CNSDAT[index];
        }

        public List<string> GetETC()
        {
            return ETC;
        }

        public string GetETC(int index)
        {
            return ETC[index];
        }

        public List<string> GetNCB2()
        {
            return NCB2;
        }

        public List<string> GetPLC1()
        {
            return PLC1;
        }

        public List<string> GetPLC2()
        {
            return PLC2;
        }

        public List<string> GetPLC3()
        {
            return PLC3;
        }

        public void FillSpecCodeList()
        {
            //grab NC spec code data
            var startIndex = OrigDMCFileContents.IndexOf("===========================[ NC-SPEC CODE No.1 ]==============================");
            for (var i = startIndex + 6; i <= startIndex + 80; i++)
            {
                NC1.Add(OrigDMCFileContents[i]);
            }

            startIndex = OrigDMCFileContents.IndexOf("===========================[ NC-SPEC CODE No.2 ]==============================");
            for (var i = startIndex + 6; i <= startIndex + 80; i++)
            {
                NCB1.Add(OrigDMCFileContents[i]);
            }

            startIndex = OrigDMCFileContents.IndexOf("===========================[ NC-SPEC CODE No.3 ]==============================");
            for (var i = startIndex + 6; i <= startIndex + 80; i++)
            {
                NCB2.Add(OrigDMCFileContents[i]);
            }

            startIndex = OrigDMCFileContents.IndexOf("===========================[ PLC-SPEC CODE No.1 ]=============================");
            for (var i = startIndex + 6; i <= startIndex + 80; i++)
            {
                PLC1.Add(OrigDMCFileContents[i]);
            }

            startIndex = OrigDMCFileContents.IndexOf("===========================[ PLC-SPEC CODE No.2 ]===========================");
            for (var i = startIndex + 6; i <= startIndex + 80; i++)
            {
                PLC2.Add(OrigDMCFileContents[i]);
            }

            startIndex = OrigDMCFileContents.IndexOf("===========================[ PLC-SPEC CODE No.3 ]===========================");
            for (var i = startIndex + 6; i <= startIndex + 80; i++)
            {
                PLC3.Add(OrigDMCFileContents[i]);
            }

            for (var i = 0; i <= NC1.Count - 1; i++)
            {
                if (NC1[i] == "==================  ==================  ==================  ==================" || NC1[i] == "------------------  ------------------  ------------------  ------------------")
                {
                    SpecSepIndex.Add(i.ToString());

                }
            }


        }

        public bool IsLathe(string controlType)
        {
            if (controlType.EndsWith("M") || controlType.EndsWith("MA"))
            {
                return false;
            }

            if (OrigLISTAFileContents[OrigLISTAFileContents.IndexOf(dmcLabel[3]) + 2].StartsWith("MNC"))
            {
                return false;
            }
            return true;
        }

        private void FillClassVarCtrlType(int index)
        {
            OSPType = TrimControlType(OrigLISTAFileContents[index + 2]);
        }

        private void FillClassVarAPI(int index)
        {
            if (index != -1)
            {
                ApiVer = regex.Replace(OrigLISTAFileContents[index + 1], string.Empty);
                ApiVer = ApiVer.Substring(ApiVer.IndexOf("V") + 1);
                ApiVer = ApiVer.Replace("P", "");
                ApiVer = ApiVer.Replace("W", "");
                ApiVer = (ApiVer.Contains("-") ? ApiVer.Substring(0, ApiVer.IndexOf("-")).Replace("P", "") : ApiVer.Replace("P", ""));
            }
            else
            {
                ApiVer = "NONE";
            }
        }

        private void FillClassVarMchType(int index)
        {
            MachineType = TrimMachineType(regex.Replace(OrigLISTAFileContents[index + 2], string.Empty));
        }

        private void FillClassVarVSYS(int index)
        {
            Vsys = regex.Replace(OrigLISTAFileContents[index + 2], string.Empty);
        }

        private void FillClassVarSerialNo(int index)
        {
            SerialNumber = regex.Replace(OrigLISTAFileContents[index + 2], string.Empty);
        }

        private void FillClassVarNcVer(int index)
        {
            NcVer = regex.Replace(OrigLISTAFileContents[index + 2], string.Empty);
            IsBSpecNC(NcVer);
        }

        private void FillClassVarPLCVer(int index)
        {
            PlcVer = regex.Replace(OrigLISTAFileContents[index + 2], string.Empty);
            IsBSpecPLC(PlcVer);
        }

        private void FillClassVarWinVersion(int index)
        {
            WinVersion = regex.Replace(OrigLISTAFileContents[index + 1], string.Empty);
        }

        private void FillClassVarAPILibVer(int index)
        {
            ApiLibVer = regex.Replace(OrigLISTAFileContents[index + 2], string.Empty);
        }

        private void FillClassVarNC1Hex(int index)
        {
            NC1Hex = regex.Replace(OrigLISTAFileContents[index + 3] + "-" + OrigLISTAFileContents[index + 5], string.Empty);
        }

        private void FillClassVarNCB1Hex(int index)
        {
            NCB1Hex = regex.Replace(OrigLISTAFileContents[index + 3] + "-" + OrigLISTAFileContents[index + 5], string.Empty);
        }

        private void FillClassVarNCB2Hex(int index)
        {
            NCB2Hex = regex.Replace(OrigLISTAFileContents[index + 3] + "-" + OrigLISTAFileContents[index + 5], string.Empty);
        }

        private void FillClassVarPLC1Hex(int index)
        {
            PLC1Hex = regex.Replace(OrigLISTAFileContents[index + 3] + "-" + OrigLISTAFileContents[index + 5], string.Empty);
        }

        private void FillClassVarPLC2Hex(int index)
        {
            PLC2Hex = regex.Replace(OrigLISTAFileContents[index + 3] + "-" + OrigLISTAFileContents[index + 5], string.Empty);
        }

        private void FillClassVarPLC3Hex(int index)
        {
            PLC3Hex = regex.Replace(OrigLISTAFileContents[index + 3] + "-" + OrigLISTAFileContents[index + 5], string.Empty);
        }

        private void FillClassVarINST(int index)
        {
            INST = regex.Replace(OrigLISTAFileContents[index + 2], string.Empty);
        }

        private void FillClassVarVDRV(int index)
        {
            VDRV = regex.Replace(OrigLISTAFileContents[index + 2], string.Empty);
        }

        private string ShortenPathName(string path)
        {
            string[] splitString = path.Split('\\');    // split string by '\', last item in list is file name
            splitString[splitString.Count() - 1] = splitString[splitString.Count() - 1].Substring(0, splitString[splitString.Count() - 1].Length - 4);  // Remove file extension
            return splitString[splitString.Count() - 1];
        }

        private void FillClassVarCNSDAT(int index)
        {
            var i = index + 2;
            while (OrigLISTAFileContents[i] != "*")
            {
                CNSDAT.Add(ShortenPathName(OrigLISTAFileContents[i]));
                i++;
            }
        }

        private void FillClassVarPBUDAT(int index)
        {
            var i = index + 2;
            //string[] splitstring;
            while (OrigLISTAFileContents[i] != "*")    // Loop until end of PBU-DAT block
            {
                PBUDAT.Add(ShortenPathName(OrigLISTAFileContents[i]));
                i++;
            }
        }
        private void FillClassVarETC(int index)
        {
            var i = index + 2;
            string fileExt;

            while (OrigLISTAFileContents[i] != "*")     // Loop until end of Var block
            {

                fileExt = OrigLISTAFileContents[i].Substring(OrigLISTAFileContents[i].Length - 4);
                if (fileExt != ".DEF" && fileExt != ".CNC" && fileExt != ".INI"  && fileExt != ".BMP")          // If file is .CNS or .PBU
                {   
                    ETC.Add(ShortenPathName(OrigLISTAFileContents[i]));                                             // Remove path and add filename to the list
                }
                i++;
            }
        }
        public void FillClassVar()
        {

                    FillClassVarCtrlType(OrigLISTAFileContents.IndexOf(dmcLabel[0]));

                    if (IsLathe(OSPType))
                    {
                        dmcLabel.Remove("/(PCGN)");
                        dmcLabel.Insert(6, "/(PCGM)");
                    }
                    else
                    {
                            dmcLabel.Remove("/(PCGM)");
                            FillClassVarMC();  
                    }
                    
                    FillClassVarAPI(OrigLISTAFileContents.IndexOf("/(CDAD001)"));
                    FillClassVarMchType(OrigLISTAFileContents.IndexOf(dmcLabel[1]));              
                    FillClassVarSerialNo(OrigLISTAFileContents.IndexOf(dmcLabel[2]));                  
                    FillClassVarNcVer(OrigLISTAFileContents.IndexOf(dmcLabel[3]));
                    FillClassVarPLCVer(OrigLISTAFileContents.IndexOf(dmcLabel[4]));
                    FillClassVarWinVersion(OrigLISTAFileContents.IndexOf(dmcLabel[5]));
                    FillClassVarAPILibVer(OrigLISTAFileContents.IndexOf(dmcLabel[6]));
                    FillClassVarNC1Hex(OrigLISTAFileContents.IndexOf(dmcLabel[7]));
                    FillClassVarNCB1Hex(OrigLISTAFileContents.IndexOf(dmcLabel[8]));
                    FillClassVarPLC1Hex(OrigLISTAFileContents.IndexOf(dmcLabel[9]));
                    FillClassVarPLC2Hex(OrigLISTAFileContents.IndexOf(dmcLabel[10]));
                    FillClassVarVSYS(OrigLISTAFileContents.IndexOf(dmcLabel[11]));
                    FillClassVarPBUDAT(OrigLISTAFileContents.IndexOf(dmcLabel[12]));
                    FillClassVarCNSDAT(OrigLISTAFileContents.IndexOf(dmcLabel[13]));
                    FillClassVarETC(OrigLISTAFileContents.IndexOf(dmcLabel[14]));

            if (OrigLISTAFileContents.Contains("/(NCB2)"))
            {
                dmcLabel.Add("/(NCB2)");
                FillClassVarNCB2Hex(OrigLISTAFileContents.IndexOf(dmcLabel[15]));
            }
            if (OrigLISTAFileContents.Contains("/(PLC3)")) 
            {
                dmcLabel.Add("/(PLC3)");
                FillClassVarPLC3Hex(OrigLISTAFileContents.IndexOf(dmcLabel[dmcLabel.Count - 1]));
            }
            
        }
        public void FillClassVarMC()
        {
            var index = OrigLISTAFileContents.IndexOf("/(PBU-DAT)") + 2;
            while (OrigLISTAFileContents[index] != "*")
            {
                if (OrigLISTAFileContents[index].StartsWith("C:\\PBU-DAT\\PLCUF"))
                {
                    PLCUF = OrigLISTAFileContents[index].Substring(11, (OrigLISTAFileContents[index].Length - 4) - 11);
                } else if (OrigLISTAFileContents[index].StartsWith("C:\\PBU-DAT\\MPRM"))
                {
                    MPRM = OrigLISTAFileContents[index].Substring(11, (OrigLISTAFileContents[index].Length - 4) - 11);
                }

                index += 1;
            }

            index = OrigLISTAFileContents.IndexOf("/(CNS-DAT)") + 2;
            while (OrigLISTAFileContents[index] != "*")
            {
                if (OrigLISTAFileContents[index].StartsWith("C:\\OSP-P\\CNS-DAT\\PLTUA"))
                {
                    PLTUA = OrigLISTAFileContents[index].Substring(17, (OrigLISTAFileContents[index].Length - 4) - 17);
                }
                index += 1;
            }
        }

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

        public string INST 
        { get; set; }
        public string VDRV 
        { get; set; }
        public string PLCS
        { get; set; }
        public string OneTouchIGF
        { get; set; }
        public string OneTouchIGFMessage
        { get; set; }
        public string NCAlarmHelp
        { get; set; }
        public string NCManual
        { get; set; }
        public string SVFKA
        { get; set; }
        public string VerticalFunctionKeyMessage
        { get; set; }
        public string CAS
        { get; set; }
        public string EasyModelling
        { get; set; }
        public string SFTY
        { get; set; }
        public string OSPSuite
        { get; set; }
        public string OSPSuiteUtility
        { get; set; }
        public string CycleTimeReduction
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
        public string Vsys
        {
            get;set;
        }
        public string TrimControlType(string controlType)
        {
            for(var i = 0; i < controlTypePattern.Length; i++)
            {
                Regex controlTypeReg = new Regex(controlTypePattern[i], RegexOptions.IgnoreCase);
                if (controlTypeReg.IsMatch(controlType))
                {
                    string outputCT = Regex.Replace(controlType, controlTypePattern[i], "");
                    
                    return outputCT.Replace("OSP-", "");
                }
            }
            return controlType.Replace("OSP-", "");
        }

     

    }
}
