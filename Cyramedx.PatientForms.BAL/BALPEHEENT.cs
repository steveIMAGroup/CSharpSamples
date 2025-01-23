using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
   public class BALPEHEENT
    {
        public DataTable BALMetaDataState()
        {
            DALPEHEENT objPEHEENT = new DALPEHEENT();
            return objPEHEENT.MetaDataState();
        }
        public int BALSavePageasXML(entPEHEENT objEntity, Guid PatientSchedulesId)
        {
            DALPEHEENT objPEHEENT = new DALPEHEENT();
            return objPEHEENT.SavePageasXML(objEntity, PatientSchedulesId);
        }
        
    }
}
