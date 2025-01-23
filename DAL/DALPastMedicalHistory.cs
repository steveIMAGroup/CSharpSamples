using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALPastMedicalHistory:IDisposable
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


        public int SavePageasXML1(entPastMedicalHistory objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("477CFB93-1A9A-4A36-91D6-F8B120B0486C");

                    }
                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("6CB27127-AD1D-4456-8F83-8D5AC2D75568");

                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("51F76C39-E22E-4236-B7F5-E924F19B96BA");
                    }
                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "PastMedicalHistory"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",

                                                    new XElement("chkNAPrenatal", objEntity.chkNAPrenatal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("chkPMHNoHistoryOfRecentHospitalizationERVisitsMajorSurgery", objEntity.chkPMHNoHistoryOfRecentHospitalizationERVisitsMajorSurgery, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHRecentHospitalization1", objEntity.dtePMHRecentHospitalization1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate1", objEntity.txtPMHRecentHospitalizationAlternativeDate1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName1", objEntity.txtPMHRecentHospitalizationHospName1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason1", objEntity.txtPMHRecentHospitalizationReason1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHRecentHospitalization2", objEntity.dtePMHRecentHospitalization2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate2", objEntity.txtPMHRecentHospitalizationAlternativeDate2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName2", objEntity.txtPMHRecentHospitalizationHospName2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason2", objEntity.txtPMHRecentHospitalizationReason2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHRecentHospitalization3", objEntity.dtePMHRecentHospitalization3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate3", objEntity.txtPMHRecentHospitalizationAlternativeDate3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName3", objEntity.txtPMHRecentHospitalizationHospName3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason3", objEntity.txtPMHRecentHospitalizationReason3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHRecentHospitalization4", objEntity.dtePMHRecentHospitalization4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate4", objEntity.txtPMHRecentHospitalizationAlternativeDate4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName4", objEntity.txtPMHRecentHospitalizationHospName4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason4", objEntity.txtPMHRecentHospitalizationReason4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

 new XElement("dtePMHRecentHospitalization5", objEntity.dtePMHRecentHospitalization5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate5", objEntity.txtPMHRecentHospitalizationAlternativeDate5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName5", objEntity.txtPMHRecentHospitalizationHospName5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason5", objEntity.txtPMHRecentHospitalizationReason5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

 new XElement("dtePMHRecentHospitalization6", objEntity.dtePMHRecentHospitalization6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate6", objEntity.txtPMHRecentHospitalizationAlternativeDate6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName6", objEntity.txtPMHRecentHospitalizationHospName6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason6", objEntity.txtPMHRecentHospitalizationReason6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
    new XElement("dtePMHRecentHospitalization7", objEntity.dtePMHRecentHospitalization7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate7", objEntity.txtPMHRecentHospitalizationAlternativeDate7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName7", objEntity.txtPMHRecentHospitalizationHospName7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason7", objEntity.txtPMHRecentHospitalizationReason7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

   new XElement("dtePMHRecentHospitalization8", objEntity.dtePMHRecentHospitalization8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate8", objEntity.txtPMHRecentHospitalizationAlternativeDate8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName8", objEntity.txtPMHRecentHospitalizationHospName8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason8", objEntity.txtPMHRecentHospitalizationReason8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHRecentHospitalization9", objEntity.dtePMHRecentHospitalization9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate9", objEntity.txtPMHRecentHospitalizationAlternativeDate9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName9", objEntity.txtPMHRecentHospitalizationHospName9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason9", objEntity.txtPMHRecentHospitalizationReason9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
    new XElement("dtePMHRecentHospitalization10", objEntity.dtePMHRecentHospitalization10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate10", objEntity.txtPMHRecentHospitalizationAlternativeDate10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName10", objEntity.txtPMHRecentHospitalizationHospName10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason10", objEntity.txtPMHRecentHospitalizationReason10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHRecentHospitalization11", objEntity.dtePMHRecentHospitalization11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate11", objEntity.txtPMHRecentHospitalizationAlternativeDate11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName11", objEntity.txtPMHRecentHospitalizationHospName11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason11", objEntity.txtPMHRecentHospitalizationReason11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHRecentHospitalization12", objEntity.dtePMHRecentHospitalization12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationAlternativeDate12", objEntity.txtPMHRecentHospitalizationAlternativeDate12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationHospName12", objEntity.txtPMHRecentHospitalizationHospName12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHRecentHospitalizationReason12", objEntity.txtPMHRecentHospitalizationReason12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

 new XElement("dtePMHERVisit1", objEntity.dtePMHERVisit1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospAlternativeDate1", objEntity.txtPMHERVisitHospAlternativeDate1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospName1", objEntity.txtPMHERVisitHospName1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitReason1", objEntity.txtPMHERVisitReason1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHERVisit2", objEntity.dtePMHERVisit2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospAlternativeDate2", objEntity.txtPMHERVisitHospAlternativeDate2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospName2", objEntity.txtPMHERVisitHospName2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitReason2", objEntity.txtPMHERVisitReason2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHERVisit3", objEntity.dtePMHERVisit3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospAlternativeDate3", objEntity.txtPMHERVisitHospAlternativeDate3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospName3", objEntity.txtPMHERVisitHospName3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitReason3", objEntity.txtPMHERVisitReason3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
  new XElement("dtePMHERVisit4", objEntity.dtePMHERVisit4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospAlternativeDate4", objEntity.txtPMHERVisitHospAlternativeDate4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospName4", objEntity.txtPMHERVisitHospName4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitReason4", objEntity.txtPMHERVisitReason4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
    new XElement("dtePMHERVisit5", objEntity.dtePMHERVisit5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospAlternativeDate5", objEntity.txtPMHERVisitHospAlternativeDate5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospName5", objEntity.txtPMHERVisitHospName5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitReason5", objEntity.txtPMHERVisitReason5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHERVisit6", objEntity.dtePMHERVisit6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospAlternativeDate6", objEntity.txtPMHERVisitHospAlternativeDate6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospName6", objEntity.txtPMHERVisitHospName6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitReason6", objEntity.txtPMHERVisitReason6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
    new XElement("dtePMHERVisit7", objEntity.dtePMHERVisit7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospAlternativeDate7", objEntity.txtPMHERVisitHospAlternativeDate7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitHospName7", objEntity.txtPMHERVisitHospName7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHERVisitReason7", objEntity.txtPMHERVisitReason7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHMajorSurgery1", objEntity.dtePMHMajorSurgery1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryAlternativeDate1", objEntity.txtPMHMajorSurgeryAlternativeDate1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryHospName1", objEntity.txtPMHMajorSurgeryHospName1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryType1", objEntity.txtPMHMajorSurgeryType1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHMajorSurgery2", objEntity.dtePMHMajorSurgery2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryAlternativeDate2", objEntity.txtPMHMajorSurgeryAlternativeDate2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryHospName2", objEntity.txtPMHMajorSurgeryHospName2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryType2", objEntity.txtPMHMajorSurgeryType2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHMajorSurgery3", objEntity.dtePMHMajorSurgery3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryAlternativeDate3", objEntity.txtPMHMajorSurgeryAlternativeDate3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryHospName3", objEntity.txtPMHMajorSurgeryHospName3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryType3", objEntity.txtPMHMajorSurgeryType3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHMajorSurgery4", objEntity.dtePMHMajorSurgery4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryAlternativeDate4", objEntity.txtPMHMajorSurgeryAlternativeDate4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryHospName4", objEntity.txtPMHMajorSurgeryHospName4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryType4", objEntity.txtPMHMajorSurgeryType4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHMajorSurgery5", objEntity.dtePMHMajorSurgery5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryAlternativeDate5", objEntity.txtPMHMajorSurgeryAlternativeDate5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryHospName5", objEntity.txtPMHMajorSurgeryHospName5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryType5", objEntity.txtPMHMajorSurgeryType5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHMajorSurgery6", objEntity.dtePMHMajorSurgery6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryAlternativeDate6", objEntity.txtPMHMajorSurgeryAlternativeDate6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryHospName6", objEntity.txtPMHMajorSurgeryHospName6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryType6", objEntity.txtPMHMajorSurgeryType6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("dtePMHMajorSurgery7", objEntity.dtePMHMajorSurgery7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryAlternativeDate7", objEntity.txtPMHMajorSurgeryAlternativeDate7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryHospName7", objEntity.txtPMHMajorSurgeryHospName7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHMajorSurgeryType7", objEntity.txtPMHMajorSurgeryType7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

  new XElement("txtPMHDate1", objEntity.txtPMHDate1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType1", objEntity.ddPMHType1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName1", objEntity.txtPMHHospitalName1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason1", objEntity.txtPMHReason1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

 new XElement("txtPMHDate2", objEntity.txtPMHDate2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("ddPMHType2", objEntity.ddPMHType2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHHospitalName2", objEntity.txtPMHHospitalName2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHReason2", objEntity.txtPMHReason2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

 new XElement("txtPMHDate3", objEntity.txtPMHDate3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType3", objEntity.ddPMHType3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName3", objEntity.txtPMHHospitalName3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHReason3", objEntity.txtPMHReason3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate4", objEntity.txtPMHDate4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType4", objEntity.ddPMHType4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName4", objEntity.txtPMHHospitalName4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason4", objEntity.txtPMHReason4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate5", objEntity.txtPMHDate5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType5", objEntity.ddPMHType5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName5", objEntity.txtPMHHospitalName5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason5", objEntity.txtPMHReason5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate6", objEntity.txtPMHDate6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType6", objEntity.ddPMHType6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName6", objEntity.txtPMHHospitalName6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason6", objEntity.txtPMHReason6, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate7", objEntity.txtPMHDate7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType7", objEntity.ddPMHType7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName7", objEntity.txtPMHHospitalName7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason7", objEntity.txtPMHReason7, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate8", objEntity.txtPMHDate8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType8", objEntity.ddPMHType8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName8", objEntity.txtPMHHospitalName8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason8", objEntity.txtPMHReason8, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate9", objEntity.txtPMHDate9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType9", objEntity.ddPMHType9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName9", objEntity.txtPMHHospitalName9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason9", objEntity.txtPMHReason9, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate10", objEntity.txtPMHDate10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType10", objEntity.ddPMHType10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName10", objEntity.txtPMHHospitalName10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason10", objEntity.txtPMHReason10, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate11", objEntity.txtPMHDate11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType11", objEntity.ddPMHType11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName11", objEntity.txtPMHHospitalName11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason11", objEntity.txtPMHReason11, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate12", objEntity.txtPMHDate12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType12", objEntity.ddPMHType12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName12", objEntity.txtPMHHospitalName12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason12", objEntity.txtPMHReason12, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate13", objEntity.txtPMHDate13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType13", objEntity.ddPMHType13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName13", objEntity.txtPMHHospitalName13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason13", objEntity.txtPMHReason13, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate14", objEntity.txtPMHDate14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType14", objEntity.ddPMHType14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName14", objEntity.txtPMHHospitalName14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason14", objEntity.txtPMHReason14, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate15", objEntity.txtPMHDate15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType15", objEntity.ddPMHType15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName15", objEntity.txtPMHHospitalName15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason15", objEntity.txtPMHReason15, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate16", objEntity.txtPMHDate16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType16", objEntity.ddPMHType16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName16", objEntity.txtPMHHospitalName16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason16", objEntity.txtPMHReason16, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate17", objEntity.txtPMHDate17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType17", objEntity.ddPMHType17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName17", objEntity.txtPMHHospitalName17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason17", objEntity.txtPMHReason17, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate18", objEntity.txtPMHDate18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType18", objEntity.ddPMHType18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName18", objEntity.txtPMHHospitalName18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason18", objEntity.txtPMHReason18, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate19", objEntity.txtPMHDate19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType19", objEntity.ddPMHType19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName19", objEntity.txtPMHHospitalName19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason19", objEntity.txtPMHReason19, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate20", objEntity.txtPMHDate20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType20", objEntity.ddPMHType20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName20", objEntity.txtPMHHospitalName20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason20", objEntity.txtPMHReason20, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate21", objEntity.txtPMHDate21, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType21", objEntity.ddPMHType21, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName21", objEntity.txtPMHHospitalName21, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason21", objEntity.txtPMHReason21, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate22", objEntity.txtPMHDate22, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType22", objEntity.ddPMHType22, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName22", objEntity.txtPMHHospitalName22, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason22", objEntity.txtPMHReason22, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate23", objEntity.txtPMHDate23, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType23", objEntity.ddPMHType23, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName23", objEntity.txtPMHHospitalName23, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason23", objEntity.txtPMHReason23, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate24", objEntity.txtPMHDate24, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType24", objEntity.ddPMHType24, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName24", objEntity.txtPMHHospitalName24, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason24", objEntity.txtPMHReason24, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

new XElement("txtPMHDate25", objEntity.txtPMHDate25, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType25", objEntity.ddPMHType25, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName25", objEntity.txtPMHHospitalName25, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason25", objEntity.txtPMHReason25, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


new XElement("txtPMHDate26", objEntity.txtPMHDate26, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("ddPMHType26", objEntity.ddPMHType26, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHHospitalName26", objEntity.txtPMHHospitalName26, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
new XElement("txtPMHReason26", objEntity.txtPMHReason26, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)), 




 new XElement("cboPrenatalCourseNormalAbnormal", objEntity.cboPrenatalCourseNormalAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHPrenatalDeliveryApproxDate", objEntity.txtPMHPrenatalDeliveryApproxDate, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHPrenatalDeliveryHospName", objEntity.txtPMHPrenatalDeliveryHospName, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
 new XElement("txtPMHPrenatalDeliveryComments", objEntity.txtPMHPrenatalDeliveryComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))


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
                       // sqlcmd.Parameters.AddWithValue("@seq", 8);

                        if (objPatientPage.PatientFormId == Guid.Parse("477CFB93-1A9A-4A36-91D6-F8B120B0486C"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 8);
                        }
                        else if (objPatientPage.PatientFormId == Guid.Parse("6CB27127-AD1D-4456-8F83-8D5AC2D75568"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 8);
                        }

                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 5);
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
