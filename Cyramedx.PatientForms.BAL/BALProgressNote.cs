using System;
using System.Data;
using Cyramedx.PatientForms.DAL;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.BAL
{
    public class BALProgressNote
    {
        public string GetLoggedinUserRole(string UserName)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.GetLoggedinUserRole((UserName));
        }
        public bool GetCheckIsDigitallySigned(string UserId)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.GetCheckIsDigitallySigned((UserId));
        }

        public DataTable BALselectProgressnote(Guid PatientSchedulesId)
        {
            DALProgressNote objProgressNote=new DALProgressNote();
            return objProgressNote.selectProgressnote((PatientSchedulesId));

        }

        public int BALInsertProgressnote(entProgressNote entProgressnote)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.InsertProgressnote((entProgressnote));
        }

        public int BALInsertDigitalSign(entProgressNote entProgressnote)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.InsertDigitalSign((entProgressnote));
        }
        public int BALUpdateDigitalSignProgressNoteText(entProgressNote entProgressnote)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.UpdateDigitalSignProgressNoteText((entProgressnote));
        }
        public int BALResetProgressnote(entProgressNote entProgressnote)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.ResetProgressnote((entProgressnote));
        }
        public int ClearSignatureProgressnote(entProgressNote entProgressnote)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.ClearSignatureProgressnote((entProgressnote));
        }

        public DataTable selectProgressnoteFromProgrssnote(entProgressNote entProgressnote)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.selectProgressnoteFromProgrssnote((entProgressnote));
        }
        public DataTable BALselectReportHeader(Guid PatientSchedulesId)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.selectReportHeader((PatientSchedulesId));
        }
        public DataTable BALselectUserSignature(Guid Userid)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.selectUserSignature((Userid));
        }
        public string BALGetProgressNotePageCounts(string ScheduleIds)
        {
            DALProgressNote objProgressNote = new DALProgressNote();
            return objProgressNote.GetProgressNotePageCounts((ScheduleIds));
        }
    }
}
