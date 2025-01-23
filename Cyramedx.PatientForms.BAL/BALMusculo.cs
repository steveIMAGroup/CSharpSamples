using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALMusculo
    {
        public int BALSavePageasXML1(entmusculo objEntity, Guid PatientSchedulesId)
        {
            DALMusculo objmus = new DALMusculo();
            return objmus.SavePageasXML1(objEntity, PatientSchedulesId);
        }
    }
}
