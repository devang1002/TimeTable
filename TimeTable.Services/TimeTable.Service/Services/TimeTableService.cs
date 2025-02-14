using AutoMapper;
using Skyttus.Core.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Entity.Manage;
using TimeTable.Infra.Repository.Interfaces;
//using TimeTable.Models.Models;
using TimeTable.Services.Services.Interfaces;

namespace TimeTable.Services.Services
{
    public class TimeTableService : ITimeTableService// BaseService<TimeTableDetail, Entity.Manage.TimeTableDetail>, ITimeTableService
    {
        private readonly ITimeTableRepository _timeTableRepository;
        public TimeTableService(ITimeTableRepository timeTableRepository, IMapper mapper) //: base(timeTableRepository, mapper)
        => (_timeTableRepository) = (timeTableRepository);

        public async Task<TimeTableDetail> AddTime(TimeTableDetail model)
        {
            var timeTable = new TimeTableDetail()
            {
                CreatedDate = DateTime.Now,
                //SubjectsPerDay = model.SubjectsPerDay,
                //WorkingDays = model.WorkingDays,
                //TotalHoursPerWeek = model.SubjectsPerDay * model.WorkingDays,
                Id = Guid.NewGuid()
            };
            var result = await _timeTableRepository.AddTime(timeTable);//_mapper.Map<Entity.Manage.TimeTableDetail>(timeTable));
            return (result);// _mapper.Map<TimeTableDetail>(result);
        }

        public async Task<TimeTableDetail> AddTimeTable(TimeTableDetail timeTableEntity)
        {
            var result = await _timeTableRepository.AddTimeTable(timeTableEntity);// _mapper.Map<Entity.Manage.TimeTableDetail>(timeTableEntity));
            return (result);// _mapper.Map<TimeTableDetail>(result);
        }
    }
}
