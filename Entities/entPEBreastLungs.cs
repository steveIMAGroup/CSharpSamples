using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entPEBreastLungs
    {
           public bool chkBreastDeferred { get; set; } 
           public bool chkBreastExaminedYes { get; set; } 
           public bool chkBreastExaminedNo { get; set; } 
           public string rtxBreastFindings { get; set; } 
           public bool chkLungsWereClearYes { get; set; } 
           public bool chkLungsWereClearNo { get; set; }
           public string txtLungsDescription { get; set; }
           public bool chkNoShortnessOfBreathAtRest { get; set; } 
           public bool chkClaimantWasVisibilityShortOfBreathAtRest { get; set; } 
           public bool chkClaimantWasShortOfBreathWithExertionInExamRoom { get; set; }
           public bool  chkChestCageAppearedNormal {get; set; } 
           public bool chkChestCageRevealedAnIncreasedAPDiameter { get; set; }
           public string txtChestCageRevealedAnIncreasedAPDiameter { get; set; } 


           public bool chkUsingAccessoryMusclesOfRespirationNo {get; set;}
           public bool chkUsingAccessoryMusclesOfRespirationYes {get; set;}
           public string txtUsingAccessoryMusclesOfRespiration {get; set; } 
           public bool chkClubbingNo {get; set;}
           public bool chkClubbingYes {get; set;}
           public string cboClubbingRating {get; set; } 
           public bool chkHeartThereWasRegularRhythmWithoutMurmurYes {get; set;}
           public bool chkHeartThereWasRegularRhythmWithoutMurmurNo {get; set;}
           public bool chkCardiacRhythmWasIrregular { get; set; }
           public string txtCardiacRhythmWasIrregular { get; set; } 
           public bool chkSystolicMurmurWasNoted {get; set;}
           public string txtSystolicMurmurWasNoted { get; set; } 
           public bool chkDiastolicMurmurWasNoted {get; set; }
           public string txtDiastolicMurmurWasNoted { get; set; } 
           public bool chkOtherAbnormality {get; set;}
           public string txtOtherAbnormality { get; set; } 
           public bool chkAbodomenWasSoftWithNoMassesOrOrganomegalyYes { get; set; } 
           public bool chkAbodomenWasSoftWithNoMassesOrOrganomegalyNo { get; set; }
 

           public string txtAbodomenWasSoftWithNoMassesOrOrganomegaly { get; set; }
           public bool chkAbodomenThereWasTendernessToPalpationyes { get; set; }
           public bool chkAbodomenThereWasTendernessToPalpationNo { get; set; } 
           public string txtAbodomenThereWasTendernessToPalpation { get; set; } 
           public bool chkAbodomenSpleenWasFeltYes { get; set; }
           public bool chkAbodomenSpleenWasFeltNo { get; set; }
           public string txtAbodomenSpleenWasFelt { get; set; } 
           public bool chkAbodomenLiverWasFeltBelowTheRightCostalMarginYes { get; set; } 
           public bool chkAbodomenLiverWasFeltBelowTheRightCostalMarginNo { get; set; }
           public bool chkUlcerationsNA { get; set; }
           public bool chkVaricositiesNA { get; set; }
        




           public string txtAbodomenLiverWasFeltBelowTheRightCostalMargin { get; set; }
           public bool chkAbodomenThereWasAscitesNotedYes { get; set; } 
           public bool chkAbodomenThereWasAscitesNotedNo { get; set; }
           public string txtAbodomenThereWasAscitesNoted { get; set; } 
           public bool chkAbodomenThereWasAnAbdominalHerniaNotedYes { get; set; } 
           public bool chkAbodomenThereWasAnAbdominalHerniaNotedNo { get; set; } 
           public string txtAbodomenThereWasAnAbdominalHerniaNoted { get; set; } 
           public bool chkBowelSoundsAppearNormal { get; set; } 
           public bool chkBowelSoundsDoNotAppearNormal { get; set; } 
           public string txtBowelSoundsComments { get; set; } 
           public string rtxAbdomenComments { get; set; }
           public string GrammerText { get; set; }
           public string UserName { get; set; }

           public string FormType { get; set; }

           public bool chkPulsesNormal { get; set; }
           public bool chkPulsesAbnormal { get; set; }
           public string txtPulses { get; set; }


           
        public bool chkEdemaYes { get; set; }
            public bool chkEdemaNo { get; set; }
            public string txtEdemaNotes { get; set; }

            public bool chkBrawny { get; set; }
            public bool chkpitting { get; set; }
            public bool chkGrading1 { get; set; }
            public bool chkGrading2 { get; set; }
            public bool chkGrading3 { get; set; }
            public bool chkGrading4 { get; set; }

            public bool chkEdemaFeet { get; set; }
            public bool chkEdemaAnkles { get; set; }
            public bool chkEdemaOther { get; set; }
            public string txtEdemaOther { get; set; }

            public bool chkUlcerationsNo { get; set; }
            public bool chkUlcerationsYes { get; set; }
            public string txtUlcerations { get; set; }

            public bool chkVaricositiesNo { get; set; }
            public bool chkVaricositiesYes { get; set; }
            public string txtVaricosities { get; set; }

            public bool chkGallopMurmurWasNoted { get; set; }
            public string txtGallopMurmurWasNoted { get; set; }
            public bool chkRubMurmurWasNoted { get; set; }
            public string txtRubMurmurWasNoted { get; set; }
            public bool chkJVDMurmurWasNoted { get; set; }
            public string txtJVDMurmurWasNoted { get; set; }

            public bool chkAbodomenThereWasAscitesNotedNA { get; set; }

            public bool chkPEEdemaYes { get; set; }
}
}
