using AutoMapper;
using TimeTable.Entity.Manage;
using Model = TimeTable.Models.Models;

namespace TimeTable.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Subject, Subject>();
            CreateMap<Subject, Model.Subject>();

            CreateMap<Model.TimeTableDetail, TimeTableDetail>();
            CreateMap<TimeTableDetail, Model.TimeTableDetail>();
        }
    }
}
