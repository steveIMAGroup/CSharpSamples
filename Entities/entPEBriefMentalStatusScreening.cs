using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
   public class entPEBriefMentalStatusScreening
    {
       
       public bool chkAdequateGrooming  { get; set; }
       public bool chkDisheveled  { get; set; }
       public bool chkAbnormalPosture { get; set; } 
       public bool chkAppearanceOther  { get; set; }
       public string txtAppearanceOther { get; set; }

       public bool chkOriented { get; set; }
       public bool chkDisoriented { get; set; } 
       public bool chkOrientationOther { get; set; } 
       public string txtOrientationOther { get; set; } 

       public bool chkAppropriateBehavior { get; set; }
       public bool chkPsychomotorAgitation { get; set; }
       public bool chkPsychomotorSlowing { get; set; }
       public bool chkTics { get; set; } 
       public bool chkBehaviorOther { get; set; } 
       public string txtBehaviorOther { get; set; } 

       public bool chkEuthymic { get; set; } 
       public bool chkEuphoric { get; set; } 
       public bool chkDysthymic { get; set; } 
       public bool chkDepressed { get; set; } 
       public bool chkManic { get; set; } 
       public bool chkIrritable { get; set; } 
       public bool chkAnxious { get; set; }
       public bool chkAngry { get; set; }
       public bool chkMoodOther { get; set; } 
       public string txtMoodOther { get; set; } 

       public bool chkEyeContactGood { get; set; } 
       public bool chkEyeContactIntermittent { get; set; } 
       public bool chkEyeContactPoor { get; set; } 
       public bool chkEyeContactOther { get; set; } 
       public string txtEyeContactOther { get; set; } 

       public bool chkCalmandCooperative { get; set; } 
       public bool chkHostile { get; set; } 
       public bool chkDefensive { get; set; } 
       public bool chkDemanding { get; set; } 
       public bool chkGuarded { get; set; } 
       public bool chkSuspicious { get; set; } 
       public bool chkSeductive { get; set; } 
       public bool chkAttitudeOther { get; set; } 
       public string txtAttitudeOther { get; set; } 

        public bool chkAffectWide { get; set; } 
        public bool chAffectRestricted { get; set; }
        public bool chkAffectBlunted { get; set; } 
        public bool chkAffectFlat { get; set; } 
        public bool chkLabile { get; set; } 
        public bool chkAffectInappropriate { get; set; } 
        public bool chkAffectOther { get; set; } 
        public string txtAffectOther { get; set; } 

        public bool chkAttentionAdequate { get; set; } 
        public bool chkAttentionDistracted { get; set; } 
        public bool chkAttentionImpaired { get; set; } 
        public string txtAttentionImpaired { get; set; } 

        public bool chkConcentrationGood { get; set; }
        public bool chkConcentrationDifficult { get; set; } 
        public bool chkConcentrationModerate { get; set; } 
        public bool chkConcentrationOther { get; set; } 
        public string txtConcentrationOther { get; set; } 

        public bool chkMemoryRecent { get; set; } 
        public bool chkMemoryImpairment { get; set; }
        public string txtMemoryImpairment { get; set; }

        public string FormType { get; set; }

        public string UserName { get; set; }
        public string GrammerText { get; set; }
        public string PersonId { get; set; }
        public string Gender { get; set; }

    }
}
