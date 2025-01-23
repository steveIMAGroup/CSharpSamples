using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALPENeuroLogic
    {
        public int BALSavePageasXML1(entNeurologic objEntity, Guid PatientSchedulesId)
        {
            DALPENeuroLogic objAllegations = new DALPENeuroLogic();
            return objAllegations.SavePageasXML1(objEntity, PatientSchedulesId);
        }

    }
}
