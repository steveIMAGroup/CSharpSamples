using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALPESpine
    {
        public DataTable BALMetaDataState()
        {
            DALPESpine objPESpine = new DALPESpine();
            return objPESpine.MetaDataState();
        }
        public int BALSavePageasXML(entPESpine objEntity, Guid PatientSchedulesId)
        {
            DALPESpine objPESpine = new DALPESpine();
            return objPESpine.SavePageasXML(objEntity, PatientSchedulesId);
        }
       
    }
}
