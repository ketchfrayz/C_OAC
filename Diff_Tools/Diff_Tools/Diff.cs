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
        private bool aotFlag = false;
        private bool safetyFlag = false;
        private bool apiFlag = false;
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

        public List<string> getioFiles()
        {
            return ioFiles;
        }

        public string getioFiles(int index)
        {
            return ioFiles[index];
        }

        public void addioFiles(string value)
        {
            ioFiles.Add(value);
        }

        public List<string> getFileSection()
        {
            return fileSection;
        }

        public string getFileSection(int index)
        {
            return fileSection[index];
        }

        public void addFileSection(string value)
        {
            fileSection.Add(value);
        }

        public void setHexIndex(List<string> value)
        {
            hexIndex = value;
        }

        public List<string> getHexIndex()
        {
            return hexIndex;
        }

        public string getHexIndex(int index)
        {
            return hexIndex[index];
        }

        public List<string> getTrimFileContents()
        {
            return trimFileContents;
        }

        public string getTrimFileContents(int index)
        {
            return trimFileContents[index];
        }

        public void setTrimFileContents(List<string> value)
        {
            trimFileContents = value;
        }

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


        public List<string> getSafetyFiles()
        {
            return safetyFiles;
        }

        public string getSafetyFiles(int index)
        {
            return safetyFiles[index];
        }

        public void addSafetyFiles(string value)
        {
            safetyFiles.Add(value);
        }



    }
}
