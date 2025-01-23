using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entFunction
    {
 public string cboHxOfFunctionalStatusHowFarInSchool {get; set;}
public string cboHxOfFunctionalStatusLastJob {get; set;}
public string Occupation {get; set;}
public bool chkUseAmbulatoryDeviceToGetAroundYes {get; set;}
public bool chkUseAmbulatoryDeviceToGetAroundNo { get; set; }
public string cboUseAmbulatoryDeviceToGetAroundType {get; set;}
public string cboHxOfFunctionalStatusHowFarCanWalkOnLevelGround {get; set;}
public bool chkHxOfFunctionalStatusCanFeedSelf { get; set; }
public bool chkHxOfFunctionalStatusCanFeedSelfNo { get; set; }
public bool chkHxOfFunctionalStatusCanDressSelf { get; set; }
public bool chkHxOfFunctionalStatusCanDressSelfNo { get; set; }
public bool chkHxOfFunctionalStatusTroubleStanding { get; set; }
public bool chkHxOfFunctionalStatusTroubleStandingNo { get; set; }
public bool chkHxOfFunctionalStatusHasDifficultyLifting { get; set; }
public bool chkHxOfFunctionalStatusHasDifficultyLiftingNo { get; set; }
public bool chkHxOfFunctionalStatusCanDriveCar { get; set; }
public bool chkHxOfFunctionalStatusCanDriveCarNo { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToSweep { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToSweepNo { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToMop { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToMopNo { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToVacuum { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToVacuumNo { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToCook { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToCookNo { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToDoDishes { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToDoDishesNo { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToShopGroceries { get; set; }
public bool chkHxOfFunctionalStatusIsAbleToShopGroceriesNo {get; set;}
public bool chkHxOfFunctionalStatusIsAbleToClimbStairs {get; set;}
public bool chkHxOfFunctionalStatusIsAbleToClimbStairsNo {get; set;}
public bool chkHxOfFunctionalStatusIsAbleToCareYard {get; set;}
public bool chkHxOfFunctionalStatusIsAbleToCareyardNo {get; set;}
public bool chkHxOfFunctionalStatusIsAbleToMowGrass {get; set;}
public bool chkHxOfFunctionalStatusIsAbleToMowGrassNo {get; set;}
public bool chkHxOfFunctionalStatusIsAbleToTurnDoorknob {get; set;}
public bool chkHxOfFunctionalStatusIsAbleToTurnDoorknobNo {get; set;}
public bool chkHxOfFunctionalStatusIsAbleToBalanceCheckBook {get; set;}
public bool HxOfFunctionalStatusIsAbleToBalanceCheckBookNo {get; set;}
            
public bool chkHxOfFunctionalStatusIsAbleToWriteOwnName {get; set;}
public bool chkHxOfFunctionalStatusIsAbleToWriteOwnNameNo {get; set;}
public string txtHxOfFunctionalStatusCanFeedSelfNotes {get; set;}
public string txtHxOfFunctionalStatusCanDressSelfNotes {get; set;}
public string cboHxOfFunctionalStatusCanStandFor {get; set;}
public string cboHxOfFunctionalStatusHasDifficultyLiftingWithRight {get; set;}
public string cboHxOfFunctionalStatusHasDifficultyLiftingWithLeft {get; set;}
public string cboHowLongCanDriveCar {get; set;}
public string cboHxOfFunctionalStatusHowLongIsAbleToSweep {get; set;}
public string cboHxOfFunctionalStatusHowLongIsAbleToMop {get; set;}
public string cboHxOfFunctionalStatusHowLongIsAbleToVacuum {get; set;}
public string cboHxOfFunctionalStatusHowLongIsAbleToCook {get; set;}
public string cboHxOfFunctionalStatusHowLongIsAbleToDoDishes {get; set;}
public string cboHxOfFunctionalStatusHowLongIsAbleToShopGroceries {get; set;}
public string cboHxOfFunctionalStatusHowLongIsAbleToClimbStairs {get; set;}
public string cboHxOfFunctionalStatusHowLongIsAbleToCareYard {get; set;}
public string cboHxOfFunctionalStatusHowLongIsAbleToMowGrass {get; set;}
public string cboHxOfFunctionalStatusIsAbleToTurnDoorKnobWIth {get; set;}
public string txtHxOfFunctionalStatusIsAbleToBalanceCheckBookNotes {get; set;}
public string txtHxOfFunctionalStatusIsAbleToWriteOwnNameNotes {get; set;}
public string rtxHxOfFunctionalStatusComments { get; set; }
public string GrammerText { get; set; }

                     
       public string txtUseAmbulatoryDeviceToGetAroundOtherDescription {get; set;}
       public string txtHxOfFunctionalStatusHowFarCanWalkOnLevelGround {get; set;}
       public string txtHxOfFunctionalStatusCanStandFor {get; set;}

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

       public bool chkUseAmbulatoryDeviceToGetAroundNA { get; set; }
       public bool chkHxOfFunctionalStatusCanFeedSelfNA { get; set; }
       public bool chkHxOfFunctionalStatusCanDressSelfNA { get; set; }
       public bool chkHxOfFunctionalStatusTroubleStandingNA { get; set; }
       public bool chkHxOfFunctionalStatusHasDifficultyLiftingNA { get; set; }

    }
}

