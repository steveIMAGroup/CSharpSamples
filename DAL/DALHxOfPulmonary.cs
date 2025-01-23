using System;
using System.Data;
using System.Data.SqlClient;
using Cyramedx.PatientForms.Entities;
using System.Xml.Linq;



namespace Cyramedx.PatientForms.DAL
{
    public class DALHxOfPulmonary:IDisposable
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

        public int SavePageasXML1(entHxOfPulmonary objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("4BFE214C-0DD7-4DD1-B020-F34914665714");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("72954AA7-333A-44E5-A371-964E774CC2CF");
                    }


                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;


                     doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "Hx of Pulmonary"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                                   new XElement("NoHistoryOfPulmonaryDisease", objEntity.NoHistoryOfPulmonaryDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("ChronicObstructivePulmonaryDisease", objEntity.ChronicObstructivePulmonaryDisease, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
           new XElement("Asthma", objEntity.Asthma, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("Bronchitis", objEntity.Bronchitis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
           new XElement("Sarcoidosis", objEntity.Sarcoidosis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("Tuberculosis", objEntity.Tuberculosis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
           new XElement("Pneumonia", objEntity.Pneumonia, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("Hemoptysis", objEntity.Hemoptysis, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("ProductiveCough", objEntity.ProductiveCough, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
           new XElement("chkPMHCOPDOther", objEntity.chkPMHCOPDOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

           new XElement("txtPMHCOPDOtherDescription", objEntity.txtPMHCOPDOtherDescription, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


 new XElement("Wheezing", objEntity.Wheezing, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("WheezingAM", objEntity.WheezingAM, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("WheezingPM", objEntity.WheezingPM, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("WheezingAllTheTime", objEntity.WheezingAllTheTime, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("WheezingWorsensWithExercise", objEntity.WheezingWorsensWithExercise, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("WheezingWorsensWithDust", objEntity.WheezingWorsensWithDust, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("WheezingWorsensWithWeatherChange", objEntity.WheezingWorsensWithWeatherChange, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("WheezingWorsensStrongWithFumes", objEntity.WheezingWorsensStrongWithFumes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("WheezingWorsensWithHotColdWater", objEntity.WheezingWorsensWithHotColdWater, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
  new XElement("URI", objEntity.URI, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("WheezingWorsensWithAnimals", objEntity.WheezingWorsensWithAnimals, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("WheezingWorsensWithChangeSeasons", objEntity.WheezingWorsensWithChangeSeasons, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("chkPMHWheezingWorsensOther", objEntity.chkPMHWheezingWorsensOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHWheezingWorsensOther", objEntity.txtPMHWheezingWorsensOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("AsthmaAttackFrequencyAmount", objEntity.AsthmaAttackFrequencyAmount, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("AsthmaAttackFrequency", objEntity.AsthmaAttackFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
  new XElement("WheezingAverageDaysPerMonth", objEntity.WheezingAverageDaysPerMonth, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("AsthmaLastSevereAttack", objEntity.AsthmaLastSevereAttack, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("AsthmaTakesMedsPRN", objEntity.AsthmaTakesMedsPRN, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("AsthmaHospitalizationERVisitsThisYear", objEntity.AsthmaHospitalizationERVisitsThisYear, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("AsthmaHospitalizationERVisitsLastYear", objEntity.AsthmaHospitalizationERVisitsLastYear, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("AsthmaTakesMedsDaily", objEntity.AsthmaTakesMedsDaily, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("numPMHERVisitsThisYear", objEntity.numPMHERVisitsThisYear, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("numPMHERVisitsLastYear", objEntity.numPMHERVisitsLastYear, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("chkPMHTakesAsthmaMedsOther", objEntity.chkPMHTakesAsthmaMedsOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHTakesAsthmaMedsOther", objEntity.txtPMHTakesAsthmaMedsOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("AsthmaSchoolWorkDaysMissed", objEntity.AsthmaSchoolWorkDaysMissed, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


           new XElement("txtPMHPulmonaryHxNotes", objEntity.txtPMHPulmonaryHxNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
           new XElement("rtxCommentsOnHxOfPulmonaryDisease", objEntity.rtxCommentsOnHxOfPulmonaryDisease, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

           new XElement("NoHistoryOfMusculoskeletalDisease", objEntity.NoHistoryOfMusculoskeletalDisease, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


           new XElement("chkPMHMusculoskeletalJointShoulder", objEntity.chkPMHMusculoskeletalJointShoulder, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointShoulder", objEntity.cboPMHMusculoskeletalJointShoulder, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointShoulderSurgery", objEntity.cboPMHMusculoskeletalJointShoulderSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointShoulderMostSevere", objEntity.chkPMHMusculoskeletalJointShoulderMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointShoulder", objEntity.txtPMHMusculoskeletalJointShoulder, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHMusculoskeletalJointElbow", objEntity.chkPMHMusculoskeletalJointElbow, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointElbow", objEntity.cboPMHMusculoskeletalJointElbow, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointElbowSurgery", objEntity.cboPMHMusculoskeletalJointElbowSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointElbowMostSevere", objEntity.chkPMHMusculoskeletalJointElbowMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointElbow", objEntity.txtPMHMusculoskeletalJointElbow, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHMusculoskeletalJointWrist", objEntity.chkPMHMusculoskeletalJointWrist, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointWrist", objEntity.cboPMHMusculoskeletalJointWrist, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointWristSurgery", objEntity.cboPMHMusculoskeletalJointWristSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointWristMostSevere", objEntity.chkPMHMusculoskeletalJointWristMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointWrist", objEntity.txtPMHMusculoskeletalJointWrist, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


            new XElement("chkPMHMusculoskeletalJointHand", objEntity.chkPMHMusculoskeletalJointHand, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointHand", objEntity.cboPMHMusculoskeletalJointHand, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointHandSurgery", objEntity.cboPMHMusculoskeletalJointHandSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointHandMostSevere", objEntity.chkPMHMusculoskeletalJointHandMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointHand", objEntity.txtPMHMusculoskeletalJointHand, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHMusculoskeletalJointHip", objEntity.chkPMHMusculoskeletalJointHip, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointHip", objEntity.cboPMHMusculoskeletalJointHip, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointHipSurgery", objEntity.cboPMHMusculoskeletalJointHipSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointHipMostSevere", objEntity.chkPMHMusculoskeletalJointHipMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointHip", objEntity.txtPMHMusculoskeletalJointHip, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHMusculoskeletalJointKnee", objEntity.chkPMHMusculoskeletalJointKnee, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointKnee", objEntity.cboPMHMusculoskeletalJointKnee, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointKneeSurgery", objEntity.cboPMHMusculoskeletalJointKneeSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointKneeMostSevere", objEntity.chkPMHMusculoskeletalJointKneeMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointKnee", objEntity.txtPMHMusculoskeletalJointKnee, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHMusculoskeletalJointAnkle", objEntity.chkPMHMusculoskeletalJointAnkle, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointAnkle", objEntity.cboPMHMusculoskeletalJointAnkle, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointAnkleSurgery", objEntity.cboPMHMusculoskeletalJointAnkleSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointAnkleMostSevere", objEntity.chkPMHMusculoskeletalJointAnkleMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointAnkle", objEntity.txtPMHMusculoskeletalJointAnkle, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHMusculoskeletalJointFoot", objEntity.chkPMHMusculoskeletalJointFoot, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointFoot", objEntity.cboPMHMusculoskeletalJointFoot, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointFootSurgery", objEntity.cboPMHMusculoskeletalJointFootSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointFootMostSevere", objEntity.chkPMHMusculoskeletalJointFootMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointFoot", objEntity.txtPMHMusculoskeletalJointFoot, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHMusculoskeletalJointCervical", objEntity.chkPMHMusculoskeletalJointCervical, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointCervicalSurgery", objEntity.cboPMHMusculoskeletalJointCervicalSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointCervicalMostSevere", objEntity.chkPMHMusculoskeletalJointCervicalMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointCervical", objEntity.txtPMHMusculoskeletalJointCervical, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHMusculoskeletalJointThoracic", objEntity.chkPMHMusculoskeletalJointThoracic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointThoracicSurgery", objEntity.cboPMHMusculoskeletalJointThoracicSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointThoracicMostSevere", objEntity.chkPMHMusculoskeletalJointThoracicMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointThoracic", objEntity.txtPMHMusculoskeletalJointThoracic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHMusculoskeletalJointLumbar", objEntity.chkPMHMusculoskeletalJointLumbar, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                new XElement("cboPMHMusculoskeletalJointLumbarSurgery", objEntity.cboPMHMusculoskeletalJointLumbarSurgery, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                new XElement("chkPMHMusculoskeletalJointLumbarMostSevere", objEntity.chkPMHMusculoskeletalJointLumbarMostSevere, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                new XElement("txtPMHMusculoskeletalJointLumbar", objEntity.txtPMHMusculoskeletalJointLumbar, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

            new XElement("chkPMHMusculoskeletalJointSacral", objEntity.chkPMHMusculoskeletalJointSacral, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHMusculoskeletalJointSacralSurgery", objEntity.cboPMHMusculoskeletalJointSacralSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHMusculoskeletalJointSacralMostSevere", objEntity.chkPMHMusculoskeletalJointSacralMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("txtPMHMusculoskeletalJointSacral", objEntity.txtPMHMusculoskeletalJointSacral, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHUrinaryIncontinence", objEntity.chkPMHUrinaryIncontinence, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("numPMHUrinaryIncontinenceFrequency", objEntity.numPMHUrinaryIncontinenceFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHUrinaryIncontinenceFrequency", objEntity.cboPMHUrinaryIncontinenceFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHUrinaryIncontinenceMostSevere", objEntity.chkPMHUrinaryIncontinenceMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("chkPMHFecalIncontinence", objEntity.chkPMHFecalIncontinence, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("numPMHFecalIncontinenceFrequency", objEntity.numPMHFecalIncontinenceFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPMHFecalIncontinenceFrequency", objEntity.cboPMHFecalIncontinenceFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPMHFecalIncontinenceMostSevere", objEntity.chkPMHFecalIncontinenceMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPainNA", objEntity.chkPainNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPainNo", objEntity.chkPainNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkPainYes", objEntity.chkPainYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPainType", objEntity.cboPainType, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPainFrequency", objEntity.cboPainFrequency, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("cboPainQuality", objEntity.cboPainQuality, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                 new XElement("chkUIncYes", objEntity.chkUIncYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkUIncNo", objEntity.chkUIncNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkUIncNA", objEntity.chkUIncNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                 new XElement("chkFIncYes", objEntity.chkFIncYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkFIncNo", objEntity.chkFIncNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                new XElement("chkFIncNA", objEntity.chkFIncNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

            new XElement("rtxCommentsOnHxOfMusculoskeletalProblems", objEntity.rtxCommentsOnHxOfMusculoskeletalProblems, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)) 


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
                       sqlcmd.Parameters.AddWithValue("@seq", 4);

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


























