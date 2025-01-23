using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALROMFinger
    {
        public int BALSavePageasXML(entROMFinger objEntity, Guid PatientSchedulesId)
        {
            DALROMFinger objfinger = new DALROMFinger();
            return objfinger.SavePageasXML(objEntity, PatientSchedulesId);
        }
    }
}
