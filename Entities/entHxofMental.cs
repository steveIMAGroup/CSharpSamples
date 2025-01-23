using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
   public class entHxofMental
    {

       public bool NoHistoryOfHeadDisease { get; set; }
        public bool Depression { get; set; }
        public bool Anxiety { get; set; }
        public bool chkPMHMentalPanicAttacks { get; set; }
        public bool Bipolar { get; set; }
        public bool chkPMHMentalOther { get; set; }
        public string txtPMHMentalOther { get; set; }
        public bool chkPMHMentalHospitalizationsYes { get; set; }
        public bool chkPMHMentalHospitalizationsNo { get; set; }
        public string txtPMHMentalHospitalizationsNotes { get; set; }
        public bool chkSuicideAttemptYes { get; set; }
        public bool chkSuicideAttemptNo { get; set; }
        public string numSuicideAttemptAmount { get; set; }
        public string txtSuicideAttemptLastAttempt { get; set; }
        public bool chkTakesMedsForConditionYes { get; set; }
        public bool chkTakesMedsForConditionNo { get; set; }
        public string numTakesMedsForConditionSince { get; set; }
        public string cboTakesMedsForConditionSince { get; set; }
        public string rtxMedicationComment { get; set; }
        public bool chkCanHandleOwnFinancesYes { get; set; }
        public bool chkCanHandleOwnFinancesNo { get; set; }
        public string txtCanHandleOwnFinancesWhyNot { get; set; }
        public bool chkPMHMentalConditionAffectAbilityToWorkYes { get; set; }
        public bool chkPMHMentalConditionAffectAbilityToWorkNo { get; set; }
        public string rtxPMHMentalConditionAffectAbilityToWorkHow { get; set; }
        public bool NoHistoryOfSkinDisease { get; set; }
        public bool Psoriasis { get; set; }
        public bool chkHxOfSkinProblemsEczema { get; set; }
        public bool chkHxOfSkinProblemsFungal { get; set; }
        public bool chkPMHHxOfSkinProblemsSkinCancer { get; set; }
        public bool chkHxOfSkinProblemsOther { get; set; }
        public string txtHxOfSkinProblemsOtherDescription { get; set; }
        public bool chkHxOfSkinProblemsSkinConditionAffectWorkYes { get; set; }
        public bool chkHxOfSkinProblemsSkinConditionAffectWorkNo { get; set; }
        public string rtxHxOfSkinProblemsAffectedNotes { get; set; }
        public String GrammerText { get; set; }
        public string UserName { get; set; }




            public bool chkPreschoolPerformanceYes { get; set; }
           public bool chkPreschoolPerformanceNo { get; set; }
           public string txtPreschoolPerformance { get; set; }

           public bool chkDaycarePerformanceYes { get; set; }
           public bool chkDaycarePerformanceNo { get; set; }
           public string txtDaycarePerformance { get; set; }

           public bool chkSchoolPerformanceYes { get; set; }
           public bool chkSchoolPerformanceNo { get; set; }
           public string txtSchoolPerformance { get; set; }

           public bool chkBehaviorProblemNo { get; set; }
           public bool chkBehaviorProblemYes { get; set; }
           public string txtBehaviorProblem { get; set; }

           public bool chkAttentionSpanNormal { get; set; }
           public bool chkAttentionSpanAbnormal { get; set; }
           public string txtAttentionSpan { get; set; }
            
       public bool chkPreschoolPerformanceNA{get;set;}
       public bool chkDaycarePerformanceNA{get;set;}
       public bool chkSchoolPerformanceNA{get;set;}

           public string FormType { get; set; }
           public bool chkBehaviorProblemNA { get; set; }
           public bool chkAttentionSpanNA { get; set; }

    }
}
