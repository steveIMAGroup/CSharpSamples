using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entROS
    {
        public bool chkROSGeneralNoIssues { get; set; }
        public bool Fatigue { get; set; }
        public bool ExcessiveWeightLoss { get; set; }
        public bool Chills { get; set; }
        public bool chkROSGeneralOther { get; set; }
        public string txtROSGeneralOther { get; set; }
        public bool NoHistoryOfSkinDisease { get; set; }
        public bool Psoriasis { get; set; }
        public bool chkPMHHxOfSkinProblemsSkinCancer { get; set; }
        public bool chkHxOfSkinProblemsEczema { get; set; }
        public bool chkHxOfSkinProblemsFungal { get; set; }
        public bool chkHxOfSkinProblemsOther { get; set; }
        public string txtHxOfSkinProblemsOtherDescription { get; set; }
        public bool chkROSNoHxOfNeckThyroidProblems { get; set; }
        public bool Goiter { get; set; }
        public bool HeentOther { get; set; }
        public string txtROSNeckThyroidOther { get; set; }
        public bool NoHistoryOfPulmonaryDisease { get; set; }
        public bool Asthma { get; set; }
        public bool Pneumonia { get; set; }
        public bool ChronicObstructivePulmonaryDisease { get; set; }
        public bool Bronchitis { get; set; }
        public bool Sarcoidosis { get; set; }
        public bool Tuberculosis { get; set; }
        public bool Hemoptysis { get; set; }
        public bool chkPMHCOPDOther { get; set; }
        public string txtPMHCOPDOtherDescription { get; set; }
        public bool NoHistoryOfCardiovascularDisease { get; set; }
        public bool Hypertension { get; set; }
        public bool MyocardialInfarction { get; set; }
        public bool chkAnyChestPainInTheLast6MonthsYes { get; set; }
        public bool HeartMurmur { get; set; }
        public bool DiabetesMellitus { get; set; }
        public bool Stroke { get; set; }
        public bool chkPMHOther { get; set; }
        public string txtPMHOtherDescription { get; set; }
        public bool NoHistoryOfGastrointestinalDisease { get; set; }
        public bool StomachUlcerOfPepticUlcer { get; set; }
        public bool chkPMHGIBloodInStool { get; set; }
        public bool Hemorrhoids { get; set; }
        public bool HiatalHernia { get; set; }
        public bool IBS { get; set; }
        public bool Hepatitis { get; set; }
        public bool UlcerativeColitis { get; set; }
        public bool chkPMHGIOtherGICondition { get; set; }
        public string txtPMHGIOtherGICondition { get; set; }
        public bool chkROSNoHxOfGUProblems { get; set; }
        public bool FrequentUTI { get; set; }
        public bool Dysuria { get; set; }
        public bool Hematuria { get; set; }
        public bool Incontinence { get; set; }
        public bool GenitourinaryOther { get; set; }
        public string txtROSGenitoUrinaryOther { get; set; }
        public bool chkROSNoHxOfEndocrineProblems { get; set; }
        public bool ChronicAnemia { get; set; }
        public bool LymphNodeEnlargementOrTenderness { get; set; }
        public bool BleedingTendency { get; set; }
        public bool ImmunologicLymphaticEndocrineOther { get; set; }
        public String txtROSEndocrineOther { get; set; }
        public bool chkROSNoHxOfNeuroProblems { get; set; }
        public bool TIAs { get; set; }
        public bool MultipleSclerosis { get; set; }
        public bool Headaches { get; set; }
        public bool Seizures { get; set; }
        public bool NeurologicPsychiatricOther { get; set; }
        public string txtROSNeurologicOther { get; set; }
        public bool NoHistoryOfHeadDisease { get; set; }
        public bool Depression { get; set; }
        public bool chkPMHMentalPanicAttacks { get; set; }
        public bool Bipolar { get; set; }
        public bool Anxiety { get; set; }
        public bool chkPMHMentalOther { get; set; }
        public string txtPMHMentalOther { get; set; }
        public string txtGeneralComments { get; set; }
        public bool chkROSReviewed { get; set; }
        public string GrammerText { get; set; }
        public string FormType { get; set; }
      //  public string Gender { get; set; }
        public string UserName { get; set; }


        public bool chkBehavioralProblems { get; set; }
        public bool chkShortAttentionSpan { get; set; }





           public bool ProductiveCough  { get; set; }
           public bool chkEdemaYes  { get; set; }
           public bool chkCongenitalHeartDiseaseYes  { get; set; }
           public bool chkHeadache  { get; set; }
           public bool chkSeizures  { get; set; }


           public string cboHeadacheLocation { get; set; }
           public bool chkPMHHxOfHeadacheSeizuresGeneralized  { get; set; }
           public bool chkPMHHxOfHeadacheSeizuresPetitMal  { get; set; }
           public bool chkPMHHxOfHeadacheSeizuresOther  { get; set; }
           public bool chkPMHGERD { get; set; }       
    }
}
