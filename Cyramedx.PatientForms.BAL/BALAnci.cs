using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
   public class BALAnci
    {
       public int BALSavePageasXML(entAnciTesting objEntity, Guid PatientSchedulesId)
       {
           DALAnciTesting objancitest = new DALAnciTesting();
           return objancitest.SavePageasXML(objEntity, PatientSchedulesId);
       }
    }
}
