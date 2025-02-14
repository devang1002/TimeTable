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
    public class TimeTableRepository :ITimeTableRepository//: GenericRepository<TimeTableDetail>, ITimeTableRepository
    {
        private readonly TimeTableContext _timeTablesContext;
        public TimeTableRepository(TimeTableContext timeTablesContext) //: base(timeTablesContext)
        => (_timeTablesContext) = (timeTablesContext);

        public async Task<TimeTableDetail> AddTime(TimeTableDetail model)
        {
            var result = _timeTablesContext.TimeTable.Add(model);
            await _timeTablesContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimeTableDetail> AddTimeTable(TimeTableDetail timeTable)
        {
            foreach (var subject in timeTable.SubjectHours)
            {
                subject.TimeTableId = timeTable.Id;
            }
            _timeTablesContext.TimeTable.Add(timeTable);
            try
            {
                await _timeTablesContext.SaveChangesAsync();
                

            }
            catch (Exception)
            {

                throw;
            }
            return timeTable;
        }
    }
}
