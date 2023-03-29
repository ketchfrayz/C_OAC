using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff_Tools
{
    public class Diff
    {

        public List<string> OrigFileContents { get; set; }
        public List<string> TrimFileContents { get; set; }
        public List<string> HexIndex { get; set; }
        public List<string> FileSection { get; set; }
        private List<string> safetyFiles;
        public List<string> IoFiles { get; set; }

        public Diff()
        {

            OrigFileContents = new List<string>();
            TrimFileContents = new List<string>();
            HexIndex = new List<string>();
            FileSection = new List<string>();
            IoFiles = new List<string>();
            safetyFiles = new List<string>();

        }
        public void FillSerialAndTypeVar()
        {
            if (OrigFileContents[0].StartsWith("Machine Name="))
            {
                char[] separators = new char[] { ',', ',' };
                string[] value = OrigFileContents[0].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < value.Count(); i++)
                {
                    value[i] = value[i].Trim();
                    if (value[i].StartsWith("Machine Name="))
                    {
                        MachineType = value[i].Substring((value[i].IndexOf("=") + 1));
                    }
                    else if (value[i].StartsWith("B#orP.NO.="))
                    {
                        SerialNumber = value[i].Substring((value[i].IndexOf("=") + 1));
                    }
                }
            }
        }

        public string SerialNumber { get; set; }

        public string MachineType { get; set; }

        public string FileLocation
        { get; set; }

        public bool SafetyFlag
        { get; set; }

        public bool ApiFlag
        { get; set; }
        public List<string> GetSafetyFiles()
        {
            return safetyFiles;
        }

        public void AddSafetyFiles(string value)
        {
            safetyFiles.Add(value);
        }



    }
}
