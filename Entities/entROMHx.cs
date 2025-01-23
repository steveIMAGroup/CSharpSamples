using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entROMHx
    {
        public string numROMSpineCervicalFlexion { get; set; }
        public string numROMSpineCervicalExtension { get; set; }
        public string numROMSpineCervicalLateralFlexionRight { get; set; }
            public string numROMSpineCervicalLateralFlexionLeft { get; set; }
        public string numROMSpineCervicalRotation { get; set; }
        public string numROMSpineLumbarForwardFlexion { get; set; }
        public string numROMSpineLumbarForwardExtension { get; set; }

        public string numROMSpineLumbarForwardExtensionRight { get; set; }
        public string numROMSpineLumbarForwardExtensionLeft { get; set; }

        public string numROMSpineLumbarLateralFlexionRight { get; set; }
    public string numROMSpineLumbarLateralFlexionLeft { get; set; }
    public string numROMUpperExtremityShoulderAbductionRight { get; set; }
    public string numROMUpperExtremityShoulderAbductionLeft { get; set; }
    public string numROMUpperExtremityShoulderAdductionRight { get; set; }
    public string numROMUpperExtremityShoulderAdductionLeft { get; set; }
    public string numROMUpperExtremityShoulderForwardElevationRight { get; set; }
    public string numROMUpperExtremityShoulderForwardElevationLeft { get; set; }
    public string numROMUpperExtremityShoulderInternalRotationRight { get; set; }
    public string numROMUpperExtremityShoulderInternalRotationLeft { get; set; }
    public string numROMUpperExtremityShoulderExternalRotationRight { get; set; }
    public string numROMUpperExtremityShoulderExternalRotationLeft { get; set; }
    public string numROMUpperExtremityElbowFlexionRight { get; set; }
    public string numROMUpperExtremityElbowFlexionLeft { get; set; }
    public string numROMUpperExtremityElbowSupinationRight { get; set; }
    public string numROMUpperExtremityElbowSupinationLeft { get; set; }
    public string numROMUpperExtremityElbowPronationRight { get; set; }
    
    public string numROMUpperExtremityElbowPronationLeft { get; set; }
    public string numROMUpperExtremityWristDorsiflexionRight { get; set; }
    public string numROMUpperExtremityWristDorsiflexionLeft { get; set; }
    public string numROMUpperExtremityWristPalmarFlexionRight { get; set; }
    public string numROMUpperExtremityWristPalmarFlexionLeft { get; set; }

    public string numROMLowerExtremityKneeFlexionRight { get; set; }
    public string numROMLowerExtremityKneeFlexionLeft { get; set; }
    public string numROMLowerExtremityKneeExtensionRight { get; set; }
    public string numROMLowerExtremityKneeExtensionLeft { get; set; }

    public string numROMLowerExtremityKneeExtension { get; set; }

    public string numROMLowerExtremityHipAbductionRight { get; set; }
    public string numROMLowerExtremityHipAbductionLeft { get; set; }
    public string numROMLowerExtremityHipAdductionRight { get; set; }
    public string numROMLowerExtremityHipAdductionLeft { get; set; }
    public string numROMLowerExtremityHipFlexionRight { get; set; }
    public string numROMLowerExtremityHipFlexionLeft { get; set; }
    public string numROMLowerExtremityHipInternalRotationRight { get; set; }
     public string numROMLowerExtremityHipInternalRotationLeft { get; set; }
     public string numROMLowerExtremityHipExternalRotationRight { get; set; }
     public string numROMLowerExtremityHipExternalRotationLeft { get; set; }
     public string numROMLowerExtremityHipExtensionRight { get; set; }
     public string numROMLowerExtremityHipExtensionLeft { get; set; }
     public string numROMLowerExtremityAnkleDorsiflexionRight { get; set; }
     public string numROMLowerExtremityAnkleDorsiflexionLeft { get; set; }
     public string numROMLowerExtremityAnklePlantarFlexionRight { get; set; }
     public string numROMLowerExtremityAnklePlantarFlexionLeft { get; set; }

     public bool chkAllROMsNormal { get; set; }
     public bool chkCervicalROMWNL { get; set; }
     public bool chkLumbarROMWNL { get; set; }
    public bool chkShoulderROMWNL { get; set; }
    public bool chkElbowROMWNL { get; set; }
    public bool chkWristROMWNL { get; set; }
    public bool chkKneeROMWNL { get; set; }
    public bool chkHipROMWNL { get; set; }
     public bool chkAnkleROMWNL { get; set; }
     public string GrammerText { get; set; }

     public string FormType { get; set; }


     public bool chkHandROMWNL { get; set; }

     public bool HandMPFlexionNormal { get; set; }
     public bool HandMPExtensionNormal { get; set; }

     public string HandMPFlexionLeft1 { get; set; }
     public string HandMPFlexionLeft2 { get; set; }
     public string HandMPFlexionLeft3 { get; set; }
     public string HandMPFlexionLeft4 { get; set; }
     public string HandMPFlexionLeft5 { get; set; }

     public string HandMPFlexionRight1 { get; set; }
     public string HandMPFlexionRight2 { get; set; }
     public string HandMPFlexionRight3 { get; set; }
     public string HandMPFlexionRight4 { get; set; }
     public string HandMPFlexionRight5 { get; set; }

     public string HandMPExtensionLeft1 { get; set; }
     public string HandMPExtensionLeft2 { get; set; }
     public string HandMPExtensionLeft3 { get; set; }
     public string HandMPExtensionLeft4 { get; set; }
     public string HandMPExtensionLeft5 { get; set; }

     public string HandMPExtensionRight1 { get; set; }
     public string HandMPExtensionRight2 { get; set; }
     public string HandMPExtensionRight3 { get; set; }
     public string HandMPExtensionRight4 { get; set; }
     public string HandMPExtensionRight5 { get; set; }



     public bool HandPIPFlexionNormal { get; set; }
     public bool HandPIPExtensionNormal { get; set; }

     public string HandPIPFlexionLeft1 { get; set; }
     public string HandPIPFlexionLeft2 { get; set; }
     public string HandPIPFlexionLeft3 { get; set; }
     public string HandPIPFlexionLeft4 { get; set; }
     public string HandPIPFlexionLeft5 { get; set; }

     public string HandPIPFlexionRight1 { get; set; }
     public string HandPIPFlexionRight2 { get; set; }
     public string HandPIPFlexionRight3 { get; set; }
     public string HandPIPFlexionRight4 { get; set; }
     public string HandPIPFlexionRight5 { get; set; }

     public string HandPIPExtensionLeft1 { get; set; }
     public string HandPIPExtensionLeft2 { get; set; }
     public string HandPIPExtensionLeft3 { get; set; }
     public string HandPIPExtensionLeft4 { get; set; }
     public string HandPIPExtensionLeft5 { get; set; }

     public string HandPIPExtensionRight1 { get; set; }
     public string HandPIPExtensionRight2 { get; set; }
     public string HandPIPExtensionRight3 { get; set; }
     public string HandPIPExtensionRight4 { get; set; }
     public string HandPIPExtensionRight5 { get; set; }



     public bool HandDIPFlexionNormal { get; set; }
     public bool HandDIPExtensionNormal { get; set; }

     public string HandDIPFlexionLeft1 { get; set; }
     public string HandDIPFlexionLeft2 { get; set; }
     public string HandDIPFlexionLeft3 { get; set; }
     public string HandDIPFlexionLeft4 { get; set; }
     public string HandDIPFlexionLeft5 { get; set; }

     public string HandDIPFlexionRight1 { get; set; }
     public string HandDIPFlexionRight2 { get; set; }
     public string HandDIPFlexionRight3 { get; set; }
     public string HandDIPFlexionRight4 { get; set; }
     public string HandDIPFlexionRight5 { get; set; }

     public string HandDIPExtensionLeft1 { get; set; }
     public string HandDIPExtensionLeft2 { get; set; }
     public string HandDIPExtensionLeft3 { get; set; }
     public string HandDIPExtensionLeft4 { get; set; }
     public string HandDIPExtensionLeft5 { get; set; }

     public string HandDIPExtensionRight1 { get; set; }
     public string HandDIPExtensionRight2 { get; set; }
     public string HandDIPExtensionRight3 { get; set; }
     public string HandDIPExtensionRight4 { get; set; }
     public string HandDIPExtensionRight5 { get; set; }




     public bool chkMCPFlexionR1 { get; set; }
     public bool chkMCPFlexionR2 { get; set; }
     public bool chkMCPFlexionR3 { get; set; }
     public bool chkMCPFlexionR4 { get; set; }
     public bool chkMCPFlexionR5 { get; set; }


     public bool chkMCPFlexionL1 { get; set; }
     public bool chkMCPFlexionL2 { get; set; }
     public bool chkMCPFlexionL3 { get; set; }
     public bool chkMCPFlexionL4 { get; set; }
     public bool chkMCPFlexionL5 { get; set; }


     public bool chkMCPExtensionR1 { get; set; }
     public bool chkMCPExtensionR2 { get; set; }
     public bool chkMCPExtensionR3 { get; set; }
     public bool chkMCPExtensionR4 { get; set; }
     public bool chkMCPExtensionR5 { get; set; }


     public bool chkMCPExtensionL1 { get; set; }
     public bool chkMCPExtensionL2 { get; set; }
     public bool chkMCPExtensionL3 { get; set; }
     public bool chkMCPExtensionL4 { get; set; }
     public bool chkMCPExtensionL5 { get; set; }


     public bool chkPIPFlexionR1 { get; set; }
     public bool chkPIPFlexionR2 { get; set; }
     public bool chkPIPFlexionR3 { get; set; }
     public bool chkPIPFlexionR4 { get; set; }
     public bool chkPIPFlexionR5 { get; set; }


     public bool chkPIPFlexionL1 { get; set; }
     public bool chkPIPFlexionL2 { get; set; }
     public bool chkPIPFlexionL3 { get; set; }
     public bool chkPIPFlexionL4 { get; set; }
     public bool chkPIPFlexionL5 { get; set; }


     public bool chkPIPExtensionR1 { get; set; }
     public bool chkPIPExtensionR2 { get; set; }
     public bool chkPIPExtensionR3 { get; set; }
     public bool chkPIPExtensionR4 { get; set; }
     public bool chkPIPExtensionR5 { get; set; }


     public bool chkPIPExtensionL1 { get; set; }
     public bool chkPIPExtensionL2 { get; set; }
     public bool chkPIPExtensionL3 { get; set; }
     public bool chkPIPExtensionL4 { get; set; }
     public bool chkPIPExtensionL5 { get; set; }

     public bool chkDIPFlexionR1 { get; set; }
     public bool chkDIPFlexionR2 { get; set; }
     public bool chkDIPFlexionR3 { get; set; }
     public bool chkDIPFlexionR4 { get; set; }
     public bool chkDIPFlexionR5 { get; set; }


     public bool chkDIPFlexionL1 { get; set; }
     public bool chkDIPFlexionL2 { get; set; }
     public bool chkDIPFlexionL3 { get; set; }
     public bool chkDIPFlexionL4 { get; set; }
     public bool chkDIPFlexionL5 { get; set; }


     public bool chkDIPExtensionR1 { get; set; }
     public bool chkDIPExtensionR2 { get; set; }
     public bool chkDIPExtensionR3 { get; set; }
     public bool chkDIPExtensionR4 { get; set; }
     public bool chkDIPExtensionR5 { get; set; }


     public bool chkDIPExtensionL1 { get; set; }
     public bool chkDIPExtensionL2 { get; set; }
     public bool chkDIPExtensionL3 { get; set; }
     public bool chkDIPExtensionL4 { get; set; }
     public bool chkDIPExtensionL5 { get; set; }



     public string txthidden { get; set; }
     public string dteInformedConsentSigned1 { get; set; }


     public string numROMSpineCervicalRotationRight { get; set; }
     public string numROMSpineCervicalRotationLeft { get; set; }
     public string numROMSpineLumbarRotationRight { get; set; }
     public string numROMSpineLumbarRotationLeft { get; set; }
     public string UserName { get; set; }

    public bool chkSpineCervicalFlexionDefNo { get; set; }
    public bool chkSpineCervicalFlexionDefYes { get; set; }
    public string txtSpineCervicalFlexionDef { get; set; }
    public bool chkSpineLumbarForwardFlexionDefNo { get; set; }
    public bool chkSpineLumbarForwardFlexionDefYes { get; set; }
    public string txtSpineLumbarForwardFlexionDef { get; set; }
    public bool chkUEShoulderAbductionDefNo { get; set; }
    public bool chkUEShoulderAbductionDefYes { get; set; }
    public string txtUEShoulderAbductionDef { get; set; }
    public bool chkUEElbowFlexionDefNo { get; set; }
    public bool chkUEElbowFlexionDefYes { get; set; }
    public string txtUEElbowFlexionDef { get; set; }
    public bool chkUEWristDorsiflexionDefNo { get; set; }
    public bool chkUEWristDorsiflexionDefYes { get; set; }
    public string txtUEWristDorsiflexionDef { get; set; }
    public bool chkUEHandMCPFlexionR1DefNo { get; set; }
    public bool chkUEHandMCPFlexionL1DefYes { get; set; }
    public string txtUEHandMCPFlexionL1DefYes { get; set; }
    public bool chkUEHandMCPFlexionR2DefNo { get; set; }
    public bool chkUEHandMCPFlexionL2DefYes { get; set; }
    public string txtUEHandMCPFlexionL2DefYes { get; set; }
    public bool chkUEHandMCPFlexionR3DefNo { get; set; }
    public bool chkUEHandMCPFlexionL3DefYes { get; set; }
    public string txtUEHandMCPFlexionL3DefYes { get; set; }
    public bool chkUEHandMCPFlexionR4DefNo { get; set; }
    public bool chkUEHandMCPFlexionL4DefYes { get; set; }
    public string txtUEHandMCPFlexionL4DefYes { get; set; }
    public bool chkUEHandMCPFlexionR5DefNo { get; set; }
    public bool chkUEHandMCPFlexionL5DefYes { get; set; }
    public string txtUEHandMCPFlexionL5DefYes { get; set; }
    public bool chkUEHandPIPFlexionR2DefNo { get; set; }
    public bool chkUEHandPIPFlexionL2DefYes { get; set; }
    public string txtUEHandPIPFlexionL2DefYes { get; set; }
    public bool chkUEHandPIPFlexionR3DefNo { get; set; }
    public bool chkUEHandPIPFlexionL3DefYes { get; set; }
    public string txtUEHandPIPFlexionL3DefYes { get; set; }
    public bool chkUEHandPIPFlexionR4DefNo { get; set; }
    public bool chkUEHandPIPFlexionL4DefYes { get; set; }
    public string txtUEHandPIPFlexionL4DefYes { get; set; }
    public bool chkUEHandPIPFlexionR5DefNo { get; set; }
    public bool chkUEHandPIPFlexionL5DefYes { get; set; }
    public string txtUEHandPIPFlexionL5DefYes { get; set; }
    public bool chkUEHandDIPFlexionR1DefNo { get; set; }
    public bool chkUEHandDIPFlexionL1DefYes { get; set; }
    public string txtUEHandDIPFlexionL1DefYes { get; set; }
    public bool chkUEHandDIPFlexionR2DefNo { get; set; }
    public bool chkUEHandDIPFlexionL2DefYes { get; set; }
    public string txtUEHandDIPFlexionL2DefYes { get; set; }
    public bool chkUEHandDIPFlexionR3DefNo { get; set; }
    public bool chkUEHandDIPFlexionL3DefYes { get; set; }
    public string txtUEHandDIPFlexionL3DefYes { get; set; }
    public bool chkUEHandDIPFlexionR4DefNo { get; set; }
    public bool chkUEHandDIPFlexionL4DefYes { get; set; }
    public string txtUEHandDIPFlexionL4DefYes { get; set; }
    public bool chkUEHandDIPFlexionR5DefNo { get; set; }
    public bool chkUEHandDIPFlexionL5DefYes { get; set; }
    public string txtUEHandDIPFlexionL5DefYes { get; set; }
    public bool chkLEKneeFlexionDefNo { get; set; }
    public bool chkLEKneeFlexionDefYes { get; set; }
    public string txtLEKneeFlexionDef { get; set; }        
    public bool chkLEHIPAbductionDefNo { get; set; }
    public bool chkLEHIPAbductionDefYes { get; set; }
    public string txtLEHIPAbductionDef { get; set; }
    public bool chkLEAnkleDorsiflexionDefNo { get; set; }
    public bool chkLEAnkleDorsiflexionDefYes { get; set; }
    public string txtLEAnkleDorsiflexionDef { get; set; }

    public bool chkeffortPoor { get; set; }
    public bool chkeffortFair { get; set; }
    public bool chkeffortGood { get; set; }
    public bool chkeffortExcellent { get; set; }
    public string txteffortComment { get; set; }


    }
}
