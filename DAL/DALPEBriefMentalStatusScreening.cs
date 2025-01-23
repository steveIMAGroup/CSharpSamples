using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALPEBriefMentalStatusScreening : IDisposable
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

        public DataTable MetaDataState()
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                String strSql = string.Format("SELECT [StateCodeId], [StateName], [StateCode] FROM [Metadata].[StateCodes] Order by sequence");
                sqlcmd = new SqlCommand(strSql, sqlcon);
                sqlda = new SqlDataAdapter(sqlcmd);
                dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        private const string MAPTO_ACROSS_ENCOUNTER = "MapToAcrossEncounter";
        private const string DATA_INHERITANCE = "DataInheritance";
        private const string NOT_INHERITANCE = "NotInherited";

        public int SavePageasXML(entPEBriefMentalStatusScreening objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("6E610334-9F92-4D18-81D1-3ED13FD722B2");
                    }                   
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("1A77E14E-1159-4F26-8B98-F7C3E4B5E281");
                    }

                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "PE - Grip"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",

                   new XElement("chkAdequateGrooming", objEntity.chkAdequateGrooming, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkDisheveled", objEntity.chkDisheveled, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAbnormalPosture", objEntity.chkAbnormalPosture, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAppearanceOther", objEntity.chkAppearanceOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("txtAppearanceOther", objEntity.txtAppearanceOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                     new XElement("chkOriented", objEntity.chkOriented, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkDisoriented", objEntity.chkDisoriented, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkOrientationOther", objEntity.chkOrientationOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("txtOrientationOther", objEntity.txtOrientationOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                     new XElement("chkAppropriateBehavior", objEntity.chkAppropriateBehavior, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkPsychomotorAgitation", objEntity.chkPsychomotorAgitation, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkPsychomotorSlowing", objEntity.chkPsychomotorSlowing, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkTics", objEntity.chkTics, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkBehaviorOther", objEntity.chkBehaviorOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("txtBehaviorOther", objEntity.txtBehaviorOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                     new XElement("chkEuthymic", objEntity.chkEuthymic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkEuphoric", objEntity.chkEuphoric, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkDysthymic", objEntity.chkDysthymic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkDepressed", objEntity.chkDepressed, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkManic", objEntity.chkManic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkIrritable", objEntity.chkIrritable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAnxious", objEntity.chkAnxious, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAngry", objEntity.chkAngry, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkMoodOther", objEntity.chkMoodOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("txtMoodOther", objEntity.txtMoodOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                     new XElement("chkEyeContactGood", objEntity.chkEyeContactGood, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkEyeContactIntermittent", objEntity.chkEyeContactIntermittent, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkEyeContactPoor", objEntity.chkEyeContactPoor, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkEyeContactOther", objEntity.chkEyeContactOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("txtEyeContactOther", objEntity.txtEyeContactOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                     new XElement("chkCalmandCooperative", objEntity.chkCalmandCooperative, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkHostile", objEntity.chkHostile, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkDefensive", objEntity.chkDefensive, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkDemanding", objEntity.chkDemanding, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkGuarded", objEntity.chkGuarded, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkSuspicious", objEntity.chkSuspicious, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkSeductive", objEntity.chkSeductive, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAttitudeOther", objEntity.chkAttitudeOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("txtAttitudeOther", objEntity.txtAttitudeOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                     new XElement("chkAffectWide", objEntity.chkAffectWide, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chAffectRestricted", objEntity.chAffectRestricted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAffectBlunted", objEntity.chkAffectBlunted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAffectFlat", objEntity.chkAffectFlat, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkLabile", objEntity.chkLabile, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAffectInappropriate", objEntity.chkAffectInappropriate, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAffectOther", objEntity.chkAffectOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("txtAffectOther", objEntity.txtAffectOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                     new XElement("chkAttentionAdequate", objEntity.chkAttentionAdequate, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAttentionDistracted", objEntity.chkAttentionDistracted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkAttentionImpaired", objEntity.chkAttentionImpaired, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("txtAttentionImpaired", objEntity.txtAttentionImpaired, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                     new XElement("chkConcentrationGood", objEntity.chkConcentrationGood, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkConcentrationDifficult", objEntity.chkConcentrationDifficult, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkConcentrationModerate", objEntity.chkConcentrationModerate, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkConcentrationOther", objEntity.chkConcentrationOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("txtConcentrationOther", objEntity.txtConcentrationOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                     new XElement("chkMemoryRecent", objEntity.chkMemoryRecent, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("chkMemoryImpairment", objEntity.chkMemoryImpairment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                     new XElement("txtMemoryImpairment", objEntity.txtMemoryImpairment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)) 
                   

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
                        //  sqlcmd.Parameters.AddWithValue("@seq", 15);
                        if (objPatientPage.PatientFormId == Guid.Parse("6E610334-9F92-4D18-81D1-3ED13FD722B2"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 17);
                        }                        
                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 11);
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
            catch(Exception ex)
            {
               // throw ex;
            }
            return 1;
        }









    }

}
