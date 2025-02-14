using Skyttus.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Entity.Manage;
//using TimeTable.Models.Models;

namespace TimeTable.Services.Services.Interfaces
{
    public interface ITimeTableService //: IBaseService<TimeTableDetail, Entity.Manage.TimeTableDetail>
    {
        Task<TimeTableDetail> AddTime(TimeTableDetail model);
        Task<TimeTableDetail> AddTimeTable(TimeTableDetail timeTableEntity);
    }
}
