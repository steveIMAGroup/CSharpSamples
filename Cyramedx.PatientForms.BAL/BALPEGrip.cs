using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
   public class BALPEGrip
    {
        public DataTable BALMetaDataState()
        {
            DALPEGrip objPEGrip = new DALPEGrip();
            return objPEGrip.MetaDataState();
        }
        public int BALSavePageasXML(entPEGrip objEntity, Guid PatientSchedulesId)
        {
            DALPEGrip objPEGrip = new DALPEGrip();
            return objPEGrip.SavePageasXML(objEntity, PatientSchedulesId);
        }
        
    }
}
