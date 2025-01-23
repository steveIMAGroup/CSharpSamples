using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entAllegationHx
    {
        public string cboFacilityState { get; set; }
        public string txtCCAllegation1 { get; set; }
        public string txtCCAllegation2 { get; set; }
        public string txtCCAllegation3 { get; set; }
        public string txtCCAllegation4 { get; set; }
        public string txtCCAllegation5 { get; set; }
        public string txtCCAllegation6 { get; set; }
        public string txtCCAllegation7 { get; set; }
        public string txtCCAllegation8 { get; set; }
        public string txtCCAllegation9 { get; set; }
        public string txtCCAllegation10 { get; set; }
        public string txtCCAllegation11  { get; set; }
        public string txtCCAllegation12 { get; set; }
        public string txtCCAllegation13 { get; set; }
        public string txtCCAllegation14 { get; set; }
        public string txtCCAllegation15 { get; set; }
        public string txtCCAllegation16 { get; set; }
        public string txtCCAllegation17 { get; set; }
        public string txtCCAllegation18 { get; set; }
        public string txtCCAllegation19 { get; set; }
        public string txtCCAllegation20 { get; set; }
        public bool chkMRReceivedYes { get; set; }
        public bool chkMRReceivedNo { get; set; }
        public bool chkMRReviewedYes { get; set; }
        public bool chkMRReviewedNo { get; set; }
        public string cboIdentificationBy { get; set; }
        public string cboArrivedVia { get; set; }
        public String ddlLanguageSpoken { get; set; }
        public bool chkSpanishInterpreterUsedYes { get; set; }
        public bool chkSpanishInterpreterUsedNo { get; set; }
        public bool chkOtherInterpreterUsedYes { get; set; }
        public bool chkOtherInterpreterUsedNo { get; set; }
        public string txtLanguageOther { get; set; }

        public string cboSmokingStatus { get; set; }
        public string ddlSmokingType { get; set; }
       
        public string numTobaccoPacksPerDay { get; set; }
        public string numTobaccoYears { get; set; }
        public string txtTobaccoQuitDate { get; set; }
        public bool chkAlcoholYes { get; set; }
        public bool chkAlcoholNo { get; set; }
        public string AlcoholUseId { get; set; }
        public string numAlcoholDrinksPerDay { get; set; }
        public bool chkAlcoholQuit { get; set; }
        public string dteAlcoholQuitDate { get; set; }
        public bool DrugUse { get; set; }
        public bool chkDrugUseNo { get; set; }
        public bool chkDrugQuit { get; set; }
        public string cboIllicitDrugUseType { get; set; }
        public string cboIllicitDrug2UseType { get; set; }
        public string cboIllicitDrug3UseType { get; set; }
        public string rtxIllicitDrugUseComments { get; set; }
        public string rtxAllegationsSocialHxComments { get; set; }
        public string GrammerText { get; set; }
        public string PersonId { get; set; }
        public string Gender { get; set; }

        public string txtReviewedExam { get; set; }

        public string formtype { get; set; }

        public string UserName { get; set; }




        public bool chkNotRelevent { get; set; }
        public bool chkRelevent { get; set; }

        public bool chkAppropriateYes { get; set; }
        public bool chkAppropriateNo { get; set; }

        public string txtFamilyHistoryContributory { get; set; }


        public string cboSourceOfHistory { get; set; }
        public string txtSourceOfHistory { get; set; }
    }
}
