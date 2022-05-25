using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff_Tools
{
    public class Diff
    {
        private List<string> origFileContents = new List<string>();
        private List<string> trimFileContents = new List<string>();
        private List<string> hexIndex;
        private List<string> fileSection = new List<string>();
        private List<string> safetyFiles = new List<string>();
        private List<string> ioFiles = new List<string>();
        private string serialNumber = "";
        private string machineType = "";

        public void FillSerialAndTypeVar()
        {
            if (origFileContents[0].StartsWith("Machine Name="))
            {
                char[] separators = new char[] { ',', ',' };
                string[] value = origFileContents[0].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < value.Count(); i++)
                {
                    value[i] = value[i].Trim();
                    if (value[i].StartsWith("Machine Name="))
                    {
                        machineType = value[i].Substring((value[i].IndexOf("=") + 1));
                    }
                    else if (value[i].StartsWith("B#orP.NO.="))
                    {
                        serialNumber = value[i].Substring((value[i].IndexOf("=") + 1));
                    }
                }
            }
        }

        public string MachineType
        {
            get => machineType;
            set => machineType = value;
        }
       public string SerialNumber
        {
            get => serialNumber;
            set => serialNumber = value;
        }

        public string FileLocation
        { get; set; }

        public bool AotFlag
        { get; set; }

        public bool SafetyFlag
        { get; set; }

        public bool ApiFlag
        { get; set; }

        public List<string> GetIOFiles()
        {
            return ioFiles;
        }

        public string GetIOFiles(int index)
        {
            return ioFiles[index];
        }

        public void AddIOFiles(string value)
        {
            ioFiles.Add(value);
        }

        public List<string> GetFileSection()
        {
            return fileSection;
        }

        public string GetFileSection(int index)
        {
            return fileSection[index];
        }

        public void AddFileSection(string value)
        {
            fileSection.Add(value);
        }

        public void SetHexIndex(List<string> value)
        {
            hexIndex = value;
        }

        public List<string> GetHexIndex()
        {
            return hexIndex;
        }

        public string GetHexIndex(int index)
        {
            return hexIndex[index];
        }

        public List<string> GetTrimFileContents()
        {
            return trimFileContents;
        }

        public string GetTrimFileContents(int index)
        {
            return trimFileContents[index];
        }

        public void SetTrimFileContents(List<string> value)
        {
            trimFileContents = value;
        }

        public string GetOrigFileContents(int index)
        {
            return origFileContents[index];
        }

        public List<string> GetOrigFileContents()
        {
            return origFileContents;
        }

        public void AddOrigFileContents(string value)
        {
            origFileContents.Add(value);
        }


        public List<string> GetSafetyFiles()
        {
            return safetyFiles;
        }

        public string GetSafetyFiles(int index)
        {
            return safetyFiles[index];
        }

        public void AddSafetyFiles(string value)
        {
            safetyFiles.Add(value);
        }



    }
}
