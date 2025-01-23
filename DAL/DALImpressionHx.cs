using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALImpressionHx:IDisposable
    {
        SqlConnection sqlcon = null;
        SqlCommand sqlcmd = null;
        DataTable dt = null;
        SqlDataAdapter sqlda = null;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                sqlcon.Dispose();
                sqlcmd.Dispose();
                sqlda.Dispose();
                dt.Dispose();
              
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private const string MAPTO_ACROSS_ENCOUNTER = "MapToAcrossEncounter";
        private const string DATA_INHERITANCE = "DataInheritance";
        private const string NOT_INHERITANCE = "NotInherited";
 
        public int SavePageasXML1(entImpressionHx objEntity, Guid PatientSchedulesId)
        {
            try
            {
                Common objCommon = new Common();
                DataTable dt = objCommon.getPatientHeader(PatientSchedulesId);
                XDocument doc = null;
                entPatientPages objPatientPage = null;
                foreach (DataRow dr in dt.Rows)
                {
                    objPatientPage = new entPatientPages();
                    objPatientPage.ScheduleId = (Guid)dr["PatientSchedulesId"];
                    objPatientPage.PatientPageId = Guid.NewGuid();
                    string v;
                    v = objEntity.FormType;
                    if (v == "i")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("425CDF2F-5F41-4F30-9B89-166C5CF24F0F");
                    }
                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("2C0AF05F-F8FF-4645-B0C6-33F4C496CD15");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("0B85DF91-058F-4EA8-8DC2-CE2D20EA92B4");
                    }
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;
                    
                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "Impression Hx"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                                    new XElement("txtCCAllegation1", objEntity.txtCCAllegation1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation2", objEntity.txtCCAllegation2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation3", objEntity.txtCCAllegation3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation4", objEntity.txtCCAllegation4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation5", objEntity.txtCCAllegation5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation6", objEntity.txtCCAllegation6, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation7", objEntity.txtCCAllegation7, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation8", objEntity.txtCCAllegation8, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation9", objEntity.txtCCAllegation9, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation10", objEntity.txtCCAllegation10, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation11", objEntity.txtCCAllegation11, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCCAllegation12", objEntity.txtCCAllegation12, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                     new XElement("txtCCAllegation13", objEntity.txtCCAllegation13, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                      new XElement("txtCCAllegation14", objEntity.txtCCAllegation14, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                       new XElement("txtCCAllegation15", objEntity.txtCCAllegation15, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                        new XElement("txtCCAllegation16", objEntity.txtCCAllegation16, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                         new XElement("txtCCAllegation17", objEntity.txtCCAllegation17, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                          new XElement("txtCCAllegation18", objEntity.txtCCAllegation18, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                           new XElement("txtCCAllegation19", objEntity.txtCCAllegation19, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                            new XElement("txtCCAllegation20", objEntity.txtCCAllegation20, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtImpression1", objEntity.txtImpression1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression2", objEntity.txtImpression2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression3", objEntity.txtImpression3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression4", objEntity.txtImpression4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression5", objEntity.txtImpression5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression6", objEntity.txtImpression6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression7", objEntity.txtImpression7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression8", objEntity.txtImpression8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression9", objEntity.txtImpression9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression10", objEntity.txtImpression10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression11", objEntity.txtImpression11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtImpression12", objEntity.txtImpression12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                     new XElement("txtImpression13", objEntity.txtImpression13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                      new XElement("txtImpression14", objEntity.txtImpression14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                       new XElement("txtImpression15", objEntity.txtImpression15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                        new XElement("txtImpression16", objEntity.txtImpression16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                         new XElement("txtImpression17", objEntity.txtImpression17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                          new XElement("txtImpression18", objEntity.txtImpression18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                           new XElement("txtImpression19", objEntity.txtImpression19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                            new XElement("txtImpression20", objEntity.txtImpression20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantCooperatedYes", objEntity.chkClaimantCooperatedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantCooperatedNo", objEntity.chkClaimantCooperatedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtReachingHandlingGraspingVerbiageLimitationsVerbiage", objEntity.txtReachingHandlingGraspingVerbiageLimitationsVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("rtxAdditionalImpressions", objEntity.rtxAdditionalImpressions, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantHasNoLimitations", objEntity.chkClaimantHasNoLimitations, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkClaimantHasLimitations", objEntity.chkClaimantHasLimitations, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    
                                                    new XElement("chkLimitationsStanding", objEntity.chkLimitationsStanding, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboLimitationsStandingFrequency", objEntity.cboLimitationsStandingFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkLimitationsSitting", objEntity.chkLimitationsSitting, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboLimitationsSittingFrequency", objEntity.cboLimitationsSittingFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkLimitationsWalking", objEntity.chkLimitationsWalking, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboLimitationsWalkingFrequency", objEntity.cboLimitationsWalkingFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkLimitationsBending", objEntity.chkLimitationsBending, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsBendingNotes", objEntity.txtLimitationsBendingNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLimitationsReaching", objEntity.chkLimitationsReaching, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsReachingNotes", objEntity.txtLimitationsReachingNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkLimitationsLifting", objEntity.chkLimitationsLifting, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLimitationsLiftingLeft", objEntity.chkLimitationsLiftingLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboLimitationsLiftingAmount", objEntity.cboLimitationsLiftingAmount, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboLimitationsLiftingFrequency", objEntity.cboLimitationsLiftingFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLimitationsLiftingRight", objEntity.chkLimitationsLiftingRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboLimitationsLiftingAmount2", objEntity.cboLimitationsLiftingAmount2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboLimitationsLiftingFrequency2", objEntity.cboLimitationsLiftingFrequency2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    
                                                    new XElement("txtLimitationsLiftingAndCarryingNotes", objEntity.txtLimitationsLiftingAndCarryingNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkLimitationsSeeing", objEntity.chkLimitationsSeeing, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsSeeingNotes", objEntity.txtLimitationsSeeingNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLimitationsHearing", objEntity.chkLimitationsHearing, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsHearingNotes", objEntity.txtLimitationsHearingNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpeech", objEntity.chkSpeech, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsSpeechNotes", objEntity.txtLimitationsSpeechNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkDriving", objEntity.chkDriving, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsDrivingNotes", objEntity.txtLimitationsDrivingNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboPercentageofUnderstandableSpeech", objEntity.cboPercentageofUnderstandableSpeech, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboDrivingDuration", objEntity.cboDrivingDuration, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLimitationsExposureDust", objEntity.chkLimitationsExposureDust, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsExposureDustNotes", objEntity.txtLimitationsExposureDustNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLimitationsUnderstanding", objEntity.chkLimitationsUnderstanding, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsUnderstandingNotes", objEntity.txtLimitationsUnderstandingNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSignificantLimitationsExplanation", objEntity.txtSignificantLimitationsExplanation, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkAmbulatesWithoutDifficultyAndAssistiveDevice", objEntity.chkAmbulatesWithoutDifficultyAndAssistiveDevice, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAmbulatesWithDifficultyWithoutAssistiveDevice", objEntity.chkAmbulatesWithDifficultyWithoutAssistiveDevice, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAmbulatesWithDifficultyAndUsesAssistiveDevice", objEntity.chkAmbulatesWithDifficultyAndUsesAssistiveDevice, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAmbulatesWithDifficultyAssistiveDeviceRequired", objEntity.chkAmbulatesWithDifficultyAssistiveDeviceRequired, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkClaimantUnableToAmbulateAtAll", objEntity.chkClaimantUnableToAmbulateAtAll, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    
                                                    new XElement("chkAnyChestPainInTheLast6MonthsYes", objEntity.chkAnyChestPainInTheLast6MonthsYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboRecentHistoryChestPainAngina", objEntity.cboRecentHistoryChestPainAngina, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                     new XElement("chkAnyChestPainInTheLast6MonthsYesforMedplus", objEntity.chkAnyChestPainInTheLast6MonthsYesforMedplus, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboRecentHistoryChestPainAnginaforMedplus", objEntity.cboRecentHistoryChestPainAnginaforMedplus, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("txtReachingHandlingGraspingVerbiageLimitationsVerbiage", objEntity.txtReachingHandlingGraspingVerbiageLimitationsVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),





                                                    new XElement("chkFunctionComparisonYes", objEntity.chkFunctionComparisonYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkFunctionComparisonNo", objEntity.chkFunctionComparisonNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtFunctionComparison", objEntity.txtFunctionComparison, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



                                                    //new XElement("chkBehavioralProblems", objEntity.chkBehavioralProblems, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkBehavorialProblemsOnTreatment", objEntity.chkBehavorialProblemsOnTreatment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkBehavorialProblemsNoOnTreatment", objEntity.chkBehavorialProblemsNoOnTreatment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("txtBehavorialProblems", objEntity.txtBehavorialProblems, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



                                                    //new XElement("chkShortAttentionSpan", objEntity.chkShortAttentionSpan, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkAttentionSpanOnTreatment", objEntity.chkAttentionSpanOnTreatment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkAttentionSpanNoOnTreatment", objEntity.chkAttentionSpanNoOnTreatment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("txtAttentionSpan", objEntity.txtAttentionSpan, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    




                                                    //new XElement("chkRollOverYes", objEntity.chkRollOverYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkRollOverNo", objEntity.chkRollOverNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkRollOverNotApplicable", objEntity.chkRollOverNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("txtRollOver", objEntity.txtRollOver, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    //new XElement("chkSitupYes", objEntity.chkSitupYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkSitupNo", objEntity.chkSitupNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkSitupNotApplicable", objEntity.chkSitupNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("txtSitup", objEntity.txtSitup, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    //new XElement("chkCrawlYes", objEntity.chkCrawlYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkCrawlNo", objEntity.chkCrawlNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkCrawlNotApplicable", objEntity.chkCrawlNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("txtCrawl", objEntity.txtCrawl, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    //new XElement("chkPullupYes", objEntity.chkPullupYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkPullupNo", objEntity.chkPullupNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkPullupNotApplicable", objEntity.chkPullupNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("txtPullup", objEntity.txtPullup, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    //new XElement("chkStandUnassistedYes", objEntity.chkStandUnassistedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkStandUnassistedNo", objEntity.chkStandUnassistedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkStandUnassistedNotApplicable", objEntity.chkStandUnassistedNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("txtStandUnassisted", objEntity.txtStandUnassisted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    //new XElement("chkWalkYes", objEntity.chkWalkYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkWalkNo", objEntity.chkWalkNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkWalkNotApplicable", objEntity.chkWalkNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("txtWalk", objEntity.txtWalk, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    //new XElement("chkCannotWalkYes", objEntity.chkCannotWalkYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkCannotWalkNo", objEntity.chkCannotWalkNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkCannotWalkNotApplicable", objEntity.chkCannotWalkNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("txtCannotWalk", objEntity.txtCannotWalk, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



                                                    new XElement("chkPhysicalLimitationsYes", objEntity.chkPhysicalLimitationsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPhysicalLimitationsNo", objEntity.chkPhysicalLimitationsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPhysicalLimitations", objEntity.txtPhysicalLimitations, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkBehavioralDevelopmentalLimitationsYes", objEntity.chkBehavioralDevelopmentalLimitationsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkBehavioralDevelopmentalLimitationsNo", objEntity.chkBehavioralDevelopmentalLimitationsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtBehavioralDevelopmentalLimitations", objEntity.txtBehavioralDevelopmentalLimitations, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkTheraphyTreatmentYes", objEntity.chkTheraphyTreatmentYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkTheraphyTreatmentNo", objEntity.chkTheraphyTreatmentNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtTheraphyTreatment", objEntity.txtTheraphyTreatment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkeffortPoor", objEntity.chkeffortPoor, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkeffortFair", objEntity.chkeffortFair, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                     new XElement("chkeffortGood", objEntity.chkeffortGood, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkeffortExcellent", objEntity.chkeffortExcellent, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txteffortComment", objEntity.txteffortComment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("txtclaimantnotcooperated", objEntity.txtclaimantnotcooperated, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("txtLimitationsStandingFrequency", objEntity.txtLimitationsStandingFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsSittingFrequency", objEntity.txtLimitationsSittingFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsWalkingFrequency", objEntity.txtLimitationsWalkingFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboLimitationsBending", objEntity.cboLimitationsBending, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboLimitationsReaching", objEntity.cboLimitationsReaching, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



                                                    new XElement("txtLimitationsVerbiage", objEntity.txtLimitationsVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER))
                                                                                                     
                                                   )));
                    objPatientPage.PageXmlData = doc.ToString();
                       }

                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                if (String.IsNullOrEmpty(objEntity.GrammerText))
                    objEntity.GrammerText = "";
                if (objPatientPage != null)
                {
                    DataSet dsIsCheck = objCommon.IsPageExist(objPatientPage.ScheduleId, objPatientPage.PatientFormId);
                    sqlcmd = null;
                    sqlcmd = new SqlCommand();
                    if (dsIsCheck != null && dsIsCheck.Tables.Count > 0 && dsIsCheck.Tables[0].Rows.Count > 0)
                    {
                        sqlcmd.Parameters.AddWithValue("@PatientPageId", objPatientPage.PatientPageId);
                        sqlcmd.Parameters.AddWithValue("@PatientFormId", objPatientPage.PatientFormId);
                        sqlcmd.Parameters.AddWithValue("@PageXmlData", objPatientPage.PageXmlData);
                        sqlcmd.Parameters.AddWithValue("@GrammerText", objEntity.GrammerText);
                        sqlcmd.Parameters.AddWithValue("@ScheduleId", objPatientPage.ScheduleId);
                        sqlcmd.Parameters.AddWithValue("@IsDeleted", objPatientPage.IsDeleted);
                        sqlcmd.Parameters.AddWithValue("@CreatedBy", objPatientPage.CreatedBy);
                        sqlcmd.Parameters.AddWithValue("@CreatedOn", objPatientPage.CreatedOn);
                        sqlcmd.Parameters.AddWithValue("@ModifiedBy", objEntity.UserName);
                        sqlcmd.Parameters.AddWithValue("@ModifiedOn", objPatientPage.ModifiedOn);

                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "updatePatientPages";
                        sqlcmd.Connection = sqlcon;
                        sqlcon.Open();
                        int retValue = sqlcmd.ExecuteNonQuery();
                        sqlcon.Close();
                        return retValue;

                    }
                    else
                    {

                        sqlcmd.Parameters.AddWithValue("@PatientPageId", objPatientPage.PatientPageId);
                        sqlcmd.Parameters.AddWithValue("@PatientFormId", objPatientPage.PatientFormId);
                        sqlcmd.Parameters.AddWithValue("@PageXmlData", objPatientPage.PageXmlData);
                        sqlcmd.Parameters.AddWithValue("@GrammerText", objEntity.GrammerText);
                        sqlcmd.Parameters.AddWithValue("@ScheduleId", objPatientPage.ScheduleId);
                        sqlcmd.Parameters.AddWithValue("@IsDeleted", objPatientPage.IsDeleted);
                        sqlcmd.Parameters.AddWithValue("@CreatedBy", objEntity.UserName);
                        sqlcmd.Parameters.AddWithValue("@CreatedOn", objPatientPage.CreatedOn);
                        sqlcmd.Parameters.AddWithValue("@ModifiedBy", objPatientPage.ModifiedBy);
                        sqlcmd.Parameters.AddWithValue("@ModifiedOn", objPatientPage.ModifiedOn);
                       // sqlcmd.Parameters.AddWithValue("@seq", 19);
                        if (objPatientPage.PatientFormId == Guid.Parse("425CDF2F-5F41-4F30-9B89-166C5CF24F0F"))
                        {
                           // sqlcmd.Parameters.AddWithValue("@seq", 19);
                            sqlcmd.Parameters.AddWithValue("@seq", 20);
                        }
                        else if (objPatientPage.PatientFormId == Guid.Parse("2C0AF05F-F8FF-4645-B0C6-33F4C496CD15"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 19);
                        }
                        else
                        {
                           // sqlcmd.Parameters.AddWithValue("@seq", 13);
                            sqlcmd.Parameters.AddWithValue("@seq", 14);
                        }
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "insertPatientPages";
                        sqlcmd.Connection = sqlcon;
                        sqlcon.Open();
                        int retValue = sqlcmd.ExecuteNonQuery();
                        sqlcon.Close();
                        return retValue;
                    }
                }
            }
            catch
            {

            }
            return 1;
        }
    }
}
