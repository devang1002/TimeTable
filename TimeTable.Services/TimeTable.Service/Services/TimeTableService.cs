using AutoMapper;
using Skyttus.Core.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Entity.Manage;
using TimeTable.Infra.Repository.Interfaces;
using TimeTable.Services.Services.Interfaces;

namespace TimeTable.Services.Services
{
    public class TimeTableService : ITimeTableService
    {
        private readonly ITimeTableRepository _timeTableRepository;
        public TimeTableService(ITimeTableRepository timeTableRepository, IMapper mapper) 
        => (_timeTableRepository) = (timeTableRepository);

        public async Task<TimeTableDetail> AddTimeTable(TimeTableDetail timeTableEntity)
        {
            var result = await _timeTableRepository.AddTimeTable(timeTableEntity);
            return (result);
        }

        public async Task<TimeTableDetail> GetTimeTable(Guid timeTableId)
        {
            var result = await _timeTableRepository.GetTimeTable(timeTableId); 
            return (result);
        }
    }
}
