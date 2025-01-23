using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyramedx.PatientForms.Entities
{
    public class entPatientPages
    {
        public Guid PatientPageId { get; set; }
        public Guid PatientFormId { get; set; }
        public Guid ScheduleId { get; set; }
        public string PageXmlData { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
