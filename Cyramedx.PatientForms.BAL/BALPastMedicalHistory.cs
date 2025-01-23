using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
   public class BALPastMedicalHistory
    {
        public int BALSavePageasXML1(entPastMedicalHistory objEntity, Guid PatientSchedulesId)
        {
            DALPastMedicalHistory objPastMedicalHistory = new DALPastMedicalHistory();
            return objPastMedicalHistory.SavePageasXML1(objEntity, PatientSchedulesId);
        }
        
    }
}
