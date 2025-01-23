using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyramedx.PatientForms.Entities;
using Cyramedx.PatientForms.DAL;

namespace Cyramedx.PatientForms.BAL
{
    public class BALPEHearing
    {
        public int BALSavePageasXML3(entPEHearing objEntity, Guid PatientSchedulesId)
        {
            DALPEHearing objhear = new DALPEHearing();
            return objhear.SavePageasXML3(objEntity, PatientSchedulesId);
        }
    }
}
