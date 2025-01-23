using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;

namespace Cyramedx.PatientForms.BAL
{
    public class BALCommon
    {
        public DataTable BALgetPatientHeader(Guid PatientSchedulesId)
        {
            Common objCommon = new Common();
            return objCommon.getPatientHeader(PatientSchedulesId);
        }
        public DataTable BALselectAll3Providers(Guid PatientSchedulesId)
        {
            Common objCommon = new Common();
            return objCommon.selectAll3Providers(PatientSchedulesId);
        }
        public bool BALUpdateDefaultProviderForms(Guid PatientScheduleId, Guid ProviderId)
        {


            Common objCommon = new Common();
            return objCommon.UpdateDefaultProviderForms(PatientScheduleId, ProviderId);
        }
        public DataTable BALGetNewMasterPage(Guid MasterPageID)
        {
            Common objCommon = new Common();
            return objCommon.GetNewMasterPage(MasterPageID);
        }
        public DataSet BALIsPageExist(Guid PatientSchedulesId, Guid MasterPageID)
        {
            Common objCommon = new Common();
            return objCommon.IsPageExist(PatientSchedulesId, MasterPageID);
        }
        public void BALupdatePatientHeaderDetails(Guid PatientId, Guid PersonId, Guid PatientSchedulesId, Guid SiteSchedulesId, string DOB,
                                                string FirstName, string MiddleName, string LastName, string SSN, string CaseId, string Gender, string UserUid)
        {
            Common objCommon = new Common();
           objCommon.updatePatientHeaderDetails( PatientId,  PersonId,  PatientSchedulesId,  SiteSchedulesId,  DOB,
                                                 FirstName,  MiddleName,  LastName,  SSN,  CaseId,  Gender,  UserUid);
        }
        public String GetCompanyName(String _companyid)
        {
            Common objCommon = new Common();
            return objCommon.GetCompanyName(_companyid);
        }
        public void UpdateGender(string personid, string gender, string SSN, bool update)
        {
            Common objCommon = new Common();
            objCommon.UpdateGender(personid, gender, SSN, update);
        }
    }
}
