using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALAllSystem
    {
        public int BALSavePageasXML3(entAllSystemForms objEntity, Guid PatientSchedulesId)
        {
            DAlAllSystems objsystem = new DAlAllSystems();
            return objsystem.SavePageasXML3(objEntity, PatientSchedulesId);
        }
    }
}
