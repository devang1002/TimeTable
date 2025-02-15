using Microsoft.EntityFrameworkCore;
using Skyttus.Core.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Entity.Manage;
using TimeTable.Infra.Context;
using TimeTable.Infra.Repository.Interfaces;

namespace TimeTables.Infra.Repository
{
    public class TimeTableRepository : ITimeTableRepository
    {
        private readonly TimeTableContext _timeTablesContext;
        public TimeTableRepository(TimeTableContext timeTablesContext)
        => (_timeTablesContext) = (timeTablesContext);

        public async Task<TimeTableDetail> AddTimeTable(TimeTableDetail timeTable)
        {
            foreach (var subject in timeTable.SubjectHours)
            {
                subject.TimeTableId = timeTable.Id;
            }
            _timeTablesContext.TimeTable.Add(timeTable);
            await _timeTablesContext.SaveChangesAsync();
            return timeTable;
        }

        public async Task<TimeTableDetail> GetTimeTable(Guid timeTableId)
        {
            return await _timeTablesContext.TimeTable.Include(x => x.SubjectHours).AsNoTracking().FirstOrDefaultAsync(x => x.Id == timeTableId);
        }
    }
}
