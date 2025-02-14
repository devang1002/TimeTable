using Skyttus.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Entity.Manage
{
    public class Subject : BaseEntity
    {
        public string SubjectName { get; set; }
        public int TotalHours { get; set; }
        public Guid TimeTableId { get; set; }
        [ForeignKey("TimeTableId")]
        public TimeTableDetail? TimeTable { get; set; }
    }
}
