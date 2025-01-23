using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALImpressionHx
    {
        public int BALSavePageasXML1(entImpressionHx objEntity, Guid PatientSchedulesId)
        {
            DALImpressionHx objImpressions = new DALImpressionHx();
            return objImpressions.SavePageasXML1(objEntity, PatientSchedulesId);
        }
        
        
    }
}
