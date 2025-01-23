using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALROS : IDisposable
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

        public int SavePageasXML2(entROS objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("FB78D1AF-B4A3-474B-B8CD-B4C166363FBF");
                    }
                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("E7DBC167-14ED-4DCA-967B-1C9545CC2C79");
                    }

                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("61B54406-0870-4318-97BC-4089A84CAA1C");
                    }



                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "ROS"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                                    new XElement("chkROSGeneralNoIssues", objEntity.chkROSGeneralNoIssues, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("Fatigue", objEntity.Fatigue, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ExcessiveWeightLoss", objEntity.ExcessiveWeightLoss, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Chills", objEntity.Chills, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkROSGeneralOther", objEntity.chkROSGeneralOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtROSGeneralOther", objEntity.txtROSGeneralOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("NoHistoryOfSkinDisease", objEntity.NoHistoryOfSkinDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Psoriasis", objEntity.Psoriasis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHHxOfSkinProblemsSkinCancer", objEntity.chkPMHHxOfSkinProblemsSkinCancer, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkHxOfSkinProblemsEczema", objEntity.chkHxOfSkinProblemsEczema, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkHxOfSkinProblemsFungal", objEntity.chkHxOfSkinProblemsFungal, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkHxOfSkinProblemsOther", objEntity.chkHxOfSkinProblemsOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtHxOfSkinProblemsOtherDescription", objEntity.txtHxOfSkinProblemsOtherDescription, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("chkROSNoHxOfNeckThyroidProblems", objEntity.chkROSNoHxOfNeckThyroidProblems, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("Goiter", objEntity.Goiter, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HeentOther", objEntity.HeentOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtROSNeckThyroidOther", objEntity.txtROSNeckThyroidOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("NoHistoryOfPulmonaryDisease", objEntity.NoHistoryOfPulmonaryDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Asthma", objEntity.Asthma, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Pneumonia", objEntity.Pneumonia, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("ChronicObstructivePulmonaryDisease", objEntity.ChronicObstructivePulmonaryDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Bronchitis", objEntity.Bronchitis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Sarcoidosis", objEntity.Sarcoidosis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Tuberculosis", objEntity.Tuberculosis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Hemoptysis", objEntity.Hemoptysis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHCOPDOther", objEntity.chkPMHCOPDOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtPMHCOPDOtherDescription", objEntity.txtPMHCOPDOtherDescription, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("NoHistoryOfCardiovascularDisease", objEntity.NoHistoryOfCardiovascularDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Hypertension", objEntity.Hypertension, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("MyocardialInfarction", objEntity.MyocardialInfarction, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAnyChestPainInTheLast6MonthsYes", objEntity.chkAnyChestPainInTheLast6MonthsYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("HeartMurmur", objEntity.HeartMurmur, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("DiabetesMellitus", objEntity.DiabetesMellitus, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Stroke", objEntity.Stroke, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHOther", objEntity.chkPMHOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtPMHOtherDescription", objEntity.txtPMHOtherDescription, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("NoHistoryOfGastrointestinalDisease", objEntity.NoHistoryOfGastrointestinalDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("StomachUlcerOfPepticUlcer", objEntity.StomachUlcerOfPepticUlcer, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHGIBloodInStool", objEntity.chkPMHGIBloodInStool, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Hemorrhoids", objEntity.Hemorrhoids, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("HiatalHernia", objEntity.HiatalHernia, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("IBS", objEntity.IBS, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Hepatitis", objEntity.Hepatitis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("UlcerativeColitis", objEntity.UlcerativeColitis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHGIOtherGICondition", objEntity.chkPMHGIOtherGICondition, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtPMHGIOtherGICondition", objEntity.txtPMHGIOtherGICondition, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("chkROSNoHxOfGUProblems", objEntity.chkROSNoHxOfGUProblems, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("FrequentUTI", objEntity.FrequentUTI, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("Dysuria", objEntity.Dysuria, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("Hematuria", objEntity.Hematuria, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("Incontinence", objEntity.Incontinence, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("GenitourinaryOther", objEntity.GenitourinaryOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtROSGenitoUrinaryOther", objEntity.txtROSGenitoUrinaryOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkROSNoHxOfEndocrineProblems", objEntity.chkROSNoHxOfEndocrineProblems, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ChronicAnemia", objEntity.ChronicAnemia, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("LymphNodeEnlargementOrTenderness", objEntity.LymphNodeEnlargementOrTenderness, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("BleedingTendency", objEntity.BleedingTendency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ImmunologicLymphaticEndocrineOther", objEntity.ImmunologicLymphaticEndocrineOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtROSEndocrineOther", objEntity.txtROSEndocrineOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkROSNoHxOfNeuroProblems", objEntity.chkROSNoHxOfNeuroProblems, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("TIAs", objEntity.TIAs, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("MultipleSclerosis", objEntity.MultipleSclerosis, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("Headaches", objEntity.Headaches, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("Seizures", objEntity.Seizures, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("NeurologicPsychiatricOther", objEntity.NeurologicPsychiatricOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtROSNeurologicOther", objEntity.txtROSNeurologicOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("NoHistoryOfHeadDisease", objEntity.NoHistoryOfHeadDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Depression", objEntity.Depression, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHMentalPanicAttacks", objEntity.chkPMHMentalPanicAttacks, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Bipolar", objEntity.Bipolar, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Anxiety", objEntity.Anxiety, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPMHMentalOther", objEntity.chkPMHMentalOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtPMHMentalOther", objEntity.txtPMHMentalOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtGeneralComments", objEntity.txtGeneralComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkBehavioralProblems", objEntity.chkBehavioralProblems, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkShortAttentionSpan", objEntity.chkShortAttentionSpan, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



           new XElement("ProductiveCough", objEntity.ProductiveCough, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("chkEdemaYes", objEntity.chkEdemaYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("chkCongenitalHeartDiseaseYes", objEntity.chkCongenitalHeartDiseaseYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("chkHeadache", objEntity.chkHeadache, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
           new XElement("chkSeizures", objEntity.chkSeizures, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


           new XElement("cboHeadacheLocation", objEntity.cboHeadacheLocation, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("chkPMHHxOfHeadacheSeizuresGeneralized", objEntity.chkPMHHxOfHeadacheSeizuresGeneralized, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("chkPMHHxOfHeadacheSeizuresPetitMal", objEntity.chkPMHHxOfHeadacheSeizuresPetitMal, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("chkPMHHxOfHeadacheSeizuresOther", objEntity.chkPMHHxOfHeadacheSeizuresOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("chkPMHGERD", objEntity.chkPMHGERD, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),                                                                                        




                                                    new XElement("chkROSReviewed", objEntity.chkROSReviewed, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))
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
                       // sqlcmd.Parameters.AddWithValue("@seq", 9);


                        if (objPatientPage.PatientFormId == Guid.Parse("FB78D1AF-B4A3-474B-B8CD-B4C166363FBF"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 9);
                        }

                        else if (objPatientPage.PatientFormId == Guid.Parse("E7DBC167-14ED-4DCA-967B-1C9545CC2C79"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 9);
                        }
                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 6);
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
    

