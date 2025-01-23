using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
   public class DALPEHEENT:IDisposable
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

        public int SavePageasXML(entPEHEENT objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("73CF3408-2882-445E-82BA-82A82A05F97D");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("05B0DE42-11A9-41D4-BF9A-7B4FA8B472A6");
                    }



                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "PE - HEENT"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",

                    new XElement("chkMouthTeethGood", objEntity.chkMouthTeethGood, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkMouthTeethPoor", objEntity.chkMouthTeethPoor, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkMouthTeethEdentulous", objEntity.chkMouthTeethEdentulous, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtMouthTeeth", objEntity.txtMouthTeeth, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("chkNoseNormal", objEntity.chkNoseNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkNoseAbnormal", objEntity.chkNoseAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtNose", objEntity.txtNose, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("chkThroatNormal", objEntity.chkThroatNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkThroatAbnormal", objEntity.chkThroatAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtThroat", objEntity.txtThroat, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("chkEarsNormal", objEntity.chkEarsNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkEarsAbnormal", objEntity.chkEarsAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtEars", objEntity.txtEars, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    



                    new XElement("chkEyesPupilsAreNormal", objEntity.chkEyesPupilsAreNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkEyesPupilsAreAbnormal", objEntity.chkEyesPupilsAreAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkEyesPupilsAreNormalYes", objEntity.chkEyesPupilsAreNormalYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtEyesPupilsAreAbnormalComments", objEntity.txtEyesPupilsAreAbnormalComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("rtxCommentsOnPupils", objEntity.rtxCommentsOnPupils, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkIcterusWasNotedYes", objEntity.chkIcterusWasNotedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkIcterusWasNotedNo", objEntity.chkIcterusWasNotedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtIcterusWasNoted", objEntity.txtIcterusWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkStrabismusWasNotedYes", objEntity.chkStrabismusWasNotedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkStrabismusWasNotedNo", objEntity.chkStrabismusWasNotedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtStrabismusWasNoted", objEntity.txtStrabismusWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkHorizontalNystagmusWasNotedYes", objEntity.chkHorizontalNystagmusWasNotedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkHorizontalNystagmusWasNotedNo", objEntity.chkHorizontalNystagmusWasNotedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtHorizontalNystagmusWasNoted", objEntity.txtHorizontalNystagmusWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkCataractsWasNotedYes", objEntity.chkCataractsWasNotedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkCataractsWasNotedNo", objEntity.chkCataractsWasNotedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("cboCataractsWasNotedEye", objEntity.cboCataractsWasNotedEye, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtCataractsWasNoted", objEntity.txtCataractsWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkArcusSenilisWasNotedYes", objEntity.chkArcusSenilisWasNotedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkArcusSenilisWasNotedNo", objEntity.chkArcusSenilisWasNotedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtArcusSenilisWasNoted", objEntity.txtArcusSenilisWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkUsesGlassesYes", objEntity.chkUsesGlassesYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkUsesGlassesNo", objEntity.chkUsesGlassesNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtUsesGlassesDescription", objEntity.txtUsesGlassesDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("cboSnellenChartTestRight1", objEntity.cboSnellenChartTestRight1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkSnellenChartTestRightWithGlasses", objEntity.chkSnellenChartTestRightWithGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkSnellenChartTestRightWithoutGlasses", objEntity.chkSnellenChartTestRightWithoutGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("txtSnellanODComments", objEntity.txtSnellanODComments, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                    new XElement("cboSnellenChartTestLeft1", objEntity.cboSnellenChartTestLeft1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkSnellenChartTestLeftWithGlasses", objEntity.chkSnellenChartTestLeftWithGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("chkSnellenChartTestLeftWithoutGlasses", objEntity.chkSnellenChartTestLeftWithoutGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                    new XElement("txtSnellanOSComments", objEntity.txtSnellanOSComments, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                    new XElement("chkVisualFieldsNormal", objEntity.chkVisualFieldsNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkVisualFieldsAbnormal", objEntity.chkVisualFieldsAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtVisualFieldsDescription", objEntity.txtVisualFieldsDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkVisionWasGrosslyNormal", objEntity.chkVisionWasGrosslyNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkVisionWasGrosslyAbnormal", objEntity.chkVisionWasGrosslyAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtVisualFieldsDescription1", objEntity.txtVisualFieldsDescription1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                        new XElement("cboVisitSightClaimantCouldReadFingers", objEntity.cboVisitSightClaimantCouldReadFingers, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("cboVisitSightClaimantCouldReadFingersAtFeet", objEntity.cboVisitSightClaimantCouldReadFingersAtFeet, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkVisitSightCouldReadOD", objEntity.chkVisitSightCouldReadOD, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkVisitSightCouldReadOS", objEntity.chkVisitSightCouldReadOS, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkVisitSightCouldReadOU", objEntity.chkVisitSightCouldReadOU, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("cboVisitSightClaimantCouldNotReadFingers", objEntity.cboVisitSightClaimantCouldNotReadFingers, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("cboVisitSightClaimantCouldNotReadFingersAtFeet", objEntity.cboVisitSightClaimantCouldNotReadFingersAtFeet, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkVisitSightCouldNotReadOD", objEntity.chkVisitSightCouldNotReadOD, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkVisitSightCouldNotReadOS", objEntity.chkVisitSightCouldNotReadOS, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkVisitSightCouldNotReadOU", objEntity.chkVisitSightCouldNotReadOU, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkClaimantHadDifficultyReadingLabels", objEntity.chkClaimantHadDifficultyReadingLabels, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkClaimantHasDifficultyManeuveringInTheClinic", objEntity.chkClaimantHasDifficultyManeuveringInTheClinic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkFundiscopicExamNormal", objEntity.chkFundiscopicExamNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkFundiscopicExamAbnormal", objEntity.chkFundiscopicExamAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkFundiscopicExamRevealedRetinalChanges", objEntity.chkFundiscopicExamRevealedRetinalChanges, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkFundiscopicExamRevealedRetinalHemorrhages", objEntity.chkFundiscopicExamRevealedRetinalHemorrhages, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkFundiscopicExamRevealedNarrowingOfArterioles", objEntity.chkFundiscopicExamRevealedNarrowingOfArterioles, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkFundiscopicExamOther", objEntity.chkFundiscopicExamOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtFundiscopicExamOtherDescription", objEntity.txtFundiscopicExamOtherDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("cboFundusCouldNotBeVisualized", objEntity.cboFundusCouldNotBeVisualized, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                        new XElement("chkNeckWasSuppleWithoutNodesOrMassesNormal", objEntity.chkNeckWasSuppleWithoutNodesOrMassesNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkNeckWasSuppleWithoutNodesOrMassesAbnormal", objEntity.chkNeckWasSuppleWithoutNodesOrMassesAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


new XElement("chkPinHoleEyeTest", objEntity.chkPinHoleEyeTest, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("cboPinHoleEyeTestLeft", objEntity.cboPinHoleEyeTestLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("cboPinHoleEyeTestRight", objEntity.cboPinHoleEyeTestRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),



                    new XElement("chkFacialDysmorphiaYes", objEntity.chkFacialDysmorphiaYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkFacialDysmorphiaNo", objEntity.chkFacialDysmorphiaNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtFacialDysmorphia", objEntity.txtFacialDysmorphia, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("chkSkeletalAbnormalityYes", objEntity.chkSkeletalAbnormalityYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkSkeletalAbnormalityNo", objEntity.chkSkeletalAbnormalityNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtSkeletalAbnormality", objEntity.txtSkeletalAbnormality, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                     new XElement("chkVisionSight", objEntity.chkVisionSight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkTrackObjectsYes", objEntity.chkTrackObjectsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkTrackObjectsNo", objEntity.chkTrackObjectsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                     new XElement("chkTrackObjectsNA", objEntity.chkTrackObjectsNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("txtTrackObjects", objEntity.txtTrackObjects, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("chkUsesGlassesNA", objEntity.chkUsesGlassesNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("chkRedLightReflexYes", objEntity.chkRedLightReflexYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRedLightReflexYesOD", objEntity.chkRedLightReflexYesOD, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRedLightReflexYesOS", objEntity.chkRedLightReflexYesOS, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRedLightReflexYesOU", objEntity.chkRedLightReflexYesOU, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("chkRedLightReflexNo", objEntity.chkRedLightReflexNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRedLightReflexNoOD", objEntity.chkRedLightReflexNoOD, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRedLightReflexNoOS", objEntity.chkRedLightReflexNoOS, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkRedLightReflexNoOU", objEntity.chkRedLightReflexNoOU, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                    new XElement("rtxCommentsOnRevealedRetinalChanges", objEntity.rtxCommentsOnRevealedRetinalChanges, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)), 
                    new XElement("txtNeckWasSuppleWithoutNodesOrMasses", objEntity.txtNeckWasSuppleWithoutNodesOrMasses, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                    new XElement("chkSnellenchartNA", objEntity.chkSnellenchartNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER))
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
                        sqlcmd.Parameters.AddWithValue("@seq", 12);

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
