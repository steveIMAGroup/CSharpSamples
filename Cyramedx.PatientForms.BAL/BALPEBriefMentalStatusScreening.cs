using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALPEBriefMentalStatusScreening
    {
        public DataTable BALMetaDataState()
        {
            DALPEBriefMentalStatusScreening objPEBriefMentalStatusScreening = new DALPEBriefMentalStatusScreening();
            return objPEBriefMentalStatusScreening.MetaDataState();
        }
        public int BALSavePageasXML(entPEBriefMentalStatusScreening objEntity, Guid PatientSchedulesId)
        {
            DALPEBriefMentalStatusScreening objPEBriefMentalStatusScreening = new DALPEBriefMentalStatusScreening();
            return objPEBriefMentalStatusScreening.SavePageasXML(objEntity, PatientSchedulesId);
        }
    }
}
