using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entPENeurologicGrip
    {
       
        public bool chkMentationNormal { get; set; }
        public bool chkMentationAbnormal { get; set; }
               public string txtMentationExplanation { get; set; }


public bool chkMotorGoodForAllExtremitiesYes { get; set; }
                public bool chkMotorGoodForAllExtremitiesNo { get; set; }
               public string txtMotorGoodForAllExtremities { get; set; }


                public string cboPENeuroMotorStrength1 { get; set; }
                public string cboPENeuroMotorStrength2 { get; set; }
                public string cboPENeuroMotorStrength3 { get; set; }
                public string cboPENeuroMotorStrength4 { get; set; }


                public string txtPENeuroMotorExtremityComments1 { get; set; }
                public string txtPENeuroMotorExtremityComments2 { get; set; }
                public string txtPENeuroMotorExtremityComments3 { get; set; }
                public string txtPENeuroMotorExtremityComments4 { get; set; }


                public bool chkMuscularatrophyYes { get; set; }
                public bool chkMuscularatrophyNo { get; set; }


                public string txtPENeuroMotorSpecifyLimb { get; set; }
                public string txtCircumferentialMeasurementRight { get; set; }
                public string txtCircumferentialMeasurementLeft { get; set; }

                public bool chkSensoryWasIntactToPinAndTouchYes { get; set; }
                public bool chkSensoryWasIntactToPinAndTouchNo { get; set; }
                public string txtSensoryWasIntactToPinAndTouch { get; set; }

                public bool chkSensoryCerebellarNormalYes { get; set; }
                public bool chkSensoryCerebellarNormalNo { get; set; }


                public bool chkSensoryRhombergNormalYes { get; set; }
                public bool chkSensoryRhombergNormalNo { get; set; }
                public string txtSensoryRhombergNormal { get; set; }

                public bool chkSensoryFingerToNoseYes { get; set; }
                public bool chkSensoryFingerToNoseNo { get; set; }
                public string cboFingerToNoseSide { get; set; }
                public string txtSensoryFingerToNose { get; set; }

                public bool chkSensoryHeelToShinYes { get; set; }
                public bool chkSensoryHeelToShinNo { get; set; }
                public string cboHeelToShinSide { get; set; }
                public string txtCranialNerves { get; set; }

                public bool chkCranialNervesIIToXIIintactYes { get; set; }
                public bool chkCranialNervesIIToXIIintactNo { get; set; }

                public bool chkOpticIIYes { get; set; }
                public bool chkOculomotorIIINo { get; set; }
                public bool chkAuditoryvestibulocochlearVIIIYes { get; set; }
                public bool chkAuditoryvestibulocochlearVIIINo { get; set; }

                public bool chkOculomotorIIIYes { get; set; }
                public bool chkOpticIINo { get; set; }
                public bool chkGlossopharyngealIXYes { get; set; }
                //public bool chkAuditoryvestibulocochlearVIIINo { get; set; }

                public bool chkTrochlearIVYes { get; set; }
                public bool chkTrochlearIVNo { get; set; }
                public bool chkVagusXYes { get; set; }
                public bool chkVagusXNo { get; set; }

                public bool chkTrigeminalVYes { get; set; }
                public bool chkTrigeminalVNo { get; set; }
                public bool chkSpinalAccessoryXIYes { get; set; }
                public bool chkSpinalAccessoryXINo { get; set; }

                public bool chkAbducensVIYes { get; set; }
                public bool chkAbducensVINo { get; set; }
                public bool chkHypoglossalXIIYes { get; set; }
                public bool chkHypoglossalXIINo { get; set; }

                public bool chkFacialVIIYes { get; set; }
                public bool chkFacialVIINo { get; set; }
                public bool chkReflexesAll2Plus { get; set; }
                public bool chktemp { get; set; }
                public string cboReflexesRightBicep { get; set; }
                public string cboReflexesLeftBicep { get; set; }
                public string txtReflexesBicepComments { get; set; }

                public string cboReflexesRightTricep { get; set; }
                public string cboReflexesLeftTricep { get; set; }
                public string txtReflexesTricepComments { get; set; }

                public string cboReflexesRightAchilles { get; set; }
                public string cboReflexesLeftAchilles { get; set; }
                public string txtReflexesAchillesComments { get; set; }
                public string rtxSensoryNotes { get; set; }
                public string txtCranialNervesNotes { get; set; }
                public string txtReflexesPatellaComments { get; set; }
                public string cboReflexesLeftPatella { get; set; }
                public string cboReflexesRightPatella { get; set; }
                public string txtCerebellarNotes { get; set; }
                //public string cboReflexesRightTricep { get; set; }

                //grip form controls
                public bool chkRightNormalYes { get; set; }
                public bool chkRightNormalNo { get; set; }
                public string cboRightNormalGrade { get; set; }
                public bool chkDifficultyWithManipulativeSkillsRightYes { get; set; }
                public bool chkDifficultyWithManipulativeSkillsRightNo { get; set; }
                public string txtRightHadDifficultyWithManipulativeSkills { get; set; }
                public bool chkRightClaimantHadDifficultyButtoningYes { get; set; }
                public bool chkRightClaimantHadDifficultyButtoningNo { get; set; }
                public string numRightClaimantHadDifficultyButtoning { get; set; }
                public bool chkRightClaimantHadDifficultyZippingYes { get; set; }
                public bool chkRightClaimantHadDifficultyZippingNo { get; set; }
                public string numRightClaimantHadDifficultyZipping { get; set; }
                public bool chkRightClaimantHadDifficultyPickingUpCoinYes { get; set; }
                public bool chkRightClaimantHadDifficultyPickingUpCoinNo { get; set; }
                public string numRightClaimantHadDifficultyPickingUpCoin { get; set; }
                public bool chkRightClaimantHadDifficultyTyingShoeLacsYes { get; set; }
                public bool chkRightClaimantHadDifficultyTyingShoeLacsNo { get; set; }
                public string numRightClaimantHadDifficultyTyingShoeLacs { get; set; }
                public bool chkLeftNormalYes { get; set; }
                public bool chkLeftNormalNo { get; set; }
                public string cboLeftNormalGrade { get; set; }
                public bool chkDifficultyWithManipulativeSkillsLeftYes { get; set; }
                public bool chkDifficultyWithManipulativeSkillsLeftNo { get; set; }
                public string txtLeftHadDifficultyWithManipulativeSkills { get; set; }
                public bool chkLeftClaimantHadDifficultyButtoningYes { get; set; }
                public bool chkLeftClaimantHadDifficultyButtoningNo { get; set; }
                public string numLeftClaimantHadDifficultyButtoning { get; set; }
                public bool chkLeftClaimantHadDifficultyZippingYes { get; set; }
                public bool chkLeftClaimantHadDifficultyZippingNo { get; set; }
                public string numLeftClaimantHadDifficultyZipping { get; set; }
                public bool chkLeftClaimantHadDifficultyPickingUpCoinYes { get; set; }
                public bool chkLeftClaimantHadDifficultyPickingUpCoinNo { get; set; }
                public string numLeftClaimantHadDifficultyPickingUpCoin { get; set; }
                public bool chkLeftClaimantHadDifficultyTyingShoeLacsYes { get; set; }
                public bool chkLeftClaimantHadDifficultyTyingShoeLacsNo { get; set; }
                public string numLeftClaimantHadDifficultyTyingShoeLacsNo { get; set; }
                public bool chkRightNormalNA { get; set; }
                public bool chkRightClaimantHadDifficultyButtoningNA { get; set; }
                public bool chkRightClaimantHadDifficultyZippingNA { get; set; }
                public bool chkRightClaimantHadDifficultyPickingUpCoinNA { get; set; }
                public bool chkRightClaimantHadDifficultyTyingShoeLacsNA { get; set; }
                public bool chkLeftNormalNA { get; set; }
                public bool chkLeftClaimantHadDifficultyButtoningNA { get; set; }
                public bool chkLeftClaimantHadDifficultyZippingNA { get; set; }
                public bool chkLeftClaimantHadDifficultyPickingUpCoinNA { get; set; }
                public bool chkLeftClaimantHadDifficultyTyingShoeLacsNA { get; set; }
                public string rtxGripNotes { get; set; }

               
                public String GrammerText { get; set; }

                public string PersonId { get; set; }
                public string Gender { get; set; }
                public string FormType { get; set; }
                public string UserName { get; set; }
                public bool chkRightPinchYes { get; set; }
                public bool chkRightPinchNo { get; set; }
                public String txtRightHandPinch { get; set; }
                public bool chkLeftPinchYes { get; set; }
                public bool chkLeftPinchNo { get; set; }
                public String txtLeftHandPinch { get; set; }
    }
}
