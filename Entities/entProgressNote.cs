using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public  class entProgressNote
    {
        public int ProgressNOteId { get; set; }
        public Guid ScheduleId { get; set; }
        public string ProgressNoteText { get; set; }
        public string ProgressNoteType { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public int PageCount { get; set; }

        public DateTime? SignedDate { get; set; }
        public bool IsSigned { get; set; }
        public string AddendumNotes { get; set; }
        public bool IsDigitallySigned { get; set; }
        public string DigitalSign { get; set; }
    }
}
