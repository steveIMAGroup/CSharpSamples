using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
   public class entImpressionHx
    {
       public string lblHeSheLowerCase { get; set; }
       public String txtCCAllegation1 { get; set; }
       public String txtCCAllegation2 { get; set; }
       public String txtCCAllegation3 { get; set; }
       public String txtCCAllegation4 { get; set; }
       public String txtCCAllegation5 { get; set; }
       public String txtCCAllegation6 { get; set; }
       public String txtCCAllegation7 { get; set; }
       public String txtCCAllegation8 { get; set; }
       public String txtCCAllegation9 { get; set; }
       public String txtCCAllegation10 { get; set; }
       public String txtCCAllegation11 { get; set; }
       public String txtCCAllegation12 { get; set; }
       public String txtCCAllegation13 { get; set; }
       public String txtCCAllegation14 { get; set; }
       public String txtCCAllegation15 { get; set; }
       public String txtCCAllegation16 { get; set; }
       public String txtCCAllegation17 { get; set; }
       public String txtCCAllegation18 { get; set; }
       public String txtCCAllegation19 { get; set; }
       public String txtCCAllegation20 { get; set; }
       public String txtImpression1 { get; set; }
       public String txtImpression2 { get; set; }
       public String txtImpression3 { get; set; }
       public String txtImpression4 { get; set; }
       public String txtImpression5 { get; set; }
       public String txtImpression6 { get; set; }
       public String txtImpression7 { get; set; }
       public String txtImpression8 { get; set; }
       public String txtImpression9 { get; set; }
       public String txtImpression10 { get; set; }
       public String txtImpression11 { get; set; }
       public String txtImpression12 { get; set; }
       public String txtImpression13 { get; set; }
       public String txtImpression14 { get; set; }
       public String txtImpression15 { get; set; }
       public String txtImpression16 { get; set; }
       public String txtImpression17 { get; set; }
       public String txtImpression18 { get; set; }
       public String txtImpression19 { get; set; }
       public String txtImpression20 { get; set; }
       public bool chkClaimantCooperatedYes { get; set; }
       public bool chkClaimantCooperatedNo { get; set; }
       public string txtReachingHandlingGraspingVerbiageLimitationsVerbiage { get; set; }
       
       public bool chkClaimantHasNoLimitations { get; set; }
       public bool chkClaimantHasLimitations { get; set; }
       public bool chkLimitationsStanding { get; set; }
       public String cboLimitationsStandingFrequency { get; set; }
       public bool chkLimitationsSitting { get; set; }
       public String cboLimitationsSittingFrequency { get; set; }
       public bool chkLimitationsWalking { get; set; }
       public String cboLimitationsWalkingFrequency { get; set; }
       public bool chkLimitationsBending { get; set; }
       public String txtLimitationsBendingNotes {get; set; }
       public bool chkLimitationsReaching { get; set; }
       public String txtLimitationsReachingNotes { get; set; }
       public bool chkLimitationsLifting { get; set; }
       public bool chkLimitationsLiftingLeft { get; set; }
       public String cboLimitationsLiftingAmount { get; set; }
       public String cboLimitationsLiftingFrequency { get; set; }
       public bool chkLimitationsLiftingRight { get; set; }
       public String cboLimitationsLiftingAmount2 { get; set; }
       public String cboLimitationsLiftingFrequency2 { get; set; }
       public String txtLimitationsLiftingAndCarryingNotes { get; set; }
       public bool chkLimitationsSeeing { get; set; }
       public String txtLimitationsSeeingNotes { get; set; }
       public bool chkLimitationsHearing { get; set; }
       public String txtLimitationsHearingNotes { get; set; }
       public bool chkSpeech { get; set; }
       public String txtLimitationsSpeechNotes { get; set; }
       public bool chkDriving { get; set; }
       public String txtLimitationsDrivingNotes { get; set; }
       public String cboPercentageofUnderstandableSpeech { get; set; }
       public String cboDrivingDuration { get; set; }
       public bool chkLimitationsExposureDust { get; set; }
       public String txtLimitationsExposureDustNotes {get; set;}
       public bool chkLimitationsUnderstanding { get; set; }
       public String txtLimitationsUnderstandingNotes {get; set;}
       public String txtSignificantLimitationsExplanation  { get; set; }
       public bool chkAmbulatesWithoutDifficultyAndAssistiveDevice { get; set; }
       public bool chkAmbulatesWithDifficultyWithoutAssistiveDevice { get; set; }
       public bool chkAmbulatesWithDifficultyAndUsesAssistiveDevice { get; set; }
       public bool chkAmbulatesWithDifficultyAssistiveDeviceRequired { get; set; }
       public bool chkClaimantUnableToAmbulateAtAll { get; set; }
       public bool chkAnyChestPainInTheLast6MonthsYes { get; set; }      
       public String cboRecentHistoryChestPainAngina { get; set; }

       public bool chkAnyChestPainInTheLast6MonthsYesforMedplus { get; set; }
       public String cboRecentHistoryChestPainAnginaforMedplus { get; set; }

       public String GrammerText { get; set; }

       public String txtLimitationsVerbiage { get; set; }
       public string FormType { get; set; }

       public string rtxAdditionalImpressions { get; set; }

       public string UserName { get; set; }



      public bool chkFunctionComparisonYes { get; set; }
      public bool chkFunctionComparisonNo { get; set; }
      public string txtFunctionComparison { get; set; }

      public bool chkBehavioralProblems { get; set; }
public bool chkBehavorialProblemsOnTreatment { get; set; }
public bool chkBehavorialProblemsNoOnTreatment { get; set; }
public string txtBehavorialProblems { get; set; }

public bool chkShortAttentionSpan { get; set; }
public bool chkAttentionSpanOnTreatment { get; set; }
public bool chkAttentionSpanNoOnTreatment { get; set; }
public string txtAttentionSpan { get; set; }




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


       public bool chkPhysicalLimitationsYes { get; set; }
           public bool chkPhysicalLimitationsNo { get; set; }
           public string txtPhysicalLimitations { get; set; }

           public bool chkBehavioralDevelopmentalLimitationsYes { get; set; }
           public bool chkBehavioralDevelopmentalLimitationsNo { get; set; }
           public string txtBehavioralDevelopmentalLimitations { get; set; }

           public bool chkTheraphyTreatmentYes { get; set; }
           public bool chkTheraphyTreatmentNo { get; set; }
           public string txtTheraphyTreatment { get; set; }


           public string txtclaimantnotcooperated { get; set; }
           public bool chkeffortPoor { get; set; }
           public bool chkeffortFair { get; set; }
           public bool chkeffortGood { get; set; }
           public bool chkeffortExcellent { get; set; }
           public string txteffortComment { get; set; }

           public string txtLimitationsStandingFrequency { get; set; }
           public string txtLimitationsSittingFrequency { get; set; }
           public string txtLimitationsWalkingFrequency { get; set; }
           public string cboLimitationsBending { get; set; }
           public string cboLimitationsReaching { get; set; }
    }
}
