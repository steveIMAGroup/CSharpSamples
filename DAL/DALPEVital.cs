using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALPEVital : IDisposable
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


        private const string MAPTO_ACROSS_ENCOUNTER = "MapToAcrossEncounter";
        private const string DATA_INHERITANCE = "DataInheritance";
        private const string NOT_INHERITANCE = "NotInherited";

        public int SavePageasXML3(entPEVital objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("F83C6C97-9F14-4E94-AE2E-F0484C92F4B5");
                    }
                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("103D6C4D-EE94-40B3-8F34-23501BE0B6A1");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("DF9869CB-69B1-42B3-B716-9CCF757788C2");
                    }


                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "PE-Vitals-Ambulation-GAIT"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                                     new XElement("chkGACleangroomed", objEntity.chkGACleangroomed, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGAOther", objEntity.chkGAOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGAOtherComments", objEntity.txtGAOtherComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGaitAbnormalNA", objEntity.chkGaitAbnormalNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("Height", objEntity.Height, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("Weight", objEntity.Weight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("lblBMI", objEntity.lblBMI, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkBloodPressureTakenWithRegularArmCuff", objEntity.chkBloodPressureTakenWithRegularArmCuff, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkBloodPressureTakenWithRegularThighCuff", objEntity.chkBloodPressureTakenWithRegularThighCuff, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("BPDiastolic", objEntity.BPDiastolic, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("BPSystolic", objEntity.BPSystolic, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("PulseRate", objEntity.PulseRate, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("RespiratoryRate", objEntity.RespiratoryRate, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("PulseOx", objEntity.PulseOx, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                   new XElement("chkparaplegicYes", objEntity.chkparaplegicYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("chkparaplegicNo", objEntity.chkparaplegicNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtparaplegicComment", objEntity.txtparaplegicComment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("chkManeuversClaimantCanWalkOnToesYes", objEntity.chkManeuversClaimantCanWalkOnToesYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("chkManeuversClaimantCanWalkOnToesNo", objEntity.chkManeuversClaimantCanWalkOnToesNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtManeuversClaimantCanWalkOnToes", objEntity.txtManeuversClaimantCanWalkOnToes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("chkManeuversClaimantCanWalkOnHeelsYes", objEntity.chkManeuversClaimantCanWalkOnHeelsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("chkManeuversClaimantCanWalkOnHeelsNo", objEntity.chkManeuversClaimantCanWalkOnHeelsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtManeuversClaimantCanWalkOnHeels", objEntity.txtManeuversClaimantCanWalkOnHeels, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("chkManeuversClaimantCanSquatYes", objEntity.chkManeuversClaimantCanSquatYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("chkManeuversClaimantCanSquatNo", objEntity.chkManeuversClaimantCanSquatNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtManeuversClaimantCanSquat", objEntity.txtManeuversClaimantCanSquat, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("chkManeuversClaimantCanTandemHeelWalkYes", objEntity.chkManeuversClaimantCanTandemHeelWalkYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("chkManeuversClaimantCanTandemHeelWalkNo", objEntity.chkManeuversClaimantCanTandemHeelWalkNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtManeuversClaimantCanTandemHeelWalk", objEntity.txtManeuversClaimantCanTandemHeelWalk, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("chkManeuversClaimantBendOverAndTouchTheirToesYes", objEntity.chkManeuversClaimantBendOverAndTouchTheirToesYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("chkManeuversClaimantBendOverAndTouchTheirToesNo", objEntity.chkManeuversClaimantBendOverAndTouchTheirToesNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtManeuversClaimantBendOverAndTouchTheirToes", objEntity.txtManeuversClaimantBendOverAndTouchTheirToes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("ChkManueversPoor", objEntity.ChkManueversPoor, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ChkManeuversFair", objEntity.ChkManeuversFair, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ChkManeuversGood", objEntity.ChkManeuversGood, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ChkManeuversExcellent", objEntity.ChkManeuversExcellent, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtManeuversEffortComment", objEntity.txtManeuversEffortComment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtManeuversAdditionalComments", objEntity.txtManeuversAdditionalComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkAmbulatesWithoutDifficultyAndAssistiveDevice", objEntity.chkAmbulatesWithoutDifficultyAndAssistiveDevice, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAmbulatesWithDifficultyWithoutAssistiveDevice", objEntity.chkAmbulatesWithDifficultyWithoutAssistiveDevice, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAmbulatesWithDifficultyAndUsesAssistiveDevice", objEntity.chkAmbulatesWithDifficultyAndUsesAssistiveDevice, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAmbulatesWithDifficultyAssistiveDeviceRequired", objEntity.chkAmbulatesWithDifficultyAssistiveDeviceRequired, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAssistiveDeviceCane", objEntity.chkAssistiveDeviceCane, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAssistiveDeviceCrutches", objEntity.chkAssistiveDeviceCrutches, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkAssistiveDeviceWalker", objEntity.chkAssistiveDeviceWalker, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAssistiveDeviceWheelChair", objEntity.chkAssistiveDeviceWheelChair, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAssistiveDeviceOther", objEntity.chkAssistiveDeviceOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtAssistiveDeviceOther", objEntity.txtAssistiveDeviceOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    //new XElement("chkClaimantUnableToAmbulateAtAll", objEntity.chkClaimantUnableToAmbulateAtAll, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("ddlCane", objEntity.ddlCane, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ddlCrutches", objEntity.ddlCrutches, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ddlWalker", objEntity.ddlWalker, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ddlWheelChair", objEntity.ddlWheelChair, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtOther", objEntity.txtOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkClaimantCanGetUpAndOutOfChairWithoutDifficulty", objEntity.chkClaimantCanGetUpAndOutOfChairWithoutDifficulty, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantHasDifficultyGettingUpAndOutOfChair", objEntity.chkClaimantHasDifficultyGettingUpAndOutOfChair, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantNotAbleToGetUpAndOutOfChair", objEntity.chkClaimantNotAbleToGetUpAndOutOfChair, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("rtxCommentsOnAbilityToGetUpOutOfChair", objEntity.rtxCommentsOnAbilityToGetUpOutOfChair, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantAbleToGetOnAndOffExamTable", objEntity.chkClaimantAbleToGetOnAndOffExamTable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantHasDifficultyGettingOnAndOffExamTable", objEntity.chkClaimantHasDifficultyGettingOnAndOffExamTable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantNotAbleToGetOnAndOffExamTable", objEntity.chkClaimantNotAbleToGetOnAndOffExamTable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("rtxCommentsOnAbilityToOnOffExamTable", objEntity.rtxCommentsOnAbilityToOnOffExamTable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGaitNormal", objEntity.chkGaitNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGaitAbnormal", objEntity.chkGaitAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGaitChoeiform", objEntity.chkGaitChoeiform, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkGaitAntalgic", objEntity.chkGaitAntalgic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGaitDiplegic", objEntity.chkGaitDiplegic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGaitHemiplegic", objEntity.chkGaitHemiplegic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGaitChoeiform", objEntity.txtGaitChoeiform, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGaitAntalgic", objEntity.txtGaitAntalgic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGaitDiplegic", objEntity.txtGaitDiplegic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGaitHemiplegic", objEntity.txtGaitHemiplegic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGaitParkinsonian", objEntity.chkGaitParkinsonian, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGaitAppearedNeuropathic", objEntity.chkGaitAppearedNeuropathic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGaitAppearedMyopathic", objEntity.chkGaitAppearedMyopathic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGaitOther", objEntity.chkGaitOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtGaitParkinsonian", objEntity.txtGaitParkinsonian, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGaitAppearedNeuropathic", objEntity.txtGaitAppearedNeuropathic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGaitAppearedMyopathic", objEntity.txtGaitAppearedMyopathic, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGaitOtherDescription", objEntity.txtGaitOtherDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ddlgaitChoeiSeverity", objEntity.ddlgaitChoeiSeverity, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("ddlgaitParkinsonSeverity", objEntity.ddlgaitParkinsonSeverity, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ddlgaitAntalgicSeverity", objEntity.ddlgaitAntalgicSeverity, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ddlgaitNeuropathicSeverity", objEntity.ddlgaitNeuropathicSeverity, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ddlgaitDiplegicSeverity", objEntity.ddlgaitDiplegicSeverity, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ddlgaitMyopathicSeverity", objEntity.ddlgaitMyopathicSeverity, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ddlgaitHemiplegicSeverity", objEntity.ddlgaitHemiplegicSeverity, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("ddlgaitOtherSeverity", objEntity.ddlgaitOtherSeverity, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                   
                                                    new XElement("txtAmbulationVerbiage", objEntity.txtAmbulationVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtGaitVerbiage", objEntity.txtGaitVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


                                                    new XElement("chkRollOverYes", objEntity.chkRollOverYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkRollOverNo", objEntity.chkRollOverNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkRollOverNotApplicable", objEntity.chkRollOverNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtRollOver", objEntity.txtRollOver, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkSitupYes", objEntity.chkSitupYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSitupNo", objEntity.chkSitupNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSitupNotApplicable", objEntity.chkSitupNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSitup", objEntity.txtSitup, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkCrawlYes", objEntity.chkCrawlYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCrawlNo", objEntity.chkCrawlNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCrawlNotApplicable", objEntity.chkCrawlNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCrawl", objEntity.txtCrawl, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkPullupYes", objEntity.chkPullupYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPullupNo", objEntity.chkPullupNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPullupNotApplicable", objEntity.chkPullupNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPullup", objEntity.txtPullup, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkStandUnassistedYes", objEntity.chkStandUnassistedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkStandUnassistedNo", objEntity.chkStandUnassistedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkStandUnassistedNotApplicable", objEntity.chkStandUnassistedNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtStandUnassisted", objEntity.txtStandUnassisted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkWalkYes", objEntity.chkWalkYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkWalkNo", objEntity.chkWalkNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkWalkNotApplicable", objEntity.chkWalkNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtWalk", objEntity.txtWalk, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkCannotWalkYes", objEntity.chkCannotWalkYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCannotWalkNo", objEntity.chkCannotWalkNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCannotWalkNotApplicable", objEntity.chkCannotWalkNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCannotWalk", objEntity.txtCannotWalk, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("txtPercentile", objEntity.txtPercentile, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtHeadCircumference", objEntity.txtHeadCircumference, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPedsCuff", objEntity.chkPedsCuff, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),



                                                    new XElement("txtHeightPercentile", objEntity.txtHeightPercentile, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtWeightPercentile", objEntity.txtWeightPercentile, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtHeadPercentile", objEntity.txtHeadPercentile, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                   new XElement("cboSnellenChartTestRight1", objEntity.cboSnellenChartTestRight1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkSnellenChartTestRightWithGlasses", objEntity.chkSnellenChartTestRightWithGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkSnellenChartTestRightWithoutGlasses", objEntity.chkSnellenChartTestRightWithoutGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboSnellenChartTestLeft1", objEntity.cboSnellenChartTestLeft1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkSnellenChartTestLeftWithGlasses", objEntity.chkSnellenChartTestLeftWithGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkSnellenChartTestLeftWithoutGlasses", objEntity.chkSnellenChartTestLeftWithoutGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


                                                    new XElement("chkPinHoleEyeTest", objEntity.chkPinHoleEyeTest, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPinHoleEyeTestLeft", objEntity.cboPinHoleEyeTestLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPinHoleEyeTestRight", objEntity.cboPinHoleEyeTestRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("chkeffortPoor", objEntity.chkeffortPoor, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkeffortFair", objEntity.chkeffortFair, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                     new XElement("chkeffortGood", objEntity.chkeffortGood, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkeffortExcellent", objEntity.chkeffortExcellent, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txteffortComment", objEntity.txteffortComment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("rtxCommentsOnAmbulation", objEntity.rtxCommentsOnAmbulation, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))

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
                        //     sqlcmd.Parameters.AddWithValue("@seq", 10);
                        if (objPatientPage.PatientFormId == Guid.Parse("F83C6C97-9F14-4E94-AE2E-F0484C92F4B5"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 10);
                        }
                        else if (objPatientPage.PatientFormId == Guid.Parse("103D6C4D-EE94-40B3-8F34-23501BE0B6A1"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 10);
                        }
                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 7);
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
