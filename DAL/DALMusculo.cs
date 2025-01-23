using System;
using System.Data;
using System.Data.SqlClient;
using Cyramedx.PatientForms.Entities;
using System.Xml.Linq;

namespace Cyramedx.PatientForms.DAL
{
    public class DALMusculo : IDisposable
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

        public int SavePageasXML1(entmusculo objEntity, Guid PatientSchedulesId)
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
                   
                
                        objPatientPage.PatientFormId = Guid.Parse("F5B51B65-3259-461C-B22B-A2A70156ABC6");
                   

                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;


                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "Musculoskeletal Orthopedic Hx"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                               new XElement("Body",
                                                  

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

           new XElement("chkPMHMusculoskeletalJointLumbar", objEntity.chkPMHMusculoskeletalJointLumbar, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
               new XElement("cboPMHMusculoskeletalJointLumbarSurgery", objEntity.cboPMHMusculoskeletalJointLumbarSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
               new XElement("chkPMHMusculoskeletalJointLumbarMostSevere", objEntity.chkPMHMusculoskeletalJointLumbarMostSevere, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
               new XElement("txtPMHMusculoskeletalJointLumbar", objEntity.txtPMHMusculoskeletalJointLumbar, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

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

           new XElement("rtxCommentsOnHxOfMusculoskeletalProblems", objEntity.rtxCommentsOnHxOfMusculoskeletalProblems, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))


                     )));
                    objPatientPage.PageXmlData = doc.ToString();
                }
                sqlcon = new SqlConnection(DBContext.GetConnectionString());

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
                        sqlcmd.Parameters.AddWithValue("@ModifiedBy", objPatientPage.ModifiedBy);
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
                        sqlcmd.Parameters.AddWithValue("@CreatedBy", objPatientPage.CreatedBy);
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
