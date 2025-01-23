using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALAllegationHx
    {

        public DataTable BALMetaDataState()
        {
            DALAllegationHx objAllegations = new DALAllegationHx();
            return objAllegations.MetaDataState();
        }
        public int BALSavePageasXML(entAllegationHx objEntity, Guid PatientSchedulesId)
        {
            DALAllegationHx objAllegations = new DALAllegationHx();
            return objAllegations.SavePageasXML(objEntity,PatientSchedulesId);
        }
        public string BAlselectDefaultStateid(string ScheduleId)
        {
            DALAllegationHx objAllegations = new DALAllegationHx();
            return objAllegations.selectDefaultStateid(ScheduleId);
        }
        public string BALselectClinicName(string ScheduleId)
        {
            DALAllegationHx objAllegations = new DALAllegationHx();
            return objAllegations.selectClinicName(ScheduleId);
        }
        public string getGrammerText(Guid PatientScheduleId, Guid PatientFormId)
        {
            DALAllegationHx objAllegations = new DALAllegationHx();
            return objAllegations.getGrammerText(PatientScheduleId, PatientFormId);
        }
    }
}
