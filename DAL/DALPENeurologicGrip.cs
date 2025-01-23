using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALPENeurologicGrip
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

        public int UpdatePEVitalGrammerText(Guid PatientScheduleId, Guid PatientFormId, string grammertext)
        {
            try
            {
                Common objCommon = new Common();
                int _successfulupdate = objCommon.UpdatePEVitalGrammerText(PatientScheduleId, PatientFormId, grammertext);

                return _successfulupdate;
            }
            catch
            {
                return 0;
            }
        }

        public int InsertPEVitalNewGrammerText(Guid PatientScheduleId, Guid PatientFormId, string GrammerText)
        {
            try
            {
                Common objCommon = new Common();
                int _successfulupdate = objCommon.InsertPEVitalNewGrammerText(PatientScheduleId, PatientFormId, GrammerText);

                return _successfulupdate;
            }
            catch
            {
                return 0;
            }
        }

        public void UpdateGender(string personid, string gender, string SSN, bool update)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                String strSql = string.Empty;
                if (update)
                    strSql = string.Format("update dbo.Persons set Gender='{0}',SSN='{2}' where uid='{1}'", gender, personid, SSN);
                else
                    strSql = string.Format("update dbo.Persons set Gender='{0}' where uid='{1}'", gender, personid);
                // strSql = string.Format("update dbo.Persons set Gender='{0}' where uid='{1}'", gender, personid, SSN);
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



        public int SavePageasXML(entPENeurologicGrip objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("436F9D61-48E8-41EC-AEB7-0513C4C88984");
                    }

                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("703A247F-D542-4A77-B673-FDAA6B9F8ECA");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("57868EA0-B53C-41C9-9761-B50B8F8AF746");
                    }

                    //  objPatientPage.PatientFormId = Guid.Parse("5C26A971-76EE-4BC9-9EF9-EE1C7BA28A90");
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "MA Form"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
new XElement("chkMentationNormal", objEntity.chkMentationNormal, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
               new XElement("chkMentationAbnormal", objEntity.chkMentationAbnormal, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
               new XElement("txtMentationExplanation", objEntity.txtMentationExplanation, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


new XElement("chkMotorGoodForAllExtremitiesYes", objEntity.chkMotorGoodForAllExtremitiesYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkMotorGoodForAllExtremitiesNo", objEntity.chkMotorGoodForAllExtremitiesNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
               new XElement("txtMotorGoodForAllExtremities", objEntity.txtMotorGoodForAllExtremities, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


                new XElement("cboPENeuroMotorStrength1", objEntity.cboPENeuroMotorStrength1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboPENeuroMotorStrength2", objEntity.cboPENeuroMotorStrength2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboPENeuroMotorStrength3", objEntity.cboPENeuroMotorStrength3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboPENeuroMotorStrength4", objEntity.cboPENeuroMotorStrength4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


                new XElement("txtPENeuroMotorExtremityComments1", objEntity.txtPENeuroMotorExtremityComments1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtPENeuroMotorExtremityComments2", objEntity.txtPENeuroMotorExtremityComments2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtPENeuroMotorExtremityComments3", objEntity.txtPENeuroMotorExtremityComments3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtPENeuroMotorExtremityComments4", objEntity.txtPENeuroMotorExtremityComments4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


                new XElement("chkMuscularatrophyYes", objEntity.chkMuscularatrophyYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkMuscularatrophyNo", objEntity.chkMuscularatrophyNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


                new XElement("txtPENeuroMotorSpecifyLimb", objEntity.txtPENeuroMotorSpecifyLimb, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtCircumferentialMeasurementRight", objEntity.txtCircumferentialMeasurementRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtCircumferentialMeasurementLeft", objEntity.txtCircumferentialMeasurementLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkSensoryWasIntactToPinAndTouchYes", objEntity.chkSensoryWasIntactToPinAndTouchYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkSensoryWasIntactToPinAndTouchNo", objEntity.chkSensoryWasIntactToPinAndTouchNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtSensoryWasIntactToPinAndTouch", objEntity.txtSensoryWasIntactToPinAndTouch, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkSensoryCerebellarNormalYes", objEntity.chkSensoryCerebellarNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkSensoryCerebellarNormalNo", objEntity.chkSensoryCerebellarNormalNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


                new XElement("chkSensoryRhombergNormalYes", objEntity.chkSensoryRhombergNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkSensoryRhombergNormalNo", objEntity.chkSensoryRhombergNormalNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtSensoryRhombergNormal", objEntity.txtSensoryRhombergNormal, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkSensoryFingerToNoseYes", objEntity.chkSensoryFingerToNoseYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkSensoryFingerToNoseNo", objEntity.chkSensoryFingerToNoseNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboFingerToNoseSide", objEntity.cboFingerToNoseSide, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtSensoryFingerToNose", objEntity.txtSensoryFingerToNose, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkSensoryHeelToShinYes", objEntity.chkSensoryHeelToShinYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkSensoryHeelToShinNo", objEntity.chkSensoryHeelToShinNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboHeelToShinSide", objEntity.cboHeelToShinSide, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtCranialNerves", objEntity.txtCranialNerves, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkCranialNervesIIToXIIintactYes", objEntity.chkCranialNervesIIToXIIintactYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkCranialNervesIIToXIIintactNo", objEntity.chkCranialNervesIIToXIIintactNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkOpticIIYes", objEntity.chkOpticIIYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkOculomotorIIINo", objEntity.chkOculomotorIIINo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkAuditoryvestibulocochlearVIIIYes", objEntity.chkAuditoryvestibulocochlearVIIIYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkAuditoryvestibulocochlearVIIINo", objEntity.chkAuditoryvestibulocochlearVIIINo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkOculomotorIIIYes", objEntity.chkOculomotorIIIYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkOpticIINo", objEntity.chkOpticIINo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkGlossopharyngealIXYes", objEntity.chkGlossopharyngealIXYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                //new XElement("chkAuditoryvestibulocochlearVIIINo", objEntity.chkAuditoryvestibulocochlearVIIINo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkTrochlearIVYes", objEntity.chkTrochlearIVYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkTrochlearIVNo", objEntity.chkTrochlearIVNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkVagusXYes", objEntity.chkVagusXYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkVagusXNo", objEntity.chkVagusXNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkTrigeminalVYes", objEntity.chkTrigeminalVYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkTrigeminalVNo", objEntity.chkTrigeminalVNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkSpinalAccessoryXIYes", objEntity.chkSpinalAccessoryXIYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkSpinalAccessoryXINo", objEntity.chkSpinalAccessoryXINo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkAbducensVIYes", objEntity.chkAbducensVIYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkAbducensVINo", objEntity.chkAbducensVINo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkHypoglossalXIIYes", objEntity.chkHypoglossalXIIYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkHypoglossalXIINo", objEntity.chkHypoglossalXIINo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("chkFacialVIIYes", objEntity.chkFacialVIIYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkFacialVIINo", objEntity.chkFacialVIINo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkReflexesAll2Plus", objEntity.chkReflexesAll2Plus, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("cboReflexesRightBicep", objEntity.cboReflexesRightBicep, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboReflexesLeftBicep", objEntity.cboReflexesLeftBicep, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtReflexesBicepComments", objEntity.txtReflexesBicepComments, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("cboReflexesRightTricep", objEntity.cboReflexesRightTricep, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboReflexesLeftTricep", objEntity.cboReflexesLeftTricep, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtReflexesTricepComments", objEntity.txtReflexesTricepComments, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                new XElement("cboReflexesRightAchilles", objEntity.cboReflexesRightAchilles, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboReflexesLeftAchilles", objEntity.cboReflexesLeftAchilles, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtReflexesAchillesComments", objEntity.txtReflexesAchillesComments, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("rtxSensoryNotes", objEntity.rtxSensoryNotes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtCranialNervesNotes", objEntity.txtCranialNervesNotes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtReflexesPatellaComments", objEntity.txtReflexesPatellaComments, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboReflexesLeftPatella", objEntity.cboReflexesLeftPatella, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboReflexesRightPatella", objEntity.cboReflexesRightPatella, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtCerebellarNotes", objEntity.txtCerebellarNotes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chktemp", objEntity.chktemp, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                //new XElement("cboReflexesRightTricep", objEntity.cboReflexesRightTricep, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                //grip form controls
                new XElement("chkRightNormalYes", objEntity.chkRightNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightNormalNo", objEntity.chkRightNormalNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboRightNormalGrade", objEntity.cboRightNormalGrade, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkDifficultyWithManipulativeSkillsRightYes", objEntity.chkDifficultyWithManipulativeSkillsRightYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkDifficultyWithManipulativeSkillsRightNo", objEntity.chkDifficultyWithManipulativeSkillsRightNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtRightHadDifficultyWithManipulativeSkills", objEntity.txtRightHadDifficultyWithManipulativeSkills, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightClaimantHadDifficultyButtoningYes", objEntity.chkRightClaimantHadDifficultyButtoningYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightClaimantHadDifficultyButtoningNo", objEntity.chkRightClaimantHadDifficultyButtoningNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("numRightClaimantHadDifficultyButtoning", objEntity.numRightClaimantHadDifficultyButtoning, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightClaimantHadDifficultyZippingYes", objEntity.chkRightClaimantHadDifficultyZippingYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightClaimantHadDifficultyZippingNo", objEntity.chkRightClaimantHadDifficultyZippingNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("numRightClaimantHadDifficultyZipping", objEntity.numRightClaimantHadDifficultyZipping, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightClaimantHadDifficultyPickingUpCoinYes", objEntity.chkRightClaimantHadDifficultyPickingUpCoinYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightClaimantHadDifficultyPickingUpCoinNo", objEntity.chkRightClaimantHadDifficultyPickingUpCoinNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("numRightClaimantHadDifficultyPickingUpCoin", objEntity.numRightClaimantHadDifficultyPickingUpCoin, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightClaimantHadDifficultyTyingShoeLacsYes", objEntity.chkRightClaimantHadDifficultyTyingShoeLacsYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightClaimantHadDifficultyTyingShoeLacsNo", objEntity.chkRightClaimantHadDifficultyTyingShoeLacsNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("numRightClaimantHadDifficultyTyingShoeLacs", objEntity.numRightClaimantHadDifficultyTyingShoeLacs, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkLeftNormalYes", objEntity.chkLeftNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkLeftNormalNo", objEntity.chkLeftNormalNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("cboLeftNormalGrade", objEntity.cboLeftNormalGrade, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkDifficultyWithManipulativeSkillsLeftYes", objEntity.chkDifficultyWithManipulativeSkillsLeftYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkDifficultyWithManipulativeSkillsLeftNo", objEntity.chkDifficultyWithManipulativeSkillsLeftNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("txtLeftHadDifficultyWithManipulativeSkills", objEntity.txtLeftHadDifficultyWithManipulativeSkills, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkLeftClaimantHadDifficultyButtoningYes", objEntity.chkLeftClaimantHadDifficultyButtoningYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkLeftClaimantHadDifficultyButtoningNo", objEntity.chkLeftClaimantHadDifficultyButtoningNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("numLeftClaimantHadDifficultyButtoning", objEntity.numLeftClaimantHadDifficultyButtoning, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkLeftClaimantHadDifficultyZippingYes", objEntity.chkLeftClaimantHadDifficultyZippingYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkLeftClaimantHadDifficultyZippingNo", objEntity.chkLeftClaimantHadDifficultyZippingNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("numLeftClaimantHadDifficultyZipping", objEntity.numLeftClaimantHadDifficultyZipping, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkLeftClaimantHadDifficultyPickingUpCoinYes", objEntity.chkLeftClaimantHadDifficultyPickingUpCoinYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkLeftClaimantHadDifficultyPickingUpCoinNo", objEntity.chkLeftClaimantHadDifficultyPickingUpCoinNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("numLeftClaimantHadDifficultyPickingUpCoin", objEntity.numLeftClaimantHadDifficultyPickingUpCoin, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkLeftClaimantHadDifficultyTyingShoeLacsYes", objEntity.chkLeftClaimantHadDifficultyTyingShoeLacsYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkLeftClaimantHadDifficultyTyingShoeLacsNo", objEntity.chkLeftClaimantHadDifficultyTyingShoeLacsNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("numLeftClaimantHadDifficultyTyingShoeLacsNo", objEntity.numLeftClaimantHadDifficultyTyingShoeLacsNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightNormalNA", objEntity.chkLeftClaimantHadDifficultyTyingShoeLacsNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkRightClaimantHadDifficultyButtoningNA", objEntity.chkRightClaimantHadDifficultyButtoningNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkRightClaimantHadDifficultyZippingNA", objEntity.chkRightClaimantHadDifficultyZippingNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkRightClaimantHadDifficultyPickingUpCoinNA", objEntity.chkRightClaimantHadDifficultyPickingUpCoinNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkRightClaimantHadDifficultyTyingShoeLacsNA", objEntity.chkRightClaimantHadDifficultyTyingShoeLacsNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkLeftNormalNA", objEntity.chkLeftNormalNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkLeftClaimantHadDifficultyButtoningNA", objEntity.chkLeftClaimantHadDifficultyButtoningNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkLeftClaimantHadDifficultyZippingNA", objEntity.chkLeftClaimantHadDifficultyZippingNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkLeftClaimantHadDifficultyPickingUpCoinNA", objEntity.chkLeftClaimantHadDifficultyPickingUpCoinNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkLeftClaimantHadDifficultyTyingShoeLacsNA", objEntity.chkLeftClaimantHadDifficultyTyingShoeLacsNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("rtxGripNotes", objEntity.rtxGripNotes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                new XElement("chkRightPinchYes", objEntity.chkRightPinchYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkRightPinchNo", objEntity.chkRightPinchNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("txtRightHandPinch", objEntity.txtRightHandPinch, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("chkLeftPinchYes", objEntity.chkLeftPinchYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkLeftPinchNo", objEntity.chkLeftPinchNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("txtLeftHandPinch", objEntity.txtLeftHandPinch, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))
                
                )));
                    objPatientPage.PageXmlData = doc.ToString();
                }

                sqlcon = new SqlConnection(DBContext.GetConnectionString());

                if (objPatientPage != null)
                {

                    //if (!String.IsNullOrEmpty(objEntity.Gender))
                    //UpdateGender(objEntity.PersonId, objEntity.Gender, objEntity.SSN, objEntity.updateSSN);

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
                        //sqlcmd.Parameters.AddWithValue("@seq", 16);
                        if (objPatientPage.PatientFormId == Guid.Parse("436F9D61-48E8-41EC-AEB7-0513C4C88984"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 16);
                        }
                        else if (objPatientPage.PatientFormId == Guid.Parse("703A247F-D542-4A77-B673-FDAA6B9F8ECA"))
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
            catch
            {

            }
            return 1;
        }



    }
}
