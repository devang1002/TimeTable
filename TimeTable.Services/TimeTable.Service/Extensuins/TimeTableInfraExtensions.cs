using TimeTable.Services.Services;
using TimeTable.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
//using AutoMapper.Extensions.Microsoft.DependencyInjection;

namespace TimeTable.Services.Extensions
{
    public static class TimeTableServiceExtensions
    {
        public static IServiceCollection TimeTableInfraService(this IServiceCollection builder)
        {


            builder.AddScoped<ISubjectService, SubjectService>();
            builder.AddScoped<ITimeTableService, TimeTableService>();


            //All service needs to register for Dependency injection
            builder.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




            return builder;
        }
    }
}
