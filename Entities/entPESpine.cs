using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entPESpine
    {
        public bool chkGenitaliaDeferred { get; set; }
        public bool chkGenitaliaExaminedYes { get; set; }
        public bool chkGenitaliaExaminedNo { get; set; }
        public bool chkGenitaliaRevealedAnIndirectInguinalHernia { get; set; }
        public string cboGenitaliaRevealedAnIndirectInguinalHerniaJointArea { get; set; }
        public string cboGenitaliaRevealedAnIndirectInguinalHernia { get; set; }
        public string txtGenitaliaRevealedAnIndirectInguinalHernia { get; set; }
        public bool chkGenitaliaRevealedADirectInguinalHernia { get; set; }
        public string cboGenitaliaRevealedADirectInguinalHerniaJointArea { get; set; }
        public string cboGenitaliaRevealedADirectInguinalHernia { get; set; }
        public string txtGenitaliaRevealedADirectInguinalHernia { get; set; }
        public bool chkThereWasScoliosisNotedYes { get; set; }
        public bool chkThereWasScoliosisNotedNo { get; set; }
        public string txtThereWasScoliosisNoted { get; set; }
        public bool chkThereWasSpasmOfTheParaspinousMusclesYes { get; set; }
        public bool chkThereWasSpasmOfTheParaspinousMusclesNo { get; set; }
        public string txtThereWasSpasmOfTheParaspinousMuscles { get; set; }
        public bool chkThereWasKyphosisNotedYes { get; set; }
        public bool chkThereWasKyphosisNotedNo { get; set; }
        public string txtThereWasKyphosisNoted { get; set; }
        public bool chkSittingStraightLegRaisingIsNormalYes { get; set; }
        public bool chkSittingStraightLegRaisingIsNormalNo { get; set; }
        public string txtSittingStraightLegRaisingIsNormal { get; set; }
        public string numSittingStraightLeftLegRaisingDegrees { get; set; }
        public string txtLeftLegDegrees { get; set; }
        public string numSittingStraightRightLegRaisingDegrees { get; set; }
        public string txtRightLegDegrees { get; set; }
        public bool chkSupineStraightLegRaisingNormalYes { get; set; }
        public bool chkSupineStraightLegRaisingNormalNo { get; set; }
        public string txtSupineStraightLegRaisingComments { get; set; }
        public string numSupineLeftLegRaisingDegrees { get; set; }
        public string txtLeftLegDegrees1 { get; set; }
        public string numSupineRightLegRaisingDegrees { get; set; }
        public string txtRightLegDegrees1 { get; set; }
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
        public string txtManeuversAdditionalComments { get; set; }
        public String GrammerText { get; set; }
        public string FormType { get; set; }
        public string UserName { get; set; }

        public string txtOther { get; set; }
        public bool chkOther { get; set; }

        public bool chkManeuversClaimantCanWalkOnToesNotApplicable { get; set; }
                        
        public bool chkManeuversClaimantCanWalkOnHeelsNotApplicable { get; set; }
        public bool chkManeuversClaimantCanSquatNotApplicable { get; set; }
        public bool chkManeuversClaimantCanTandemHeelWalkNotApplicable { get; set; }
        public bool chkManeuversClaimantBendOverAndTouchTheirToesNotApplicable { get; set; }

        public bool chkSittingStraightLegRaisingIsNormalLeftNormal { get; set; }
        public bool chkSittingStraightLegRaisingIsNormalLeftAbnormal { get; set; }
        public bool chkSittingStraightLegRaisingIsNormalRightNormal { get; set; }
        public bool chkSittingStraightLegRaisingIsNormalRightAbnormal { get; set; }
        public bool chkSupineStraightLegRaisingLeftNormal { get; set; }
        public bool chkSupineStraightLegRaisingLeftAbNormal { get; set; }
        public bool chkSupineStraightLegRaisingRightNormal { get; set; }
        public bool chkSupineStraightLegRaisingRightAbNormal { get; set; }
        public bool chkSittingStraightLegRaisingIsNormalLeftPainYes { get; set; }
        public bool chkSittingStraightLegRaisingIsNormalLeftPainNo { get; set; }
        public bool chkSittingStraightLegRaisingIsNormalRightPainYes { get; set; }
        public bool chkSittingStraightLegRaisingIsNormalRightPainNo { get; set; }
        public bool chkSupineStraightLegRaisingLeftPainYes { get; set; }
        public bool chkSupineStraightLegRaisingLeftPainNo { get; set; }
        public bool chkSupineStraightLegRaisingRightPainYes { get; set; }
        public bool chkSupineStraightLegRaisingRightPainNo { get; set; }

        public string txtRightLegDegrees2 { get; set; }
        public string txtLeftLegDegrees3 { get; set; }
        public string txtLeftLegDegrees2 { get; set; }
        public string txtLeftLegDegrees4 { get; set; }
        public string txtOtherCommentsOnSpine { get; set; }

        public bool chkparaplegicYes { get; set; }
        public bool chkparaplegicNo { get; set; }
        public string txtparaplegicComment { get; set; }

        public bool chkeffortPoor { get; set; }
        public bool chkeffortFair { get; set; }
        public bool chkeffortGood { get; set; }
        public bool chkeffortExcellent { get; set; }
        public string txteffortComment { get; set; }
    }
}
