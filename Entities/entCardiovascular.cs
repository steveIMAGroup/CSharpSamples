using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entCardiovascular
    {
        public bool NoHistoryOfCardiovascularDisease { get; set; }
        public bool Hypertension { get; set; }
        public bool DiabetesMellitus { get; set; }
        public bool Angioplasty { get; set; }
        public bool CoronaryArteryBypassGraft { get; set; }
        public bool chkPMHUrinaryCatheter { get; set; }
        public bool Stroke { get; set; }
        public bool KidneyFailure { get; set; }
        public bool MyocardialInfarction { get; set; }
        public bool PeripheralNeuropathy { get; set; }
        public bool chkPMHOther { get; set; }
        public string txtCommentOnSequel3 { get; set; }
        public bool chkAnyChestPainInTheLast6MonthsYes { get; set; }
        public bool chkAnyChestPainInTheLast6MonthsNo { get; set; }
        public bool chkAnyChestPainInTheLast6MonthsYesforMedplus { get; set; }
        public bool chkCausesChestPainExercise { get; set; }
        public bool chkCausesChestPainStress { get; set; }
        public bool chkCausesChestPainRest { get; set; }
        public bool chkCausesChestPainOther { get; set; }
        public string txtCausesChestPainOtherDescription {get; set;}
        public bool chkChestPainSeveritySharp { get; set; }
        public bool chkChestPainSeverityDull {get; set;}
        public bool chkChestPainSeverityAching {get; set;}
        public bool chkChestPainSeverityPinPrick {get; set;}
        public bool chkChestPainSeverityBurning {get; set;}
        public bool chkChestPainSeverityHeaviness {get; set;}
        public bool chkChestPainSeverityPressure {get; set;}
        public bool chkChestPainSeverityTightness {get; set;}
        public bool chkChestPainSeverityOther {get; set;}
        public bool chkLocationSternal {get; set;}
        public bool chkLocationLeftChest {get; set;}
        public bool chkLocationNeck {get; set;}
        public bool chkLocationAngleOfJaw { get; set; }
        public bool chkLocationLeftArm { get; set; }
        public bool chkLocationOther { get; set; }
        public string numChestPainAverageFrequencyAmount { get; set; }
        public string cboChestPainAverageFrequencyType { get; set; }
        public string txtChestPainAverageDurationAmount { get; set; }
        public string cboChestPainAverageDurationType {get; set;}
        public string cboRecentHistoryChestPainAnginaforMedplus { get; set; }
        public bool chkNitroResponseYes { get; set; }
        public bool chkNitroResponseNo { get; set; }
        public string cboWhatRelievesChestPainWorkaround {get; set;}
        public string txtNoChestPainRemarks { get; set; }
        public bool HeartMurmur { get; set; }
        public bool chkHxOfHeartMurmurNo { get; set; }
        public string txtHxOfHeartMurmurNotes {get; set;}
        public bool chkEdemaYes { get; set; }
        public bool chkEdemaNo { get; set; }
        public string txtEdemaNotes {get; set;}
        public string numSleepOnPillowsAmount {get; set;}
        public string txtHistoryOfCardiovascularRemarks { get; set; }
        public string GrammerText { get; set; }



        public bool chkHTNOnRxYes { get; set; }
        public bool chkHTNOnRxNo { get; set; }
        public bool chkHTNTakesMedicineYes { get; set; }
        public bool chkHTNTakesMedicineNo { get; set; }
        public bool chkDMOnRxYes { get; set; }
        public bool chkDMOnRxNo { get; set; }
        public bool chkDMTakesMedicineYes { get; set; }
        public bool chkDMTakesMedicineNo { get; set; }
        public bool chkEdemaFeet { get; set; }
        public bool chkEdemaAnkles { get; set; }
        public bool chkEdemaOther { get; set; }
        public string numHTNNumberOfYearsDiagnosed { get; set; }
        public string txtCommentOnSequel1 { get; set; }
        public string numDMNumberOfYearsDiagnosed { get; set; }
        public string txtCommentOnSequel2 { get; set; }

        public string txtPMHOtherDescription { get; set; }
        public string txtChestPainSeverityOther { get; set; }
        public string txtChestPainLocationOther { get; set; }
        public string txtNitroHowManyMinutes { get; set; }
        public string txtOtherRelievesChestPainDescription { get; set; }
        public string txtEdemaOther { get; set; }

        public bool chkTakesNitroYes { get; set; }
        public bool chkTakesNitroNo { get; set; }
        public string TakesNitroMinutes { get; set; }

        public string UserName { get; set; }

        public string FormType { get; set; }

        public bool chkCongenitalHeartDiseaseNo { get; set; }
        public bool chkCongenitalHeartDiseaseYes { get; set; }
        public string txtCongenitalHeartDisease { get; set; }



        public bool chkGrading1 { get; set; }
        public bool chkGrading2 { get; set; }
        public bool chkGrading3 { get; set; }
        public bool chkGrading4 { get; set; }


        public bool chkBrawny { get; set; }
        public bool chkpitting { get; set; }
        public bool chkAnyChestPainInTheLast6MonthsNA { get; set; }
        
    }
}
