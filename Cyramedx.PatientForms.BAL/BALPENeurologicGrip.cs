using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALPENeurologicGrip
    {
        public DataTable BALMetaDataState()
        {
            DALPENeurologicGrip objPENeuroGrip = new DALPENeurologicGrip();
            return objPENeuroGrip.MetaDataState();
        }
        public int BALSavePageasXML(entPENeurologicGrip objEntity, Guid PatientSchedulesId)
        {
            DALPENeurologicGrip objPENeuroGrip = new DALPENeurologicGrip();
            return objPENeuroGrip.SavePageasXML(objEntity, PatientSchedulesId);
        }
        public int UpdatePEVitalGrammerText(Guid PatientScheduleId, Guid PatientFormId, string grammertext)
        {
            DALPENeurologicGrip objPENeuroGrip = new DALPENeurologicGrip();
            return objPENeuroGrip.UpdatePEVitalGrammerText(PatientScheduleId, PatientFormId, grammertext);
        }
        public int InsertPEVitalNewGrammerText(Guid PatientScheduleId, Guid PatientFormId, string grammertext)
        {
            DALMAForm objMAForm = new DALMAForm();
            return objMAForm.InsertPEVitalNewGrammerText(PatientScheduleId, PatientFormId, grammertext);
        }

    }
}
