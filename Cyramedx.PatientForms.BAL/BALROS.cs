using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALROS
    {
        public int BALSavePageasXML2(entROS objEntity, Guid PatientSchedulesId)
        {
            DALROS objROSs = new DALROS();
            return objROSs.SavePageasXML2(objEntity, PatientSchedulesId);
           
        }
    }
}
