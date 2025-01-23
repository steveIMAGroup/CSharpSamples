using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entNeurologic
    {

        public bool chkMentationNormal { get; set; }
        public bool chkMentationAbnormal { get; set; }
        public String txtMentationExplanation { get; set; }
  
        public bool chkMotorGoodForAllExtremitiesYes { get; set; }
        public bool chkMotorGoodForAllExtremitiesNo { get; set; }
        public String txtMotorGoodForAllExtremities { get; set; }

        public String cboPENeuroMotorExtremity1 { get; set; }
        public String cboPENeuroMotorExtremity2 { get; set; }
        public String cboPENeuroMotorExtremity3 { get; set; }
        public String cboPENeuroMotorExtremity4 { get; set; }
        public String cboPENeuroMotorExtremity5 { get; set; }
        public String cboPENeuroMotorExtremity6 { get; set; }
        public String cboPENeuroMotorExtremity7 { get; set; }
        public String cboPENeuroMotorExtremity8 { get; set; }

        public String cboPENeuroMotorStrength1 { get; set; }
        public String cboPENeuroMotorStrength2 { get; set; }
        public String cboPENeuroMotorStrength3 { get; set; }
        public String cboPENeuroMotorStrength4 { get; set; }
        public String cboPENeuroMotorStrength5 { get; set; }
        public String cboPENeuroMotorStrength6 { get; set; }
        public String cboPENeuroMotorStrength7 { get; set; }
        public String cboPENeuroMotorStrength8 { get; set; }

        public String cboPENeuroMotorProximalDistal1 { get; set; }
        public String cboPENeuroMotorProximalDistal2 { get; set; }
        public String cboPENeuroMotorProximalDistal3 { get; set; }
        public String cboPENeuroMotorProximalDistal4 { get; set; }
        public String cboPENeuroMotorProximalDistal5 { get; set; }
        public String cboPENeuroMotorProximalDistal6 { get; set; }
        public String cboPENeuroMotorProximalDistal7 { get; set; }
        public String cboPENeuroMotorProximalDistal8 { get; set; }

        public String txtPENeuroMotorExtremityComments1 { get; set; }
        public String txtPENeuroMotorExtremityComments2 { get; set; }
        public String txtPENeuroMotorExtremityComments3 { get; set; }
        public String txtPENeuroMotorExtremityComments4 { get; set; }
        public String txtPENeuroMotorExtremityComments5 { get; set; }
        public String txtPENeuroMotorExtremityComments6 { get; set; }
        public String txtPENeuroMotorExtremityComments7 { get; set; }
        public String txtPENeuroMotorExtremityComments8 { get; set; }

        public String txtPENeuroMotorSpecifyLimb { get; set; }
        public String txtCircumferentialMeasurementRight { get; set; }
        public String txtCircumferentialMeasurementLeft { get; set; }

        public bool chkSensoryWasIntactToPinAndTouchYes { get; set; }
        public bool chkSensoryWasIntactToPinAndTouchNo { get; set; }
        public String txtSensoryWasIntactToPinAndTouch { get; set; }

        public bool chkSensoryCerebellarNormalYes { get; set; }
        public bool chkSensoryCerebellarNormalNo { get; set; }
        public String txtCerebellarNotes { get; set; }

        public bool chkSensoryRhombergNormalYes { get; set; }
        public bool chkSensoryRhombergNormalNo { get; set; }
        public String txtSensoryRhombergNormal { get; set; }


        public bool chkSensoryFingerToNoseYes { get; set; }
        public bool chkSensoryFingerToNoseNo { get; set; }
        public String cboFingerToNoseSide { get; set; }
        public String txtSensoryFingerToNose { get; set; }

        public bool chkSensoryHeelToShinYes { get; set; }
        public bool chkSensoryHeelToShinNo { get; set; }
        public String cboHeelToShinSide { get; set; }
        public String txtCranialNerves { get; set; }

        public bool chkCranialNervesIIToXIIintactYes { get; set; }
        public bool chkCranialNervesIIToXIIintactNo { get; set; }

        public bool chkOpticIIYes { get; set; }
        public bool chkOculomotorIIINo { get; set; }
        public bool chkAuditoryvestibulocochlearVIIIYes { get; set; }
        public bool chkAuditoryvestibulocochlearVIIINo { get; set; }

        public bool chkOculomotorIIIYes { get; set; }
        public bool chkOpticIINo { get; set; }
        public bool chkGlossopharyngealIXYes { get; set; }
        public bool chkGlossopharyngealIXNo { get; set; }

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

        public String cboReflexesRightBicep { get; set; }
        public String cboReflexesLeftBicep { get; set; }
        public String txtReflexesBicepComments { get; set; }
        public String cboReflexesRightTricep { get; set; }
        public String cboReflexesLeftTricep { get; set; }
        public String txtReflexesTricepComments { get; set; }
        public String cboReflexesRightAchilles { get; set; }


        public String cboReflexesLeftAchilles { get; set; }

        public String txtReflexesAchillesComments { get; set; }
        public String rtxSensoryNotes { get; set; }
        public String GrammerText { get; set; }
        public String txtCranialNervesNotes { get; set; }
        public String txtReflexesPatellaComments { get; set; }
        public String cboReflexesLeftPatella { get; set; }
        public String cboReflexesRightPatella { get; set; }


        public string formtype { get; set; }
        public bool chktemp { get; set; }

        public string UserName { get; set; }


        public bool chkMuscularatrophyYes { get; set; }
        public bool chkMuscularatrophyNo { get; set; }
    }
        
       
    }

