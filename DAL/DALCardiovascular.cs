using System;
using System.Data;
using System.Data.SqlClient;
using Cyramedx.PatientForms.Entities;
using System.Xml.Linq;


namespace Cyramedx.PatientForms.DAL
{
    public class DALCardiovascular:IDisposable
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

        public int SavePageasXML3(entCardiovascular objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("7F200FBA-BF87-4494-ACC2-68FF4BADA0A2");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("33EC6A15-86C3-4534-B7AB-E6BC865F1704");
                    }
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "Hx of Cardiovascular"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",

                                                    new XElement("NoHistoryOfCardiovascularDisease", objEntity.NoHistoryOfCardiovascularDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Hypertension", objEntity.Hypertension, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("DiabetesMellitus", objEntity.DiabetesMellitus, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Angioplasty", objEntity.Angioplasty, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("CoronaryArteryBypassGraft", objEntity.CoronaryArteryBypassGraft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPMHUrinaryCatheter", objEntity.chkPMHUrinaryCatheter, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("Stroke", objEntity.Stroke, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("KidneyFailure", objEntity.KidneyFailure, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("MyocardialInfarction", objEntity.MyocardialInfarction, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("PeripheralNeuropathy", objEntity.PeripheralNeuropathy, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPMHOther", objEntity.chkPMHOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCommentOnSequel3", objEntity.txtCommentOnSequel3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAnyChestPainInTheLast6MonthsYes", objEntity.chkAnyChestPainInTheLast6MonthsYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAnyChestPainInTheLast6MonthsNo", objEntity.chkAnyChestPainInTheLast6MonthsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboRecentHistoryChestPainAnginaforMedplus", objEntity.cboRecentHistoryChestPainAnginaforMedplus, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAnyChestPainInTheLast6MonthsYesforMedplus", objEntity.chkAnyChestPainInTheLast6MonthsYesforMedplus, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkCausesChestPainExercise", objEntity.chkCausesChestPainExercise, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCausesChestPainStress", objEntity.chkCausesChestPainStress, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCausesChestPainRest", objEntity.chkCausesChestPainRest, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCausesChestPainOther", objEntity.chkCausesChestPainOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestPainSeveritySharp", objEntity.chkChestPainSeveritySharp, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestPainSeverityDull", objEntity.chkChestPainSeverityDull, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestPainSeverityAching", objEntity.chkChestPainSeverityAching, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestPainSeverityPinPrick", objEntity.chkChestPainSeverityPinPrick, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestPainSeverityBurning", objEntity.chkChestPainSeverityBurning, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestPainSeverityHeaviness", objEntity.chkChestPainSeverityHeaviness, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestPainSeverityPressure", objEntity.chkChestPainSeverityPressure, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestPainSeverityTightness", objEntity.chkChestPainSeverityTightness, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestPainSeverityOther", objEntity.chkChestPainSeverityOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLocationSternal", objEntity.chkLocationSternal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLocationLeftChest", objEntity.chkLocationLeftChest, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLocationNeck", objEntity.chkLocationNeck, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("txtNoChestPainRemarks", objEntity.txtNoChestPainRemarks, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkLocationAngleOfJaw", objEntity.chkLocationAngleOfJaw, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLocationLeftArm", objEntity.chkLocationLeftArm, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLocationOther", objEntity.chkLocationOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numChestPainAverageFrequencyAmount", objEntity.numChestPainAverageFrequencyAmount, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboChestPainAverageFrequencyType", objEntity.cboChestPainAverageFrequencyType, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtChestPainAverageDurationAmount", objEntity.txtChestPainAverageDurationAmount, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboChestPainAverageDurationType", objEntity.cboChestPainAverageDurationType, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkNitroResponseYes", objEntity.chkNitroResponseYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkNitroResponseNo", objEntity.chkNitroResponseNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboWhatRelievesChestPainWorkaround", objEntity.cboWhatRelievesChestPainWorkaround, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HeartMurmur", objEntity.HeartMurmur, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkHxOfHeartMurmurNo", objEntity.chkHxOfHeartMurmurNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtHxOfHeartMurmurNotes", objEntity.txtHxOfHeartMurmurNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkEdemaYes", objEntity.chkEdemaYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkEdemaNo", objEntity.chkEdemaNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtEdemaNotes", objEntity.txtEdemaNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numSleepOnPillowsAmount", objEntity.numSleepOnPillowsAmount, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),




                                                    new XElement("chkHTNOnRxYes", objEntity.chkHTNOnRxYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHTNOnRxNo", objEntity.chkHTNOnRxNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHTNTakesMedicineYes", objEntity.chkHTNTakesMedicineYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHTNTakesMedicineNo", objEntity.chkHTNTakesMedicineNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkDMOnRxYes", objEntity.chkDMOnRxYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkDMOnRxNo", objEntity.chkDMOnRxNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkDMTakesMedicineYes", objEntity.chkDMTakesMedicineYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkDMTakesMedicineNo", objEntity.chkDMTakesMedicineNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkEdemaFeet", objEntity.chkEdemaFeet, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkEdemaAnkles", objEntity.chkEdemaAnkles, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkEdemaOther", objEntity.chkEdemaOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),new XElement("txtPMHOtherDescription", objEntity.txtPMHOtherDescription, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numHTNNumberOfYearsDiagnosed", objEntity.numHTNNumberOfYearsDiagnosed, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCommentOnSequel1", objEntity.txtCommentOnSequel1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numDMNumberOfYearsDiagnosed", objEntity.numDMNumberOfYearsDiagnosed, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCommentOnSequel2", objEntity.txtCommentOnSequel2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCausesChestPainOtherDescription", objEntity.txtCausesChestPainOtherDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtChestPainSeverityOther", objEntity.txtChestPainSeverityOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtChestPainLocationOther", objEntity.txtChestPainLocationOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtNitroHowManyMinutes", objEntity.txtNitroHowManyMinutes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtOtherRelievesChestPainDescription", objEntity.txtOtherRelievesChestPainDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtEdemaOther", objEntity.txtEdemaOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtChestPainAverageDurationAmount", objEntity.txtChestPainAverageDurationAmount, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkTakesNitroYes", objEntity.chkTakesNitroYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkTakesNitroNo", objEntity.chkTakesNitroNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("TakesNitroMinutes", objEntity.TakesNitroMinutes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkCongenitalHeartDiseaseNo", objEntity.chkCongenitalHeartDiseaseNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCongenitalHeartDiseaseYes", objEntity.chkCongenitalHeartDiseaseYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtCongenitalHeartDisease", objEntity.txtCongenitalHeartDisease, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



                                                    //new XElement("chkGrading1", objEntity.chkGrading1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    //new XElement("chkGrading2", objEntity.chkGrading2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkGrading3", objEntity.chkGrading3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkGrading4", objEntity.chkGrading4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



                                                    new XElement("chkBrawny", objEntity.chkBrawny, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkpitting", objEntity.chkpitting, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAnyChestPainInTheLast6MonthsNA", objEntity.chkAnyChestPainInTheLast6MonthsNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("txtHistoryOfCardiovascularRemarks", objEntity.txtHistoryOfCardiovascularRemarks, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))
                                                    
                                                   )));
                    objPatientPage.PageXmlData = doc.ToString();
                }

                sqlcon = new SqlConnection(DBContext.GetConnectionString());

                if (objPatientPage != null)
                {
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
                        sqlcmd.Parameters.AddWithValue("@seq", 3);

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
