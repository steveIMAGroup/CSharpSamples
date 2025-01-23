using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
   public class entHxOfPulmonary
    {
           public bool NoHistoryOfPulmonaryDisease { get; set; }
           public bool ChronicObstructivePulmonaryDisease { get; set; }
           public bool Asthma { get; set; }
           public bool Bronchitis { get; set; }
           public bool Sarcoidosis { get; set; }
           public bool Tuberculosis { get; set; }
           public bool Pneumonia { get; set; }
           public bool Hemoptysis { get; set; }
           public bool ProductiveCough { get; set; }
           public bool chkPMHCOPDOther { get; set; }
           public String txtPMHPulmonaryHxNotes { get; set; }
           public String rtxCommentsOnHxOfPulmonaryDisease { get; set; }

           public bool NoHistoryOfMusculoskeletalDisease { get; set; }


           public bool chkPMHMusculoskeletalJointShoulder { get; set; }
                public String cboPMHMusculoskeletalJointShoulder { get; set; }
                public String cboPMHMusculoskeletalJointShoulderSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointShoulderMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointShoulder { get; set; }

                public bool chkPMHMusculoskeletalJointElbow { get; set; }
                public String cboPMHMusculoskeletalJointElbow { get; set; }
                public String cboPMHMusculoskeletalJointElbowSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointElbowMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointElbow { get; set; }

                public bool chkPMHMusculoskeletalJointWrist { get; set; }
                public String cboPMHMusculoskeletalJointWrist { get; set; }
                public String cboPMHMusculoskeletalJointWristSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointWristMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointWrist { get; set; }


                public bool chkPMHMusculoskeletalJointHand { get; set; }
                public String cboPMHMusculoskeletalJointHand { get; set; }
                public String cboPMHMusculoskeletalJointHandSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointHandMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointHand { get; set; }

                public bool chkPMHMusculoskeletalJointHip { get; set; }
                public String cboPMHMusculoskeletalJointHip { get; set; }
                public String cboPMHMusculoskeletalJointHipSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointHipMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointHip { get; set; }

                public bool chkPMHMusculoskeletalJointKnee { get; set; }
                public String cboPMHMusculoskeletalJointKnee { get; set; }
                public String cboPMHMusculoskeletalJointKneeSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointKneeMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointKnee { get; set; }

                public bool chkPMHMusculoskeletalJointAnkle { get; set; }
                public String cboPMHMusculoskeletalJointAnkle { get; set; }
                public String cboPMHMusculoskeletalJointAnkleSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointAnkleMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointAnkle { get; set; }

                public bool chkPMHMusculoskeletalJointFoot { get; set; }
                public String cboPMHMusculoskeletalJointFoot { get; set; }
                public String cboPMHMusculoskeletalJointFootSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointFootMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointFoot { get; set; }

                public bool chkPMHMusculoskeletalJointCervical { get; set; }
                public String cboPMHMusculoskeletalJointCervicalSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointCervicalMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointCervical { get; set; }

                public bool chkPMHMusculoskeletalJointThoracic { get; set; }
                public String cboPMHMusculoskeletalJointThoracicSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointThoracicMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointThoracic { get; set; }

                public bool chkPMHMusculoskeletalJointLumbar { get; set; }
                public String cboPMHMusculoskeletalJointLumbarSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointLumbarMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointLumbar { get; set; }

                public bool chkPMHMusculoskeletalJointSacral { get; set; }
                public String cboPMHMusculoskeletalJointSacralSurgery { get; set; }
                public bool chkPMHMusculoskeletalJointSacralMostSevere { get; set; }
                public String txtPMHMusculoskeletalJointSacral { get; set; }

                public bool chkPMHUrinaryIncontinence { get; set; }
                public String numPMHUrinaryIncontinenceFrequency { get; set; }
                public String cboPMHUrinaryIncontinenceFrequency { get; set; }
                public bool chkPMHUrinaryIncontinenceMostSevere { get; set; }

                public bool chkPMHFecalIncontinence { get; set; }
                public String numPMHFecalIncontinenceFrequency { get; set; }
                public String cboPMHFecalIncontinenceFrequency { get; set; }
                public bool chkPMHFecalIncontinenceMostSevere { get; set; }
                public bool chkPainNA { get; set; }
                public bool chkPainNo { get; set; }
                public bool chkPainYes { get; set; }
                public String cboPainType { get; set; }
                public String cboPainFrequency { get; set; }
                public String cboPainQuality { get; set; }
            public String rtxCommentsOnHxOfMusculoskeletalProblems { get; set; }
            public String GrammerText { get; set; }

            public string txtPMHCOPDOtherDescription { get; set; }
            public bool Wheezing { get; set; }
            public bool WheezingAM { get; set; }
            public bool WheezingPM { get; set; }
            public bool WheezingAllTheTime { get; set; }
            public bool WheezingWorsensWithExercise { get; set; }
            public bool WheezingWorsensWithDust { get; set; }
            public bool WheezingWorsensWithWeatherChange { get; set; }
            public bool WheezingWorsensStrongWithFumes { get; set; }
            public bool WheezingWorsensWithHotColdWater { get; set; }
            public bool URI { get; set; }
            public bool WheezingWorsensWithAnimals { get; set; }
            public bool WheezingWorsensWithChangeSeasons { get; set; }
            public bool chkPMHWheezingWorsensOther { get; set; }
            public String txtPMHWheezingWorsensOther { get; set; }
            public String AsthmaAttackFrequencyAmount { get; set; }
            public String AsthmaAttackFrequency { get; set; }
            public String WheezingAverageDaysPerMonth { get; set; }
            public String AsthmaLastSevereAttack { get; set; }
            public bool AsthmaTakesMedsPRN { get; set; }
            public String AsthmaHospitalizationERVisitsThisYear { get; set; }
            public String AsthmaHospitalizationERVisitsLastYear { get; set; }
            public bool AsthmaTakesMedsDaily { get; set; }
            public String numPMHERVisitsThisYear { get; set; }
            public String numPMHERVisitsLastYear { get; set; }
            public bool chkPMHTakesAsthmaMedsOther { get; set; }
            public String txtPMHTakesAsthmaMedsOther { get; set; }
            public String AsthmaSchoolWorkDaysMissed { get; set; }

            public string UserName { get; set; }

            public string FormType { get; set; }

            public bool chkUIncYes { get; set; }
            public bool chkUIncNo { get; set; }
            public bool chkUIncNA { get; set; }

            public bool chkFIncYes { get; set; }
            public bool chkFIncNo { get; set; }
            public bool chkFIncNA { get; set; }



    }
}
