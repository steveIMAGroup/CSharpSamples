using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALIandC
    {
        public int SavePageasXML3(string dteInformedConsentSigned, string txthidden, Guid PatientSchedulesId,string UserName)
        {
            DAL.DALIandC objIandC=new DALIandC();
            return objIandC.SavePageasXML3(dteInformedConsentSigned, txthidden, PatientSchedulesId, UserName);
        }
    }
}
