using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entHxOfDigestive
    {

        public bool NoHistoryOfGastrointestinalDisease { get; set; }
        public bool StomachUlcerOfPepticUlcer { get; set; }
        public bool UlcerativeColitis { get; set; } 
        public bool IBS { get; set; }
        public bool chkPMHGIBloodInStool { get; set; } 
        public String txtPMHGIBloodInStool { get; set; } 
        public bool Hemorrhoids { get; set; }
        public bool HiatalHernia { get; set; }
        public bool Hepatitis { get; set; }
        public bool chkPMHGIOtherGICondition { get; set; }
        public String txtPMHGIOtherGICondition { get; set; }
        public bool PreviousBloodTransfusion { get; set; }
        public bool chkPreviousBloodTransfusionNo { get; set; }
        public String numBloodTransfusionsAmount { get; set; }
        public String dteMostRecentBloodTransfusion { get; set; }
        public String txtMostRecentBloodTransfusionLocation { get; set; }
        public String txtMostRecentBloodTransfusionApproxDate { get; set; }
        public bool chkGainedLostMoreThan10lbsYes { get; set; }
        public bool chkGainedLostMoreThan10lbsNo { get; set; } 
        public bool ExcessiveWeightGain { get; set; }
        public bool ExcessiveWeightLoss { get; set; }
        public String numLBSGainedLost { get; set; }
        public String rtxCommentsOnHxOfDigestiveProblems { get; set; }
        public bool NoHistoryOfHeadache { get; set; } 
        public String cboHeadacheLocation { get; set; }
        public bool chkHeadacheCharacterPulsing { get; set; }
        public bool chkHeadacheCharacterThrobbing { get; set; } 
        public bool chkHeadacheCharacterStabbing { get; set; }
        public bool chkHeadacheCharacterOther { get; set; }
        public String txtHeadacheCharacterOtherDescription { get; set; }
        public String numHeadacheFrequency { get; set; }
        public String cboHeadacheFrequencyMeasurement { get; set; }
        public String numHeadacheDuration { get; set; }
        public String cboHeadacheDurationMeasurement { get; set; } 
        public bool chkPrecipitatingFactorTension { get; set; }
        public bool chkPrecipitatingFactorStress { get; set; } 
        public bool chkPrecipitatingFactorOther { get; set; } 
        public String txtPrecipitatingFactorOtherDescription { get; set; }
        public bool chkPMHHxOfHeadacheDoublevision { get; set; }
        public bool chkPMHHxOfHeadacheNausea { get; set; }
        public bool chkPMHHxOfHeadacheSeizures { get; set; }
        public bool chkPMHHxOfHeadacheOther { get; set; } 
        public String txtPMHHxOfHeadacheOtherDescription { get; set; } 
        public bool chkPMHHxOfHeadacheAnalgesicsRelievePrescription { get; set; }
        public bool chkPMHHxOfHeadacheAnalgesicsRelieveOTC { get; set; }
        public bool chkPMHHxOfHeadacheAnalgesicsRelieveOther { get; set; }
        public String txtPMHHxOfHeadacheAnalgesicsRelieveOtherDescription { get; set; }
        public bool chkPMHHxOfHeadacheSeizuresGeneralized { get; set; }
        public bool chkPMHHxOfHeadacheSeizuresPetitMal { get; set; }
        public bool chkPMHHxOfHeadacheSeizuresOther { get; set; } 
        public String txtPMHHxOfHeadacheSeizuresOtherDescription { get; set; } 
        public bool chkSeizuresInTheLast2YearsYes { get; set; }
        public bool chkSeizuresInTheLast2YearsNo { get; set; }
        public String numSeizuresInTheLast2YearsFrequency { get; set; }
        public String cboSeizuresInTheLast2YearsFrequencyMeasurement { get; set; }
        public String numSeizuresInTheLast2YearsDuration { get; set; } 
        public String cboSeizuresInTheLast2YearsDurationMeasurement { get; set; } 
        public bool chkHxOfHeadacheAssociatedWithIncontinence { get; set; }
        public bool chkSeizuresRelatedWithFecalIncontinence { get; set; }
        public bool chkSeizuresRelatedWithUrinaryIncontinence { get; set; } 
        public bool chkSeizuresRelatedWithFecalAndUrinaryIncontinence { get; set; }
        public bool chkPostictalStateYes { get; set; } 
        public bool chkPostictalStateNo { get; set; }
        public String rtxHxOfHeadacheGeneral { get; set; }
        public String GrammerText { get; set; }
        public string UserName { get; set; }
        public bool chkPMHGERD { get; set; }
        
        public string FormType { get; set; }
    }
}

