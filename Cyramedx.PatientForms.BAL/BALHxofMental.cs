using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALHxofMental
    {

        public int BALSavePageasXML1(entHxofMental objEntity, Guid PatientSchedulesId)
        {
            DALHxofMental objHxofMental = new DALHxofMental();
            return objHxofMental.SavePageasXML1(objEntity, PatientSchedulesId);
        }
        
    }
}
