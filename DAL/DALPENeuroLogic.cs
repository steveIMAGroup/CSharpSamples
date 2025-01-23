using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
   public class DALPENeuroLogic:IDisposable
    {
        SqlConnection sqlcon = null;
        SqlCommand sqlcmd = null;
        DataTable dt = null;
        SqlDataAdapter sqlda = null;
        private const string MAPTO_ACROSS_ENCOUNTER = "MapToAcrossEncounter";
        private const string DATA_INHERITANCE = "DataInheritance";
        private const string NOT_INHERITANCE = "NotInherited";

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

        public int SavePageasXML1(entNeurologic objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("00E86A43-DFD9-4CE5-B22A-E26765651EA2");

                    }
                    else if (v == "p")
                    {
 objPatientPage.PatientFormId = Guid.Parse("BAF85F28-700D-4CB0-B77B-21238FC4A5F6");

                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("29F64C58-E126-45C3-B74C-396DFEDD9272");
                    }
                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "PE - Neurologic"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                                    new XElement("chkMentationNormal", objEntity.chkMentationNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkMentationAbnormal", objEntity.chkMentationAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtMentationExplanation", objEntity.txtMentationExplanation, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkMotorGoodForAllExtremitiesYes", objEntity.chkMotorGoodForAllExtremitiesYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMotorGoodForAllExtremitiesNo", objEntity.chkMotorGoodForAllExtremitiesNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtMotorGoodForAllExtremities", objEntity.txtMotorGoodForAllExtremities, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("cboPENeuroMotorExtremity1", objEntity.cboPENeuroMotorExtremity1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorExtremity2", objEntity.cboPENeuroMotorExtremity2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorExtremity3", objEntity.cboPENeuroMotorExtremity3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorExtremity4", objEntity.cboPENeuroMotorExtremity4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorExtremity5", objEntity.cboPENeuroMotorExtremity5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorExtremity6", objEntity.cboPENeuroMotorExtremity6, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorExtremity7", objEntity.cboPENeuroMotorExtremity7, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorExtremity8", objEntity.cboPENeuroMotorExtremity8, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboPENeuroMotorStrength1", objEntity.cboPENeuroMotorStrength1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength2", objEntity.cboPENeuroMotorStrength2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength3", objEntity.cboPENeuroMotorStrength3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength4", objEntity.cboPENeuroMotorStrength4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength5", objEntity.cboPENeuroMotorStrength5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength6", objEntity.cboPENeuroMotorStrength6, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength7", objEntity.cboPENeuroMotorStrength7, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength8", objEntity.cboPENeuroMotorStrength8, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboPENeuroMotorProximalDistal1", objEntity.cboPENeuroMotorProximalDistal1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal2", objEntity.cboPENeuroMotorProximalDistal2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal3", objEntity.cboPENeuroMotorProximalDistal3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal4", objEntity.cboPENeuroMotorProximalDistal4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal5", objEntity.cboPENeuroMotorProximalDistal5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal6", objEntity.cboPENeuroMotorProximalDistal6, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal7", objEntity.cboPENeuroMotorProximalDistal7, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal8", objEntity.cboPENeuroMotorProximalDistal8, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("txtPENeuroMotorExtremityComments1", objEntity.txtPENeuroMotorExtremityComments1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPENeuroMotorExtremityComments2", objEntity.txtPENeuroMotorExtremityComments2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPENeuroMotorExtremityComments3", objEntity.txtPENeuroMotorExtremityComments3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPENeuroMotorExtremityComments4", objEntity.txtPENeuroMotorExtremityComments4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPENeuroMotorExtremityComments5", objEntity.txtPENeuroMotorExtremityComments5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPENeuroMotorExtremityComments6", objEntity.txtPENeuroMotorExtremityComments6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPENeuroMotorExtremityComments7", objEntity.txtPENeuroMotorExtremityComments7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPENeuroMotorExtremityComments8", objEntity.txtPENeuroMotorExtremityComments8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("txtPENeuroMotorSpecifyLimb", objEntity.txtPENeuroMotorSpecifyLimb, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCircumferentialMeasurementRight", objEntity.txtCircumferentialMeasurementRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCircumferentialMeasurementLeft", objEntity.txtCircumferentialMeasurementLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkSensoryWasIntactToPinAndTouchYes", objEntity.chkSensoryWasIntactToPinAndTouchYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSensoryWasIntactToPinAndTouchNo", objEntity.chkSensoryWasIntactToPinAndTouchNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSensoryWasIntactToPinAndTouch", objEntity.txtSensoryWasIntactToPinAndTouch, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkSensoryCerebellarNormalYes", objEntity.chkSensoryCerebellarNormalYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSensoryCerebellarNormalNo", objEntity.chkSensoryCerebellarNormalNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCerebellarNotes", objEntity.txtCerebellarNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkSensoryRhombergNormalYes", objEntity.chkSensoryRhombergNormalYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSensoryRhombergNormalNo", objEntity.chkSensoryRhombergNormalNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSensoryRhombergNormal", objEntity.txtSensoryRhombergNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkSensoryFingerToNoseYes", objEntity.chkSensoryFingerToNoseYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSensoryFingerToNoseNo", objEntity.chkSensoryFingerToNoseNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboFingerToNoseSide", objEntity.cboFingerToNoseSide, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSensoryFingerToNose", objEntity.txtSensoryFingerToNose, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkSensoryHeelToShinYes", objEntity.chkSensoryHeelToShinYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSensoryHeelToShinNo", objEntity.chkSensoryHeelToShinNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHeelToShinSide", objEntity.cboHeelToShinSide, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCranialNerves", objEntity.txtCranialNerves, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkCranialNervesIIToXIIintactYes", objEntity.chkCranialNervesIIToXIIintactYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCranialNervesIIToXIIintactNo", objEntity.chkCranialNervesIIToXIIintactNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkOpticIIYes", objEntity.chkOpticIIYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkOculomotorIIINo", objEntity.chkOculomotorIIINo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAuditoryvestibulocochlearVIIIYes", objEntity.chkAuditoryvestibulocochlearVIIIYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAuditoryvestibulocochlearVIIINo", objEntity.chkAuditoryvestibulocochlearVIIINo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkOculomotorIIIYes", objEntity.chkOculomotorIIIYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkOpticIINo", objEntity.chkOpticIINo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGlossopharyngealIXYes", objEntity.chkGlossopharyngealIXYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGlossopharyngealIXNo", objEntity.chkGlossopharyngealIXNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkTrochlearIVYes", objEntity.chkTrochlearIVYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkTrochlearIVNo", objEntity.chkTrochlearIVNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkVagusXYes", objEntity.chkVagusXYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkVagusXNo", objEntity.chkVagusXNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkTrigeminalVYes", objEntity.chkTrigeminalVYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkTrigeminalVNo", objEntity.chkTrigeminalVNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpinalAccessoryXIYes", objEntity.chkSpinalAccessoryXIYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpinalAccessoryXINo", objEntity.chkSpinalAccessoryXINo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkAbducensVIYes", objEntity.chkAbducensVIYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbducensVINo", objEntity.chkAbducensVINo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHypoglossalXIIYes", objEntity.chkHypoglossalXIIYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHypoglossalXIINo", objEntity.chkHypoglossalXIINo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkFacialVIIYes", objEntity.chkFacialVIIYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkFacialVIINo", objEntity.chkFacialVIINo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkReflexesAll2Plus", objEntity.chkReflexesAll2Plus, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("cboReflexesRightBicep", objEntity.cboReflexesRightBicep, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboReflexesLeftBicep", objEntity.cboReflexesLeftBicep, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtReflexesBicepComments", objEntity.txtReflexesBicepComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("cboReflexesRightTricep", objEntity.cboReflexesRightTricep, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboReflexesLeftTricep", objEntity.cboReflexesLeftTricep, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtReflexesTricepComments", objEntity.txtReflexesTricepComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("cboReflexesRightAchilles", objEntity.cboReflexesRightAchilles, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboReflexesLeftAchilles", objEntity.cboReflexesLeftAchilles, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtReflexesAchillesComments", objEntity.txtReflexesAchillesComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCranialNervesNotes", objEntity.txtCranialNervesNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtReflexesPatellaComments", objEntity.txtReflexesPatellaComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboReflexesLeftPatella", objEntity.cboReflexesLeftPatella, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboReflexesRightPatella", objEntity.cboReflexesRightPatella, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chktemp", objEntity.chktemp, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



                                                    new XElement("chkMuscularatrophyYes", objEntity.chkMuscularatrophyYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkMuscularatrophyNo", objEntity.chkMuscularatrophyNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("rtxSensoryNotes", objEntity.rtxSensoryNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))
                                                   )));

                    objPatientPage.PageXmlData = doc.ToString();
                }
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                if (String.IsNullOrEmpty(objEntity.GrammerText))
                    objEntity.GrammerText = "";
                if (objPatientPage != null)
                {
                    DataSet dtIsCheck = objCommon.IsPageExist(objPatientPage.ScheduleId, objPatientPage.PatientFormId);

                    if (dtIsCheck != null && dtIsCheck.Tables.Count > 0 && dtIsCheck.Tables[0].Rows.Count > 0)
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
                //        sqlcmd.Parameters.AddWithValue("@seq", 16);
                        if (objPatientPage.PatientFormId == Guid.Parse("00E86A43-DFD9-4CE5-B22A-E26765651EA2"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 16);
                        }
                        else if (objPatientPage.PatientFormId == Guid.Parse("BAF85F28-700D-4CB0-B77B-21238FC4A5F6"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 16);
                        }
                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 10);
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
            catch (Exception)
            {

            }
            return 1;
        }

    }
}
