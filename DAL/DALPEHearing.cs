using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALPEHearing:IDisposable
    {
        SqlConnection sqlcon = null;
        SqlCommand sqlcmd = null;
        DataTable dt = null;
        SqlDataAdapter sqlda = null;
        DataSet ds = null;
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                sqlcon.Dispose();
                sqlcmd.Dispose();
                sqlda.Dispose();
                dt.Dispose();
                ds.Dispose();
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

        public int SavePageasXML3(entPEHearing objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("C26E47BE-0FC3-473F-9101-430BD449AB7D");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("7D2E9862-C570-4462-BF85-9E7A67DAD9A9");
                    }

                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "PE-Hearing Speech"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",

                                                    new XElement("chkHearingIsGrosslyNormal", objEntity.chkHearingIsGrosslyNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHearingIsGrosslyNormalNo", objEntity.chkHearingIsGrosslyNormalNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantCanHearConversationAtNormalVoiceLevel", objEntity.chkClaimantCanHearConversationAtNormalVoiceLevel, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantHasDifficultHearingSpeechAtNormalVoice", objEntity.chkClaimantHasDifficultHearingSpeechAtNormalVoice, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantDoesNotWearAnyTypeOfHearingAid", objEntity.chkClaimantDoesNotWearAnyTypeOfHearingAid, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantWearsAHearingAid", objEntity.chkClaimantWearsAHearingAid, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtDifficultyInHearing", objEntity.txtDifficultyInHearing, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpeechUnderstandableYes", objEntity.chkSpeechUnderstandableYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpeechUnderstandableNo", objEntity.chkSpeechUnderstandableNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpeechIsDifficultToUnderstand", objEntity.chkSpeechIsDifficultToUnderstand, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpeechIsHalting", objEntity.chkSpeechIsHalting, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantStutters", objEntity.chkClaimantStutters, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpeechIsSlurred", objEntity.chkSpeechIsSlurred, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpeechOther", objEntity.chkSpeechOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSpeechOther", objEntity.txtSpeechOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numPercentSpeechTheExaminerUnderstand", objEntity.numPercentSpeechTheExaminerUnderstand, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("rtxCommentsOnSpeech", objEntity.rtxCommentsOnSpeech, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSkinIsClearWithNoLesionsNotes", objEntity.chkSkinIsClearWithNoLesionsNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantAppearsToHavePsoriasis", objEntity.chkClaimantAppearsToHavePsoriasis, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numClaimantAppearsToHavePsoriasisPercentage", objEntity.numClaimantAppearsToHavePsoriasisPercentage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantAppearsToHaveDiscoloration", objEntity.chkClaimantAppearsToHaveDiscoloration, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numClaimantAppearsToHaveDiscolorationPercentage", objEntity.numClaimantAppearsToHaveDiscolorationPercentage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantAppearsToHaveIrritatedRash", objEntity.chkClaimantAppearsToHaveIrritatedRash, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numClaimantAppearsToHaveIrritatedRashPercentage", objEntity.numClaimantAppearsToHaveIrritatedRashPercentage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantAppearsToHaveErythema", objEntity.chkClaimantAppearsToHaveErythema, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numClaimantAppearsToHaveErythemaPercentage", objEntity.numClaimantAppearsToHaveErythemaPercentage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantAppearsToHaveEczema", objEntity.chkClaimantAppearsToHaveEczema, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numClaimantAppearsToHaveEczemaPercentage", objEntity.numClaimantAppearsToHaveEczemaPercentage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantAppearsToHaveScarring", objEntity.chkClaimantAppearsToHaveScarring, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numClaimantAppearsToHaveScarringPercentage", objEntity.numClaimantAppearsToHaveScarringPercentage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkClaimantAppearsToHaveFungalRash", objEntity.chkClaimantAppearsToHaveFungalRash, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numClaimantAppearsToHaveFungalRashPercentage", objEntity.numClaimantAppearsToHaveFungalRashPercentage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantAppearsToHaveWeepingRash", objEntity.chkClaimantAppearsToHaveWeepingRash, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numClaimantAppearsToHaveWeepingRashPercentage", objEntity.numClaimantAppearsToHaveWeepingRashPercentage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantAppearsToHaveOther", objEntity.chkClaimantAppearsToHaveOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtClaimantAppearsToHaveOther", objEntity.txtClaimantAppearsToHaveOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("rtxCommentsOnSkin", objEntity.rtxCommentsOnSkin, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                     new XElement("chkHearingReactSoundYes", objEntity.chkHearingReactSoundYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHearingReactSoundNo", objEntity.chkHearingReactSoundNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHearingReactSoundNA", objEntity.chkHearingReactSoundNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkReceptiveLanguageYes", objEntity.chkReceptiveLanguageYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkReceptiveLanguageNo", objEntity.chkReceptiveLanguageNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtReceptiveLanguage", objEntity.txtReceptiveLanguage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkExpressiveLanguageYes", objEntity.chkExpressiveLanguageYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkExpressiveLanguageNo", objEntity.chkExpressiveLanguageNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpeechUnderstandableNA", objEntity.chkSpeechUnderstandableNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtExpressiveLanguage", objEntity.txtExpressiveLanguage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))
                                                    

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
                        sqlcmd.Parameters.AddWithValue("@seq", 11);

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
