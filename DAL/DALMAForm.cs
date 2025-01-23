using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALMAForm : IDisposable
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

        public int UpdateAllegationGrammerText(Guid PatientScheduleId, Guid PatientFormId, string grammertext)
        {
            try
            {
                Common objCommon = new Common();
                int _successfullanguagespokenupdate = objCommon.UpdateAllegationGrammerText(PatientScheduleId, PatientFormId, grammertext);

                return _successfullanguagespokenupdate;
            }
            catch
            {
                return 0;
            }
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
         public int InsertAllegationNewGrammerText(Guid PatientScheduleId, Guid PatientFormId, string GrammerText)
         {
             try
             {
                 Common objCommon = new Common();
                 int _successfulupdate = objCommon.InsertAllegationNewGrammerText(PatientScheduleId, PatientFormId, GrammerText);

                 return _successfulupdate;
             }
             catch
             {
                 return 0;
             }
         }
        
        public void UpdateGender(string personid, string gender,string SSN,bool update)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                String strSql = string.Empty;
                if(update)
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



        public int SavePageasXML(entMAForm objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("5C26A971-76EE-4BC9-9EF9-EE1C7BA28A90");
                    }
                        
                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("164218BE-8D80-442C-9C2D-8D2FBB6CF485");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("8B11D94B-7DBA-486D-B742-076C52ABBDF4");
                    }

                  //  objPatientPage.PatientFormId = Guid.Parse("5C26A971-76EE-4BC9-9EF9-EE1C7BA28A90");
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "MA Form"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
new XElement("ddlLanguageSpoken", objEntity.ddlLanguageSpoken, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkSpanishInterpreterUsedYes", objEntity.chkSpanishInterpreterUsedYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkSpanishInterpreterUsedNo", objEntity.chkSpanishInterpreterUsedNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkOtherInterpreterUsedYes", objEntity.chkOtherInterpreterUsedYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkOtherInterpreterUsedNo", objEntity.chkOtherInterpreterUsedNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("txtLanguageOther", objEntity.txtLanguageOther, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),                   

new XElement("Height", objEntity.Height, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("lblBMI", objEntity.lblBMI, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("Weight", objEntity.Weight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkBloodPressureTakenWithRegularArmCuff", objEntity.chkBloodPressureTakenWithRegularArmCuff, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkBloodPressureTakenWithRegularThighCuff", objEntity.chkBloodPressureTakenWithRegularThighCuff, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("BPDiastolic", objEntity.BPDiastolic, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("BPSystolic", objEntity.BPSystolic, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("PulseRate", objEntity.PulseRate, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("RespiratoryRate", objEntity.RespiratoryRate, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("PulseOx", objEntity.PulseOx, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("cboSnellenChartTestRight1", objEntity.cboSnellenChartTestRight1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkSnellenChartTestRightWithGlasses", objEntity.chkSnellenChartTestRightWithGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkSnellenChartTestRightWithoutGlasses", objEntity.chkSnellenChartTestRightWithoutGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("txtSnellanODComments", objEntity.txtSnellanODComments, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

new XElement("cboSnellenChartTestLeft1", objEntity.cboSnellenChartTestLeft1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkSnellenChartTestLeftWithGlasses", objEntity.chkSnellenChartTestLeftWithGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkSnellenChartTestLeftWithoutGlasses", objEntity.chkSnellenChartTestLeftWithoutGlasses, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("txtSnellanOSComments", objEntity.txtSnellanOSComments, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

new XElement("chkPinHoleEyeTest", objEntity.chkPinHoleEyeTest, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("cboPinHoleEyeTestLeft", objEntity.cboPinHoleEyeTestLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("cboPinHoleEyeTestRight", objEntity.cboPinHoleEyeTestRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


new XElement("txtPrimaryCarePhysician", objEntity.txtPrimaryCarePhysician, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtTreatingPhysician", objEntity.txtTreatingPhysician, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("chkMedications", objEntity.chkMedications, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication1", objEntity.txtMedication1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage1", objEntity.txtDosage1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency1", objEntity.txtFrequency1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments1", objEntity.txtComments1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication2", objEntity.txtMedication2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage2", objEntity.txtDosage2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency2", objEntity.txtFrequency2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments2", objEntity.txtComments2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication3", objEntity.txtMedication3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage3", objEntity.txtDosage3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency3", objEntity.txtFrequency3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments3", objEntity.txtComments3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication4", objEntity.txtMedication4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage4", objEntity.txtDosage4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency4", objEntity.txtFrequency4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments4", objEntity.txtComments4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication5", objEntity.txtMedication5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage5", objEntity.txtDosage5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency5", objEntity.txtFrequency5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments5", objEntity.txtComments5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication6", objEntity.txtMedication6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage6", objEntity.txtDosage6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency6", objEntity.txtFrequency6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments6", objEntity.txtComments6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication7", objEntity.txtMedication7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage7", objEntity.txtDosage7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency7", objEntity.txtFrequency7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments7", objEntity.txtComments7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication8", objEntity.txtMedication8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage8", objEntity.txtDosage8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency8", objEntity.txtFrequency8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments8", objEntity.txtComments8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication9", objEntity.txtMedication9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage9", objEntity.txtDosage9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency9", objEntity.txtFrequency9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments9", objEntity.txtComments9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication10", objEntity.txtMedication10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage10", objEntity.txtDosage10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency10", objEntity.txtFrequency10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments10", objEntity.txtComments10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication11", objEntity.txtMedication11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage11", objEntity.txtDosage11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency11", objEntity.txtFrequency11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments11", objEntity.txtComments11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication12", objEntity.txtMedication12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage12", objEntity.txtDosage12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency12", objEntity.txtFrequency12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments12", objEntity.txtComments12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication13", objEntity.txtMedication13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage13", objEntity.txtDosage13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency13", objEntity.txtFrequency13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments13", objEntity.txtComments13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication14", objEntity.txtMedication14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage14", objEntity.txtDosage14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency14", objEntity.txtFrequency14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments14", objEntity.txtComments14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication15", objEntity.txtMedication15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage15", objEntity.txtDosage15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency15", objEntity.txtFrequency15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments15", objEntity.txtComments15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication16", objEntity.txtMedication16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage16", objEntity.txtDosage16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency16", objEntity.txtFrequency16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments16", objEntity.txtComments16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication17", objEntity.txtMedication17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage17", objEntity.txtDosage17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency17", objEntity.txtFrequency17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments17", objEntity.txtComments17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication18", objEntity.txtMedication18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage18", objEntity.txtDosage18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency18", objEntity.txtFrequency18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments18", objEntity.txtComments18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication19", objEntity.txtMedication19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage19", objEntity.txtDosage19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency19", objEntity.txtFrequency19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments19", objEntity.txtComments19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtMedication20", objEntity.txtMedication20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtDosage20", objEntity.txtDosage20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtFrequency20", objEntity.txtFrequency20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtComments20", objEntity.txtComments20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("chkNoAllergies", objEntity.chkNoAllergies, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes1", objEntity.cboTypes1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance1", objEntity.txtSubstance1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments1", objEntity.txtAllergyComments1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes2", objEntity.cboTypes2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance2", objEntity.txtSubstance2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments2", objEntity.txtAllergyComments2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes3", objEntity.cboTypes3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance3", objEntity.txtSubstance3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments3", objEntity.txtAllergyComments3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes4", objEntity.cboTypes4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance4", objEntity.txtSubstance4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments4", objEntity.txtAllergyComments4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes5", objEntity.cboTypes5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance5", objEntity.txtSubstance5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments5", objEntity.txtAllergyComments5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes6", objEntity.cboTypes6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance6", objEntity.txtSubstance6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments6", objEntity.txtAllergyComments6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes7", objEntity.cboTypes7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance7", objEntity.txtSubstance7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments7", objEntity.txtAllergyComments7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes8", objEntity.cboTypes8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance8", objEntity.txtSubstance8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments8", objEntity.txtAllergyComments8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes9", objEntity.cboTypes9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance9", objEntity.txtSubstance9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments9", objEntity.txtAllergyComments9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes10", objEntity.cboTypes10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance10", objEntity.txtSubstance10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments10", objEntity.txtAllergyComments10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes11", objEntity.cboTypes11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance11", objEntity.txtSubstance11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments11", objEntity.txtAllergyComments11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes12", objEntity.cboTypes12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance12", objEntity.txtSubstance12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments12", objEntity.txtAllergyComments12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes13", objEntity.cboTypes13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance13", objEntity.txtSubstance13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments13", objEntity.txtAllergyComments13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes14", objEntity.cboTypes14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance14", objEntity.txtSubstance14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments14", objEntity.txtAllergyComments14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes15", objEntity.cboTypes15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance15", objEntity.txtSubstance15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments15", objEntity.txtAllergyComments15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes16", objEntity.cboTypes16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance16", objEntity.txtSubstance16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments16", objEntity.txtAllergyComments16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes17", objEntity.cboTypes17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance17", objEntity.txtSubstance17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments17", objEntity.txtAllergyComments17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes18", objEntity.cboTypes18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance18", objEntity.txtSubstance18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments18", objEntity.txtAllergyComments18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes19", objEntity.cboTypes19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance19", objEntity.txtSubstance19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments19", objEntity.txtAllergyComments19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("cboTypes20", objEntity.cboTypes20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtSubstance20", objEntity.txtSubstance20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtAllergyComments20", objEntity.txtAllergyComments20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("cboIdentificationBy", objEntity.cboIdentificationBy, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("cboArrivedVia", objEntity.cboArrivedVia, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

new XElement("cboSourceOfHistory", objEntity.cboSourceOfHistory, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

new XElement("chkPedsCuff", objEntity.chkPedsCuff, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    
new XElement("txtHeadCircumference", objEntity.txtHeadCircumference, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),




new XElement("txtSourceOfHistory", objEntity.txtSourceOfHistory, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkSnellenchartNA", objEntity.chkSnellenchartNA, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER))                                                    
                    
                                                   )));
                    objPatientPage.PageXmlData = doc.ToString();
                }

                sqlcon = new SqlConnection(DBContext.GetConnectionString());

                if (objPatientPage != null)
                {

                    //if (!String.IsNullOrEmpty(objEntity.Gender))
                    UpdateGender(objEntity.PersonId, objEntity.Gender, objEntity.SSN, objEntity.updateSSN);

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
                        sqlcmd.Parameters.AddWithValue("@seq", 2);

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
