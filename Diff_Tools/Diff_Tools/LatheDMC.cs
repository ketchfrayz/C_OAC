using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff_Tools
{
    internal class LatheDMC : DMC
    {
        // [PBU-DAT]

        public string LPRM { get; set; } // Low speed backup data file
        public string LMCNDTA { get; set; } // High speed backup data file
        public string PLCUA { get; set; } // PLC variable data

        public string PLCUD { get; set; } // PLC axis data

        public string PLCUF { get; set; } // PLC-HMI backup data

        public string PLCUH { get; set; } //ECO suite auxiliary power change

        public string LRKUA { get; set; } // ** One touch IGF/Advanced OT-IGF Parameter data file (mm)

        public string LRKUB { get; set; } // ** One touch IGF/Advanced OT-IGF Parameter data file (mm)


        // [CNS-DAT]

        public string SLGC0 { get; set; } // Safety logic
        public string PLCUB { get; set; } // PLC constant data (PLC spec code)
        public string PLCUC { get; set; } // M-code data file
        public string PMCA { get; set; } // PLC alarm message
        public string PFCUA { get; set; } // PLC download parameter
        public string PMIO { get; set; } // MTB screen I/O address conversion data

        public List<string> HMI { get; set; }
        public List<string> PBU_DAT { get; set; }
        public List<string> CNS_DAT { get; set; }  

    }
}
