using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALHxOfDigestive
    {
        public int BALSavePageasXML1(entHxOfDigestive objEntity, Guid PatientSchedulesId)
        {
            DALHxOfDigestive objHxOfDigestive = new DALHxOfDigestive();
            return objHxOfDigestive.SavePageasXML1(objEntity, PatientSchedulesId);
        }
        
    }
}
