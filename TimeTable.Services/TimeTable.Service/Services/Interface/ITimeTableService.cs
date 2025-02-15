using Skyttus.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Entity.Manage;

namespace TimeTable.Services.Services.Interfaces
{
    public interface ITimeTableService
    {
        Task<TimeTableDetail> AddTimeTable(TimeTableDetail timeTableEntity);
        Task<TimeTableDetail> GetTimeTable(Guid timeTableId);
    }
}
