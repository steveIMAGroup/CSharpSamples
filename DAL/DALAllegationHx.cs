using System;
using System.Data;
using System.Data.SqlClient;
using Cyramedx.PatientForms.Entities;
using System.Xml.Linq;

namespace Cyramedx.PatientForms.DAL
{
    public class DALAllegationHx:IDisposable
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

        public void UpdateGender(string personid,string gender)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                String strSql = string.Format("update dbo.Persons set Gender='{0}' where uid='{1}'",gender,personid);
                sqlcmd = new SqlCommand(strSql, sqlcon);
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string selectDefaultStateid(string ScheduleId)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                string getValue = string.Empty;
                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "selectDefaultStateid";
                sqlcmd.Parameters.AddWithValue("@Scheduleid", ScheduleId);
                sqlcon.Open();
                getValue = sqlcmd.ExecuteScalar().ToString();               
                sqlcon.Close();
                return getValue;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public string selectClinicName(string ScheduleId)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                string getValue = string.Empty;
                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "selectClinicName";
                sqlcmd.Parameters.AddWithValue("@Scheduleid", ScheduleId);
                sqlcon.Open();
                getValue = sqlcmd.ExecuteScalar().ToString();
                sqlcon.Close();
                return getValue;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public DataTable MetaDataState()
        {
            try
            {                
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                String strSql = string.Format("SELECT UID,ShortName FROM [dbo].[States] ");
                sqlcmd = new SqlCommand(strSql, sqlcon);
                sqlda = new SqlDataAdapter(sqlcmd);
                dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();

                DataRow dr=dt.NewRow();
                dr["UID"]=Guid.Empty.ToString();
                dr["ShortName"]=string.Empty;
                dt.Rows.InsertAt(dr, 0);
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
 
        public int SavePageasXML(entAllegationHx objEntity,Guid PatientSchedulesId)
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
                    v = objEntity.formtype;
                    if (v == "i")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("A0E2C939-19F0-493F-8A77-53717B485348");

                    }
                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("6F66CCEC-B618-4678-BB67-4F3B5619D67B");

                    }

                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("E54360E0-4811-4F30-B9E6-BD4D71536B63");
                    }
                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;
                   
                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "Allegations Social Hx"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                                    new XElement("cboFacilityState", objEntity.cboFacilityState, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
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
                                                    new XElement("chkMRReceivedYes", objEntity.chkMRReceivedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkMRReceivedNo", objEntity.chkMRReceivedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkMRReviewedYes", objEntity.chkMRReviewedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkMRReviewedNo", objEntity.chkMRReviewedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboIdentificationBy", objEntity.cboIdentificationBy, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboArrivedVia", objEntity.cboArrivedVia, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("ddlLanguageSpoken", objEntity.ddlLanguageSpoken, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkSpanishInterpreterUsedYes", objEntity.chkSpanishInterpreterUsedYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkSpanishInterpreterUsedNo", objEntity.chkSpanishInterpreterUsedNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkOtherInterpreterUsedYes", objEntity.chkOtherInterpreterUsedYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkOtherInterpreterUsedNo", objEntity.chkOtherInterpreterUsedNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtLanguageOther", objEntity.txtLanguageOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),                   

                                                    new XElement("cboSmokingStatus", objEntity.cboSmokingStatus, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("ddlSmokingType", objEntity.ddlSmokingType, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numTobaccoPacksPerDay", objEntity.numTobaccoPacksPerDay, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numTobaccoYears", objEntity.numTobaccoYears, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtTobaccoQuitDate", objEntity.txtTobaccoQuitDate, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAlcoholYes", objEntity.chkAlcoholYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAlcoholNo", objEntity.chkAlcoholNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("AlcoholUseId", objEntity.AlcoholUseId, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numAlcoholDrinksPerDay", objEntity.numAlcoholDrinksPerDay, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAlcoholQuit", objEntity.chkAlcoholQuit, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("dteAlcoholQuitDate", objEntity.dteAlcoholQuitDate, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("DrugUse", objEntity.DrugUse, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDrugUseNo", objEntity.chkDrugUseNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDrugQuit", objEntity.chkDrugQuit, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboIllicitDrugUseType", objEntity.cboIllicitDrugUseType, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboIllicitDrug2UseType", objEntity.cboIllicitDrug2UseType, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboIllicitDrug3UseType", objEntity.cboIllicitDrug3UseType, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("rtxIllicitDrugUseComments", objEntity.rtxIllicitDrugUseComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtReviewedExam", objEntity.txtReviewedExam, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("rtxAllegationsSocialHxComments", objEntity.rtxAllegationsSocialHxComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),




                                                    new XElement("chkNotRelevent", objEntity.chkNotRelevent, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkRelevent", objEntity.chkRelevent, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAppropriateYes", objEntity.chkAppropriateYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAppropriateNo", objEntity.chkAppropriateNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtFamilyHistoryContributory", objEntity.txtFamilyHistoryContributory, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("cboSourceOfHistory", objEntity.cboSourceOfHistory, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtSourceOfHistory", objEntity.txtSourceOfHistory, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER))
                                                    
                                                    )));
                    objPatientPage.PageXmlData = doc.ToString();
                }

                sqlcon = new SqlConnection(DBContext.GetConnectionString());

                if (objPatientPage != null)
                {
                    if (!String.IsNullOrEmpty(objEntity.Gender))
                        UpdateGender(objEntity.PersonId, objEntity.Gender);

                    DataSet dsIsCheck = objCommon.IsPageExist(objPatientPage.ScheduleId, objPatientPage.PatientFormId);
                    sqlcmd = null;
                    sqlcmd = new SqlCommand();
                    if (String.IsNullOrEmpty(objEntity.GrammerText))
                        objEntity.GrammerText = "";
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
                     //   sqlcmd.Parameters.AddWithValue("@seq", 1);
                        if (objPatientPage.PatientFormId == Guid.Parse("A0E2C939-19F0-493F-8A77-53717B485348"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 1);

                        }
                        else if (objPatientPage.PatientFormId == Guid.Parse("6F66CCEC-B618-4678-BB67-4F3B5619D67B"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 1);

                        } 
                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 1);
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

        public string getGrammerText(Guid PatientScheduleId, Guid PatientFormId)
        {
            try
            {
                Common objCommon = new Common();
                string strGrammerText = objCommon.GetPEVitalGrammerText(PatientScheduleId, PatientFormId);
                if (!string.IsNullOrEmpty(strGrammerText))
                    return strGrammerText;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }


    }
}
