using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALHxOfPulmonary
    {
        public int BALSavePageasXML1(entHxOfPulmonary objEntity, Guid PatientSchedulesId)
        {
            DALHxOfPulmonary objHxOfPulmonary = new DALHxOfPulmonary();
            return objHxOfPulmonary.SavePageasXML1(objEntity, PatientSchedulesId);
        }
        
    }
}
