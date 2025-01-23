using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entPEHEENT
    {

            public bool chkMouthTeethGood { get; set; }
            public bool chkMouthTeethPoor { get; set; }
            public bool chkMouthTeethEdentulous { get; set; }
            public string txtMouthTeeth { get; set; }

            public bool chkNoseNormal { get; set; }
            public bool chkNoseAbnormal { get; set; }
            public string txtNose { get; set; }

            public bool chkThroatNormal { get; set; }
            public bool chkThroatAbnormal { get; set; }
            public string txtThroat { get; set; }

            public bool chkEarsNormal { get; set; }
            public bool chkEarsAbnormal { get; set; }
            public string txtEars { get; set; }



        
        public bool chkEyesPupilsAreNormal { get; set; }
        public bool chkEyesPupilsAreAbnormal { get; set; }
        public bool chkEyesPupilsAreNormalYes { get; set; }
        public string txtEyesPupilsAreAbnormalComments { get; set; }
        public string rtxCommentsOnPupils { get; set; }
        public bool chkIcterusWasNotedYes { get; set; }
        public bool chkIcterusWasNotedNo { get; set; }
        public string txtIcterusWasNoted { get; set; }
        public bool chkStrabismusWasNotedYes { get; set; }
        public bool chkStrabismusWasNotedNo { get; set; }
        public string txtStrabismusWasNoted { get; set; }
        public bool chkHorizontalNystagmusWasNotedYes { get; set; }
        public bool chkHorizontalNystagmusWasNotedNo { get; set; }
        public string txtHorizontalNystagmusWasNoted { get; set; }
        public bool chkCataractsWasNotedYes { get; set; }
        public bool chkCataractsWasNotedNo { get; set; }
        public String cboCataractsWasNotedEye { get; set; }
        public string txtCataractsWasNoted { get; set; }
        public bool chkArcusSenilisWasNotedYes { get; set; }
        public bool chkArcusSenilisWasNotedNo { get; set; }
        public string txtArcusSenilisWasNoted { get; set; }
        public bool chkUsesGlassesYes { get; set; }
        public bool chkUsesGlassesNo { get; set; }
        public string txtUsesGlassesDescription { get; set; }
        
        public String cboSnellenChartTestRight1 { get; set; }
        public bool chkSnellenChartTestRightWithGlasses { get; set; }
        public bool chkSnellenChartTestRightWithoutGlasses { get; set; }
        public string txtSnellanODComments { get; set; }
        public String cboSnellenChartTestLeft1 { get; set; }
        public bool chkSnellenChartTestLeftWithGlasses { get; set; }
        public bool chkSnellenChartTestLeftWithoutGlasses { get; set; }
        public string txtSnellanOSComments { get; set; }
        public bool chkVisualFieldsNormal { get; set; }
        public bool chkVisualFieldsAbnormal { get; set; }
        public string txtVisualFieldsDescription { get; set; }
        public bool chkVisionWasGrosslyNormal { get; set; }
        public bool chkVisionWasGrosslyAbnormal { get; set; }
        public string txtVisualFieldsDescription1 { get; set; }
        public String cboVisitSightClaimantCouldReadFingers { get; set; }
        public String cboVisitSightClaimantCouldReadFingersAtFeet { get; set; }
        public bool chkVisitSightCouldReadOD { get; set; }
        public bool chkVisitSightCouldReadOS { get; set; }
        public bool chkVisitSightCouldReadOU { get; set; }
        public String cboVisitSightClaimantCouldNotReadFingers { get; set; }
        public String cboVisitSightClaimantCouldNotReadFingersAtFeet { get; set; }
        public bool chkVisitSightCouldNotReadOD { get; set; }
        public bool chkVisitSightCouldNotReadOS { get; set; }
        public bool chkVisitSightCouldNotReadOU { get; set; }
        public bool chkClaimantHadDifficultyReadingLabels { get; set; }
        public bool chkClaimantHasDifficultyManeuveringInTheClinic { get; set; }
        public bool chkFundiscopicExamNormal { get; set; }
        public bool chkFundiscopicExamAbnormal { get; set; }
        public bool chkFundiscopicExamRevealedRetinalChanges { get; set; }
        public bool chkFundiscopicExamRevealedRetinalHemorrhages { get; set; }
        public bool chkFundiscopicExamRevealedNarrowingOfArterioles { get; set; }
        public bool chkFundiscopicExamOther { get; set; }
        public string txtFundiscopicExamOtherDescription { get; set; }
        public String cboFundusCouldNotBeVisualized { get; set; }
        public bool chkNeckWasSuppleWithoutNodesOrMassesNormal { get; set; }
        public bool chkNeckWasSuppleWithoutNodesOrMassesAbnormal { get; set; }
        public string txtNeckWasSuppleWithoutNodesOrMasses { get; set; }

        public String GrammerText { get; set; }

        public string UserName { get; set; }

        public bool chkPinHoleEyeTest { get; set; }
        public string cboPinHoleEyeTestRight { get; set; }
        public string cboPinHoleEyeTestLeft { get; set; }



        public bool chkFacialDysmorphiaYes { get; set; }
        public bool chkFacialDysmorphiaNo { get; set; }
        public string txtFacialDysmorphia { get; set; }

        public bool chkSkeletalAbnormalityYes { get; set; }
        public bool chkSkeletalAbnormalityNo { get; set; }
        public string txtSkeletalAbnormality { get; set; }

        public string FormType { get; set; }

        public bool chkSnellenchartNA { get; set; }

        public bool chkVisionSight { get; set; }

        public bool chkTrackObjectsYes { get; set; }
        public bool chkTrackObjectsNo { get; set; }
        public bool chkTrackObjectsNA { get; set; }
        public string txtTrackObjects { get; set; }
        public bool chkUsesGlassesNA { get; set; }
        
        public bool chkRedLightReflexYes { get; set; }
        public bool chkRedLightReflexYesOD { get; set; }
        public bool chkRedLightReflexYesOS { get; set; }
        public bool chkRedLightReflexYesOU { get; set; }

        public bool chkRedLightReflexNo { get; set; }
        public bool chkRedLightReflexNoOD { get; set; }
        public bool chkRedLightReflexNoOS { get; set; }
        public bool chkRedLightReflexNoOU { get; set; }
        public string rtxCommentsOnRevealedRetinalChanges { get; set; }

    }
}
