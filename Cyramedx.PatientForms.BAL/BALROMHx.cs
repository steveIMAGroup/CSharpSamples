using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
   public class BALROMHx
    {

        public int BALSavePageasXML1(entROMHx objEntity, Guid PatientSchedulesId)
        {
            DALROMHx objROM = new DALROMHx();
            return objROM.SavePageasXML1(objEntity, PatientSchedulesId);
        }
       
    }
}
