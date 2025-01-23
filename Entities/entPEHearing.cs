using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entPEHearing
    {
        public bool chkHearingIsGrosslyNormal { get; set; }
        public bool chkHearingIsGrosslyNormalNo { get; set; }
        public bool chkClaimantCanHearConversationAtNormalVoiceLevel { get; set; }
        public bool chkClaimantHasDifficultHearingSpeechAtNormalVoice { get; set; }
        public bool chkClaimantDoesNotWearAnyTypeOfHearingAid { get; set; }
        public bool chkClaimantWearsAHearingAid { get; set; }
        public string txtDifficultyInHearing { get; set; }


        public bool chkSpeechUnderstandableYes { get; set; }
        public bool chkSpeechUnderstandableNo { get; set; }
        public bool chkSpeechIsDifficultToUnderstand { get; set; }
        public bool chkSpeechIsHalting { get; set; }
        public bool chkClaimantStutters { get; set; }
        public bool chkSpeechIsSlurred { get; set; }
        public bool chkSpeechOther { get; set; }
        public string txtSpeechOther { get; set; }
        public string numPercentSpeechTheExaminerUnderstand { get; set; }
        public string rtxCommentsOnSpeech { get; set; }
        public bool chkSkinIsClearWithNoLesionsNotes { get; set; }


        public bool chkClaimantAppearsToHavePsoriasis { get; set; }
        public string numClaimantAppearsToHavePsoriasisPercentage { get; set; }
        public bool chkClaimantAppearsToHaveDiscoloration { get; set; }
        public string numClaimantAppearsToHaveDiscolorationPercentage { get; set; }

        public bool chkClaimantAppearsToHaveIrritatedRash { get; set; }
        public string numClaimantAppearsToHaveIrritatedRashPercentage { get; set; }
        public bool chkClaimantAppearsToHaveErythema { get; set; }
        public string numClaimantAppearsToHaveErythemaPercentage { get; set; }

        public bool chkClaimantAppearsToHaveEczema { get; set; }
        public string numClaimantAppearsToHaveEczemaPercentage { get; set; }
        public bool chkClaimantAppearsToHaveScarring { get; set; }
        public string numClaimantAppearsToHaveScarringPercentage { get; set; }

        public bool chkClaimantAppearsToHaveFungalRash { get; set; }
        public string numClaimantAppearsToHaveFungalRashPercentage { get; set; }
        public bool chkClaimantAppearsToHaveWeepingRash { get; set; }
        public string numClaimantAppearsToHaveWeepingRashPercentage { get; set; }

        public bool chkClaimantAppearsToHaveOther { get; set; }
        public string txtClaimantAppearsToHaveOther { get; set; }

        public string rtxCommentsOnSkin { get; set; }
        public string GrammerText { get; set; }
        public string UserName { get; set; }


        public bool chkReceptiveLanguageYes { get; set; }
        public bool chkReceptiveLanguageNo { get; set; }
        public string txtReceptiveLanguage { get; set; }

        public bool chkExpressiveLanguageYes { get; set; }
        public bool chkExpressiveLanguageNo { get; set; }
        public string txtExpressiveLanguage { get; set; }

        public string FormType { get; set; }

        public bool chkReceptiveLanguageNA { get; set; }
        public bool chkExpressiveLanguageNA { get; set; }

        public bool chkHearingReactSoundYes { get; set; }
        public bool chkHearingReactSoundNo { get; set; }
        public bool chkHearingReactSoundNA { get; set; }
        public bool chkSpeechUnderstandableNA { get; set; }
        
        
    }
}
