using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTable.Infra.Context;
using TimeTable.Infra.Repository.Interfaces;
using TimeTables.Infra.Repository;

namespace TimeTable.Infra.Extensions
{
    public static class TimeTableInfraExtensions
    {
        public static IServiceCollection TimeTableInfraServiceRegistration(this IServiceCollection builder, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TimeTableConnectionStrings");

            builder.AddDbContext<TimeTableContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging(true);
            });

            builder.AddScoped<ISubjectRepository, SubjectRepository>();
            builder.AddScoped<ITimeTableRepository, TimeTableRepository>();

            builder.AddScoped<DbContext, TimeTableContext>();
            return builder;
        }
    }
}
