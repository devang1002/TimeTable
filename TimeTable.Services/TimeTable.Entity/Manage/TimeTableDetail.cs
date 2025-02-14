using Skyttus.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Entity.Manage
{
    public class TimeTableDetail : BaseEntity
    {
        [Range(1, 7, ErrorMessage = "No of working days should be between 1 and 7.")]
        public int NoOfWorkingDays { get; set; }

        [Range(1, 8, ErrorMessage = "No of subjects per day should be between 1 and 8.")]
        public int NoOfSubjectsPerDay { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Total subjects should be a positive number.")]
        public int TotalSubjects { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<Subject>? SubjectHours { get; set; }
    }
}
