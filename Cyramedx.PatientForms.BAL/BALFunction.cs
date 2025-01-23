using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALFunction
    {
        public int BALSavePageasXML(entFunction objEntity, Guid PatientSchedulesId)
        {
            DALFunction objFunctions = new DALFunction();
            return objFunctions.SavePageasXML(objEntity, PatientSchedulesId);
        }
       
    }
}
