using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entAnciTesting
    {
        public bool chkDDSTPerformed { get; set; }
        public bool chkDDSTNotPerformed { get; set; }
        public string txtDDSTDescription { get; set; }

        public bool chkDDSTOrdered { get; set; }
        public bool chkDDSTNotOrdered { get; set; }

        public bool chkDefault { get; set; }
        public bool chkEKGPerformed { get; set; }
        public bool chkEKGNotPerformed { get; set; }
        public string txtEKGDescription { get; set; }
        public bool chkEKGOrdered { get; set; }
        public bool chkEKGNotOrdered { get; set; }


        public bool chkLabsPerformed { get; set; }
        public bool chkLabsNotPerformed { get; set; }
        public string txtLabsDescription { get; set; }
        public bool chkLabsOrdered { get; set; }
        public bool chkLabsNotOrdered { get; set; }

        public bool chkPFTPerformed { get; set; }
        public bool chkPFTNotPerformed { get; set; }
        public string txtPFTDescription { get; set; }
        public bool chkPFTOrdered { get; set; }
        public bool chkPFTNotOrdered { get; set; }

        public bool chkXraysPerformed { get; set; }
        public bool chkXraysNotPerformed { get; set; }
        public string txtXrayDescription { get; set; }
        public string GrammerText { get; set; }
        public bool chkXraysOrdered { get; set; }
        public bool chkXraysNotOrdered { get; set; }


        public bool chkDopplerPerformed { get; set; }
        public bool chkDopplerNotPerformed { get; set; }
        public string txtDopplerDescription { get; set; }
        public string UserName { get; set; }
        public bool chkDopplerOrdered { get; set; }
        public bool chkDopplerNotOrdered { get; set; }

        public string FormType { get; set; }

    }
}
