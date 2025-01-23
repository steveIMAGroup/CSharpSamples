using System;
using System.Data;
using System.Data.SqlClient;
using Cyramedx.PatientForms.Entities;
using System.Xml.Linq;

namespace Cyramedx.PatientForms.DAL
{
    public class DALHxOfDigestive:IDisposable
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

        public int SavePageasXML1(entHxOfDigestive objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("1FC0D09D-0F44-4C67-A324-A449F5617738");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("D0D623F0-F30D-462A-9658-447E98AF140C");
                    }

                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "Digestive Hx"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                                    new XElement("NoHistoryOfGastrointestinalDisease", objEntity.NoHistoryOfGastrointestinalDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("StomachUlcerOfPepticUlcer", objEntity.StomachUlcerOfPepticUlcer, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("UlcerativeColitis", objEntity.UlcerativeColitis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("IBS", objEntity.IBS, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHGERD", objEntity.chkPMHGERD, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHGIBloodInStool", objEntity.chkPMHGIBloodInStool, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtPMHGIBloodInStool", objEntity.txtPMHGIBloodInStool, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("Hemorrhoids", objEntity.Hemorrhoids, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("HiatalHernia", objEntity.HiatalHernia, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("Hepatitis", objEntity.Hepatitis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHGIOtherGICondition", objEntity.chkPMHGIOtherGICondition, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtPMHGIOtherGICondition", objEntity.txtPMHGIOtherGICondition, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("PreviousBloodTransfusion", objEntity.PreviousBloodTransfusion, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPreviousBloodTransfusionNo", objEntity.chkPreviousBloodTransfusionNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numBloodTransfusionsAmount", objEntity.numBloodTransfusionsAmount, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("dteMostRecentBloodTransfusion", objEntity.dteMostRecentBloodTransfusion, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtMostRecentBloodTransfusionLocation", objEntity.txtMostRecentBloodTransfusionLocation, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtMostRecentBloodTransfusionApproxDate", objEntity.txtMostRecentBloodTransfusionApproxDate, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGainedLostMoreThan10lbsYes", objEntity.chkGainedLostMoreThan10lbsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGainedLostMoreThan10lbsNo", objEntity.chkGainedLostMoreThan10lbsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ExcessiveWeightGain", objEntity.ExcessiveWeightGain, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ExcessiveWeightLoss", objEntity.ExcessiveWeightLoss, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numLBSGainedLost", objEntity.numLBSGainedLost, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("rtxCommentsOnHxOfDigestiveProblems", objEntity.rtxCommentsOnHxOfDigestiveProblems, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("NoHistoryOfHeadache", objEntity.NoHistoryOfHeadache, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHeadacheLocation", objEntity.cboHeadacheLocation, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkHeadacheCharacterPulsing", objEntity.chkHeadacheCharacterPulsing, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHeadacheCharacterThrobbing", objEntity.chkHeadacheCharacterThrobbing, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHeadacheCharacterStabbing", objEntity.chkHeadacheCharacterStabbing, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHeadacheCharacterOther", objEntity.chkHeadacheCharacterOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtHeadacheCharacterOtherDescription", objEntity.txtHeadacheCharacterOtherDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numHeadacheFrequency", objEntity.numHeadacheFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHeadacheFrequencyMeasurement", objEntity.cboHeadacheFrequencyMeasurement, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numHeadacheDuration", objEntity.numHeadacheDuration, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHeadacheDurationMeasurement", objEntity.cboHeadacheDurationMeasurement, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPrecipitatingFactorTension", objEntity.chkPrecipitatingFactorTension, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPrecipitatingFactorStress", objEntity.chkPrecipitatingFactorStress, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPrecipitatingFactorOther", objEntity.chkPrecipitatingFactorOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPrecipitatingFactorOtherDescription", objEntity.txtPrecipitatingFactorOtherDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPMHHxOfHeadacheDoublevision", objEntity.chkPMHHxOfHeadacheDoublevision, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPMHHxOfHeadacheNausea", objEntity.chkPMHHxOfHeadacheNausea, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPMHHxOfHeadacheSeizures", objEntity.chkPMHHxOfHeadacheSeizures, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPMHHxOfHeadacheOther", objEntity.chkPMHHxOfHeadacheOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPMHHxOfHeadacheOtherDescription", objEntity.txtPMHHxOfHeadacheOtherDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPMHHxOfHeadacheAnalgesicsRelievePrescription", objEntity.chkPMHHxOfHeadacheAnalgesicsRelievePrescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPMHHxOfHeadacheAnalgesicsRelieveOTC", objEntity.chkPMHHxOfHeadacheAnalgesicsRelieveOTC, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPMHHxOfHeadacheAnalgesicsRelieveOther", objEntity.chkPMHHxOfHeadacheAnalgesicsRelieveOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPMHHxOfHeadacheAnalgesicsRelieveOtherDescription", objEntity.txtPMHHxOfHeadacheAnalgesicsRelieveOtherDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPMHHxOfHeadacheSeizuresGeneralized", objEntity.chkPMHHxOfHeadacheSeizuresGeneralized, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHHxOfHeadacheSeizuresPetitMal", objEntity.chkPMHHxOfHeadacheSeizuresPetitMal, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHHxOfHeadacheSeizuresOther", objEntity.chkPMHHxOfHeadacheSeizuresOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtPMHHxOfHeadacheSeizuresOtherDescription", objEntity.txtPMHHxOfHeadacheSeizuresOtherDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSeizuresInTheLast2YearsYes", objEntity.chkSeizuresInTheLast2YearsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSeizuresInTheLast2YearsNo", objEntity.chkSeizuresInTheLast2YearsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numSeizuresInTheLast2YearsFrequency", objEntity.numSeizuresInTheLast2YearsFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboSeizuresInTheLast2YearsFrequencyMeasurement", objEntity.cboSeizuresInTheLast2YearsFrequencyMeasurement, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numSeizuresInTheLast2YearsDuration", objEntity.numSeizuresInTheLast2YearsDuration, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboSeizuresInTheLast2YearsDurationMeasurement", objEntity.cboSeizuresInTheLast2YearsDurationMeasurement, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfHeadacheAssociatedWithIncontinence", objEntity.chkHxOfHeadacheAssociatedWithIncontinence, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSeizuresRelatedWithFecalIncontinence", objEntity.chkSeizuresRelatedWithFecalIncontinence, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSeizuresRelatedWithUrinaryIncontinence", objEntity.chkSeizuresRelatedWithUrinaryIncontinence, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSeizuresRelatedWithFecalAndUrinaryIncontinence", objEntity.chkSeizuresRelatedWithFecalAndUrinaryIncontinence, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPostictalStateYes", objEntity.chkPostictalStateYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPostictalStateNo", objEntity.chkPostictalStateNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("rtxHxOfHeadacheGeneral", objEntity.rtxHxOfHeadacheGeneral, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))

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
                        sqlcmd.Parameters.AddWithValue("@seq", 6);

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