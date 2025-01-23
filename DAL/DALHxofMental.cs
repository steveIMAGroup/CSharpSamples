using System;
using System.Data;
using System.Data.SqlClient;
using Cyramedx.PatientForms.Entities;
using System.Xml.Linq;

namespace Cyramedx.PatientForms.DAL
{
    public class DALHxofMental:IDisposable
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


        public int SavePageasXML1(entHxofMental objEntity, Guid PatientSchedulesId)
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
                    if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("AC1535E9-9AE4-405D-89E4-EE42B7611067");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("F1E8146C-F233-4934-A67E-525042D2D1B4");
                    }

                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "Hx Of Mental"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                new XElement("NoHistoryOfHeadDisease", objEntity.NoHistoryOfHeadDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("Depression", objEntity.Depression, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("Anxiety", objEntity.Anxiety, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("chkPMHMentalPanicAttacks", objEntity.chkPMHMentalPanicAttacks, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("Bipolar", objEntity.Bipolar, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("chkPMHMentalOther", objEntity.chkPMHMentalOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("txtPMHMentalOther", objEntity.txtPMHMentalOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("chkPMHMentalHospitalizationsYes", objEntity.chkPMHMentalHospitalizationsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkPMHMentalHospitalizationsNo", objEntity.chkPMHMentalHospitalizationsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("txtPMHMentalHospitalizationsNotes", objEntity.txtPMHMentalHospitalizationsNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkSuicideAttemptYes", objEntity.chkSuicideAttemptYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkSuicideAttemptNo", objEntity.chkSuicideAttemptNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("numSuicideAttemptAmount", objEntity.numSuicideAttemptAmount, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("txtSuicideAttemptLastAttempt", objEntity.txtSuicideAttemptLastAttempt, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkTakesMedsForConditionYes", objEntity.chkTakesMedsForConditionYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkTakesMedsForConditionNo", objEntity.chkTakesMedsForConditionNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("numTakesMedsForConditionSince", objEntity.numTakesMedsForConditionSince, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("cboTakesMedsForConditionSince", objEntity.cboTakesMedsForConditionSince, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("rtxMedicationComment", objEntity.rtxMedicationComment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkCanHandleOwnFinancesYes", objEntity.chkCanHandleOwnFinancesYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkCanHandleOwnFinancesNo", objEntity.chkCanHandleOwnFinancesNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("txtCanHandleOwnFinancesWhyNot", objEntity.txtCanHandleOwnFinancesWhyNot, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkPMHMentalConditionAffectAbilityToWorkYes", objEntity.chkPMHMentalConditionAffectAbilityToWorkYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkPMHMentalConditionAffectAbilityToWorkNo", objEntity.chkPMHMentalConditionAffectAbilityToWorkNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("rtxPMHMentalConditionAffectAbilityToWorkHow", objEntity.rtxPMHMentalConditionAffectAbilityToWorkHow, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("NoHistoryOfSkinDisease", objEntity.NoHistoryOfSkinDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("Psoriasis", objEntity.Psoriasis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("chkHxOfSkinProblemsEczema", objEntity.chkHxOfSkinProblemsEczema, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("chkHxOfSkinProblemsFungal", objEntity.chkHxOfSkinProblemsFungal, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("chkPMHHxOfSkinProblemsSkinCancer", objEntity.chkPMHHxOfSkinProblemsSkinCancer, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("chkHxOfSkinProblemsOther", objEntity.chkHxOfSkinProblemsOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("txtHxOfSkinProblemsOtherDescription", objEntity.txtHxOfSkinProblemsOtherDescription, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                new XElement("chkHxOfSkinProblemsSkinConditionAffectWorkYes", objEntity.chkHxOfSkinProblemsSkinConditionAffectWorkYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkHxOfSkinProblemsSkinConditionAffectWorkNo", objEntity.chkHxOfSkinProblemsSkinConditionAffectWorkNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("rtxHxOfSkinProblemsAffectedNotes", objEntity.rtxHxOfSkinProblemsAffectedNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                new XElement("chkPreschoolPerformanceYes", objEntity.chkPreschoolPerformanceYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkPreschoolPerformanceNo", objEntity.chkPreschoolPerformanceNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("txtPreschoolPerformance", objEntity.txtPreschoolPerformance, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                new XElement("chkDaycarePerformanceYes", objEntity.chkDaycarePerformanceYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkDaycarePerformanceNo", objEntity.chkDaycarePerformanceNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("txtDaycarePerformance", objEntity.txtDaycarePerformance, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                new XElement("chkSchoolPerformanceYes", objEntity.chkSchoolPerformanceYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkSchoolPerformanceNo", objEntity.chkSchoolPerformanceNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("txtSchoolPerformance", objEntity.txtSchoolPerformance, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                new XElement("chkBehaviorProblemNo", objEntity.chkBehaviorProblemNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkBehaviorProblemYes", objEntity.chkBehaviorProblemYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("txtBehaviorProblem", objEntity.txtBehaviorProblem, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                new XElement("chkAttentionSpanNormal", objEntity.chkAttentionSpanNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkAttentionSpanAbnormal", objEntity.chkAttentionSpanAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                new XElement("chkPreschoolPerformanceNA", objEntity.chkPreschoolPerformanceNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkDaycarePerformanceNA", objEntity.chkDaycarePerformanceNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                new XElement("chkSchoolPerformanceNA", objEntity.chkSchoolPerformanceNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                 new XElement("chkBehaviorProblemNA", objEntity.chkBehaviorProblemNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                 new XElement("chkAttentionSpanNA", objEntity.chkAttentionSpanNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                new XElement("txtAttentionSpan", objEntity.txtAttentionSpan, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))
                                
                        

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
                        sqlcmd.Parameters.AddWithValue("@seq", 5);

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