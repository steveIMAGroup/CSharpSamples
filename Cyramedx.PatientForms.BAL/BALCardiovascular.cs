using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALCardiovascular
    {
        public int BALSavePageasXML3(entCardiovascular objEntity, Guid PatientSchedulesId)
        {
            DALCardiovascular objCardio = new DALCardiovascular();
            return objCardio.SavePageasXML3(objEntity, PatientSchedulesId);
        }
    }
}
