using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;
namespace Cyramedx.PatientForms.BAL
{
    public class BALAllsystemformsforMoonlight
    {
        public int BALSavePageasXML3(entAllSystemformsforMoonlight objEntity, Guid PatientSchedulesId)
        {
            DALAllSystemformsforMoonlight objsystem = new DALAllSystemformsforMoonlight();
            return objsystem.SavePageasXML3(objEntity, PatientSchedulesId);
        }
    }
}
