using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALPEGrip:IDisposable
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

        public int SavePageasXML(entPEGrip objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("CA0B74D7-F904-40D5-B623-F014E3A2D476");
                    }
                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("1F30153E-0EC9-410B-92EE-DD087B5BB17E");
                    } 

                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("604A86E1-05AB-4E34-8C63-884C4CCD5DAB");
                    }
                   
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "PE - Grip"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",

                    new XElement("txtGripVerbiage", objEntity.txtGripVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkControlVisibility", objEntity.chkControlVisibility, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightNormalYes", objEntity.chkRightNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkRightNormalNo", objEntity.chkRightNormalNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("cboRightNormalGrade", objEntity.cboRightNormalGrade, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkDifficultyWithManipulativeSkillsRightYes", objEntity.chkDifficultyWithManipulativeSkillsRightYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkDifficultyWithManipulativeSkillsRightNo", objEntity.chkDifficultyWithManipulativeSkillsRightNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtRightHadDifficultyWithManipulativeSkills", objEntity.txtRightHadDifficultyWithManipulativeSkills, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightClaimantHadDifficultyButtoningYes", objEntity.chkRightClaimantHadDifficultyButtoningYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightClaimantHadDifficultyButtoningNo", objEntity.chkRightClaimantHadDifficultyButtoningNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("numRightClaimantHadDifficultyButtoning", objEntity.numRightClaimantHadDifficultyButtoning, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightClaimantHadDifficultyZippingYes", objEntity.chkRightClaimantHadDifficultyZippingYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightClaimantHadDifficultyZippingNo", objEntity.chkRightClaimantHadDifficultyZippingNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("numRightClaimantHadDifficultyZipping", objEntity.numRightClaimantHadDifficultyZipping, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightClaimantHadDifficultyPickingUpCoinYes", objEntity.chkRightClaimantHadDifficultyPickingUpCoinYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkRightClaimantHadDifficultyPickingUpCoinNo", objEntity.chkRightClaimantHadDifficultyPickingUpCoinNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("numRightClaimantHadDifficultyPickingUpCoin", objEntity.numRightClaimantHadDifficultyPickingUpCoin, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkRightClaimantHadDifficultyTyingShoeLacsYes", objEntity.chkRightClaimantHadDifficultyTyingShoeLacsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightClaimantHadDifficultyTyingShoeLacsNo", objEntity.chkRightClaimantHadDifficultyTyingShoeLacsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("numRightClaimantHadDifficultyTyingShoeLacs", objEntity.numRightClaimantHadDifficultyTyingShoeLacs, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftNormalYes", objEntity.chkLeftNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkLeftNormalNo", objEntity.chkLeftNormalNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("cboLeftNormalGrade", objEntity.cboLeftNormalGrade, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkDifficultyWithManipulativeSkillsLeftYes", objEntity.chkDifficultyWithManipulativeSkillsLeftYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkDifficultyWithManipulativeSkillsLeftNo", objEntity.chkDifficultyWithManipulativeSkillsLeftNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtLeftHadDifficultyWithManipulativeSkills", objEntity.txtLeftHadDifficultyWithManipulativeSkills, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftClaimantHadDifficultyButtoningYes", objEntity.chkLeftClaimantHadDifficultyButtoningYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftClaimantHadDifficultyButtoningNo", objEntity.chkLeftClaimantHadDifficultyButtoningNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("numLeftClaimantHadDifficultyButtoning", objEntity.numLeftClaimantHadDifficultyButtoning, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftClaimantHadDifficultyZippingYes", objEntity.chkLeftClaimantHadDifficultyZippingYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftClaimantHadDifficultyZippingNo", objEntity.chkLeftClaimantHadDifficultyZippingNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("numLeftClaimantHadDifficultyZipping", objEntity.numLeftClaimantHadDifficultyZipping, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftClaimantHadDifficultyPickingUpCoinYes", objEntity.chkLeftClaimantHadDifficultyPickingUpCoinYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkLeftClaimantHadDifficultyPickingUpCoinNo", objEntity.chkLeftClaimantHadDifficultyPickingUpCoinNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("numLeftClaimantHadDifficultyPickingUpCoin", objEntity.numLeftClaimantHadDifficultyPickingUpCoin, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkLeftClaimantHadDifficultyTyingShoeLacsYes", objEntity.chkLeftClaimantHadDifficultyTyingShoeLacsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftClaimantHadDifficultyTyingShoeLacsNo", objEntity.chkLeftClaimantHadDifficultyTyingShoeLacsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("numLeftClaimantHadDifficultyTyingShoeLacsNo", objEntity.numLeftClaimantHadDifficultyTyingShoeLacsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("chkRightNormalNA", objEntity.chkRightNormalNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightClaimantHadDifficultyButtoningNA", objEntity.chkRightClaimantHadDifficultyButtoningNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightClaimantHadDifficultyZippingNA", objEntity.chkRightClaimantHadDifficultyZippingNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightClaimantHadDifficultyPickingUpCoinNA", objEntity.chkRightClaimantHadDifficultyPickingUpCoinNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRightClaimantHadDifficultyTyingShoeLacsNA", objEntity.chkRightClaimantHadDifficultyTyingShoeLacsNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                     new XElement("chkLeftNormalNA", objEntity.chkLeftNormalNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftClaimantHadDifficultyButtoningNA", objEntity.chkLeftClaimantHadDifficultyButtoningNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftClaimantHadDifficultyZippingNA", objEntity.chkLeftClaimantHadDifficultyZippingNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftClaimantHadDifficultyPickingUpCoinNA", objEntity.chkLeftClaimantHadDifficultyPickingUpCoinNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkLeftClaimantHadDifficultyTyingShoeLacsNA", objEntity.chkLeftClaimantHadDifficultyTyingShoeLacsNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("rtxGripNotes", objEntity.rtxGripNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))
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
                        if (objPatientPage.PatientFormId == Guid.Parse("CA0B74D7-F904-40D5-B623-F014E3A2D476"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 15);
                        }
                        else if (objPatientPage.PatientFormId == Guid.Parse("1F30153E-0EC9-410B-92EE-DD087B5BB17E"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 15);
                        }
                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 8);
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
