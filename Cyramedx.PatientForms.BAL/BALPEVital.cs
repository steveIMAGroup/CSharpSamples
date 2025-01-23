using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALPEVital
    {
        public int BALSavePageasXML3(entPEVital objEntity, Guid PatientSchedulesId)
        {
            DALPEVital objvital = new DALPEVital();
            return objvital.SavePageasXML3(objEntity, PatientSchedulesId);
        }
        public string getGrammerText(Guid PatientScheduleId, Guid PatientFormId)
        {
            DALPEVital objvital = new DALPEVital();
            return objvital.getGrammerText(PatientScheduleId, PatientFormId);
        }
    }
}
