using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entPEVital
    {
        public string Height { get; set; }
        public string lblBMI { get; set; }
        public string Weight { get; set; }
        public bool chkBloodPressureTakenWithRegularArmCuff { get; set; }
        public bool chkBloodPressureTakenWithRegularThighCuff { get; set; }
        public string BPDiastolic { get; set; }
        public string BPSystolic { get; set; }
        public string PulseRate { get; set; }
        public string RespiratoryRate { get; set; }
        public string PulseOx { get; set; }
        public bool chkparaplegicYes { get; set; }
public bool chkparaplegicNo { get; set; }
public string txtparaplegicComment { get; set; }

public bool chkManeuversClaimantCanWalkOnToesYes { get; set; }
public bool chkManeuversClaimantCanWalkOnToesNo { get; set; }
public string txtManeuversClaimantCanWalkOnToes { get; set; }

public bool chkManeuversClaimantCanWalkOnHeelsYes { get; set; }
public bool chkManeuversClaimantCanWalkOnHeelsNo { get; set; }
public string txtManeuversClaimantCanWalkOnHeels { get; set; }

public bool chkManeuversClaimantCanSquatYes { get; set; }
public bool chkManeuversClaimantCanSquatNo { get; set; }
public string txtManeuversClaimantCanSquat { get; set; }

public bool chkManeuversClaimantCanTandemHeelWalkYes { get; set; }
public bool chkManeuversClaimantCanTandemHeelWalkNo { get; set; }
public string txtManeuversClaimantCanTandemHeelWalk { get; set; }

public bool chkManeuversClaimantBendOverAndTouchTheirToesYes { get; set; }
public bool chkManeuversClaimantBendOverAndTouchTheirToesNo { get; set; }
public string txtManeuversClaimantBendOverAndTouchTheirToes { get; set; }

public bool ChkManueversPoor { get; set; }
public bool ChkManeuversFair { get; set; }
public bool ChkManeuversGood { get; set; }
public bool ChkManeuversExcellent { get; set; }
public string txtManeuversEffortComment { get; set; }

public string txtManeuversAdditionalComments { get; set; }
        

        public bool chkAmbulatesWithoutDifficultyAndAssistiveDevice { get; set; }
        public bool chkAmbulatesWithDifficultyWithoutAssistiveDevice { get; set; }
        public bool chkAmbulatesWithDifficultyAndUsesAssistiveDevice { get; set; }
        public bool chkAmbulatesWithDifficultyAssistiveDeviceRequired { get; set; }
        public bool chkAssistiveDeviceCane { get; set; }
        public bool chkAssistiveDeviceCrutches { get; set; }
        public bool chkAssistiveDeviceWalker { get; set; }
        public bool chkAssistiveDeviceWheelChair { get; set; }
        public bool chkAssistiveDeviceOther { get; set; }
        public string txtAssistiveDeviceOther { get; set; }
       // public bool chkClaimantUnableToAmbulateAtAll { get; set; }
        public string ddlCane { get; set; }
public string ddlCrutches { get; set; }
public string ddlWalker { get; set; }
public string ddlWheelChair { get; set; }
public string txtOther { get; set; }
        public bool chkClaimantCanGetUpAndOutOfChairWithoutDifficulty { get; set; }
        public bool chkClaimantHasDifficultyGettingUpAndOutOfChair { get; set; }
        public bool chkClaimantNotAbleToGetUpAndOutOfChair { get; set; }
        public string rtxCommentsOnAbilityToGetUpOutOfChair { get; set; }
        public bool chkClaimantAbleToGetOnAndOffExamTable { get; set; }
        public bool chkClaimantHasDifficultyGettingOnAndOffExamTable { get; set; }
        public bool chkClaimantNotAbleToGetOnAndOffExamTable { get; set; }
        public string rtxCommentsOnAbilityToOnOffExamTable { get; set; }
        public bool chkGaitNormal { get; set; }
        public bool chkGaitAbnormal { get; set; }
        public bool chkGaitChoeiform { get; set; }
        public bool chkGaitAntalgic { get; set; }
        public bool chkGaitDiplegic { get; set; }
        public bool chkGaitHemiplegic { get; set; }
        public string txtGaitChoeiform { get; set; }
        public string txtGaitAntalgic { get; set; }
        public string txtGaitDiplegic { get; set; }
        public string txtGaitHemiplegic { get; set; }
        public bool chkGaitParkinsonian { get; set; }
        public bool chkGaitAppearedNeuropathic { get; set; }
        public bool chkGaitAppearedMyopathic { get; set; }
        public bool chkGaitOther { get; set; }
        public string txtGaitParkinsonian { get; set; }
        public string txtGaitAppearedNeuropathic { get; set; }
        public string txtGaitAppearedMyopathic { get; set; }
        public string txtGaitOtherDescription { get; set; }

        public string ddlgaitChoeiSeverity { get; set; }
public string ddlgaitParkinsonSeverity { get; set; }
public string ddlgaitAntalgicSeverity { get; set; }
public string ddlgaitNeuropathicSeverity { get; set; }
public string ddlgaitDiplegicSeverity { get; set; }
public string ddlgaitMyopathicSeverity { get; set; }
public string ddlgaitHemiplegicSeverity { get; set; }
public string ddlgaitOtherSeverity { get; set; }

        public string GrammerText { get; set; }
        public string txtAmbulationVerbiage { get; set; }
        public string txtGaitVerbiage { get; set; }

        public string FormType { get; set; }
        public string UserName { get; set; }




        public bool chkRollOverYes { get; set; }
        public bool chkRollOverNo { get; set; }
        public bool chkRollOverNotApplicable { get; set; }
        public string txtRollOver { get; set; }

        public bool chkSitupYes { get; set; }
        public bool chkSitupNo { get; set; }
        public bool chkSitupNotApplicable { get; set; }
        public string txtSitup { get; set; }

        public bool chkCrawlYes { get; set; }
        public bool chkCrawlNo { get; set; }
        public bool chkCrawlNotApplicable { get; set; }
        public string txtCrawl { get; set; }

        public bool chkPullupYes { get; set; }
        public bool chkPullupNo { get; set; }
        public bool chkPullupNotApplicable { get; set; }
        public string txtPullup { get; set; }

        public bool chkStandUnassistedYes { get; set; }
        public bool chkStandUnassistedNo { get; set; }
        public bool chkStandUnassistedNotApplicable { get; set; }
        public string txtStandUnassisted { get; set; }



        public bool chkWalkYes { get; set; }
        public bool chkWalkNo { get; set; }
        public bool chkWalkNotApplicable { get; set; }
        public string txtWalk { get; set; }

        public bool chkCannotWalkYes { get; set; }
        public bool chkCannotWalkNo { get; set; }
        public bool chkCannotWalkNotApplicable { get; set; }
        public string txtCannotWalk { get; set; }

        public string rtxCommentsOnAmbulation { get; set; }


        public string txtPercentile { get; set; }
        public string txtHeadCircumference { get; set; }
        public bool chkPedsCuff { get; set; }


        public string txtHeightPercentile { get; set; }
        public string txtWeightPercentile { get; set; }
        public string txtHeadPercentile { get; set; }

        public bool chkGACleangroomed { get; set; }
        public bool chkGAOther { get; set; }
        public string txtGAOtherComments { get; set; }
        public bool chkGaitAbnormalNA { get; set; }


        public bool chkPinHoleEyeTest { get; set; }
        public string cboPinHoleEyeTestRight { get; set; }
        public string cboPinHoleEyeTestLeft { get; set; }
        public String cboSnellenChartTestRight1 { get; set; }
        public bool chkSnellenChartTestRightWithGlasses { get; set; }
        public bool chkSnellenChartTestRightWithoutGlasses { get; set; }
        public String cboSnellenChartTestLeft1 { get; set; }
        public bool chkSnellenChartTestLeftWithGlasses { get; set; }
        public bool chkSnellenChartTestLeftWithoutGlasses { get; set; }

        public bool chkeffortPoor { get; set; }
        public bool chkeffortFair { get; set; }
        public bool chkeffortGood { get; set; }
        public bool chkeffortExcellent { get; set; }
        public string txteffortComment { get; set; }
    }
}
