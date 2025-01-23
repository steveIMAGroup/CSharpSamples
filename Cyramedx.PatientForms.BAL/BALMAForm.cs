using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
   public class BALMAForm
    {
        public DataTable BALMetaDataState()
        {
            DALMAForm objMAForm = new DALMAForm();
            return objMAForm.MetaDataState();
        }
        public int BALSavePageasXML(entMAForm objEntity, Guid PatientSchedulesId)
        {
            DALMAForm objMAForm = new DALMAForm();
            return objMAForm.SavePageasXML(objEntity, PatientSchedulesId);
        }
        public int UpdatePEVitalGrammerText(Guid PatientScheduleId, Guid PatientFormId, string grammertext)
        {
            DALMAForm objMAForm = new DALMAForm();
            return objMAForm.UpdatePEVitalGrammerText(PatientScheduleId, PatientFormId, grammertext);
        }
        public int UpdateAllegationGrammerText(Guid PatientScheduleId, Guid PatientFormId, string grammertext)
        {
            DALMAForm objMAForm = new DALMAForm();
            return objMAForm.UpdateAllegationGrammerText(PatientScheduleId, PatientFormId, grammertext);
        }
        public int InsertPEVitalNewGrammerText(Guid PatientScheduleId, Guid PatientFormId, string grammertext)
        {
            DALMAForm objMAForm = new DALMAForm();
            return objMAForm.InsertPEVitalNewGrammerText(PatientScheduleId, PatientFormId, grammertext);
        }
        public int InsertAllegationNewGrammerText(Guid PatientScheduleId, Guid PatientFormId, string grammertext)
        {
            DALMAForm objMAForm = new DALMAForm();
            return objMAForm.InsertAllegationNewGrammerText(PatientScheduleId, PatientFormId, grammertext);
        }
       }
}
