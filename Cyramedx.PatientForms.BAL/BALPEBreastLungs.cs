using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyramedx.PatientForms.Entities;
using Cyramedx.PatientForms.DAL;

namespace Cyramedx.PatientForms.BAL
{
    public class BALPEBreastLungs
    {
         public int BALSavePageasXML3(entPEBreastLungs objEntity, Guid PatientSchedulesId)
        {
            DALPEBreastLungs objvital = new DALPEBreastLungs();
            return objvital.SavePageasXML3(objEntity, PatientSchedulesId);
        }
    }
}
