using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALROMforMedplus
    {
        public int BALSavePageasXML1(entROMforMedplus objEntity, Guid PatientSchedulesId)
        {
            DALROMforMedplus objROM = new DALROMforMedplus();
            return objROM.SavePageasXML1(objEntity, PatientSchedulesId);
        }
    }
}
