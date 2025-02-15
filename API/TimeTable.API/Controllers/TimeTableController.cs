using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTable.API.Controllers.Common;
using TimeTable.Entity.Manage;
using TimeTable.Services.Services.Interfaces;

namespace TimeTable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTableController : ControllerBase
    {
        private readonly ITimeTableService _timeTableService;
        public TimeTableController(ILogger<TimeTableController> logger, ITimeTableService timeTableService) 
        => (_timeTableService) = (timeTableService);

        [HttpPost("generate")] 
        public async Task<IActionResult> GenerateTimeTable([FromBody] TimeTableDetail request)
        {
            int totalHoursForWeek = request.NoOfWorkingDays * request.NoOfSubjectsPerDay;

            var total = request.SubjectHours.Select(x => x.TotalHours).Sum();
            if (total != totalHoursForWeek)
            {
                return BadRequest("Total subject hours must be equal to the total hours for the week.");
            }

            var timeTableEntity = new TimeTableDetail
            {
                NoOfWorkingDays = request.NoOfWorkingDays,
                NoOfSubjectsPerDay = request.NoOfSubjectsPerDay,
                TotalSubjects = request.TotalSubjects,
                CreatedDate = DateTime.UtcNow,
                SubjectHours = request.SubjectHours
            };

            await _timeTableService.AddTimeTable(timeTableEntity);
            return Ok(new { message = "Timetable successfully created!"});
        }

        [HttpGet("GenerateTimetable")]
        public async Task<IActionResult> GetTimeTable(Guid timeTableId)
        {
            var request = await _timeTableService.GetTimeTable(timeTableId);

            if(request == null)
            {
                return NotFound("Timetable details not found.");
            }
            List<List<string>> timetable = new();
            List<string> subjects = new();

            foreach (var subject in request.SubjectHours)
            {
                if (subject == null || string.IsNullOrEmpty(subject.SubjectName))
                {
                    continue;
                }
                subjects.AddRange(Enumerable.Repeat(subject.SubjectName, subject.TotalHours));
            }

            Random rand = new Random();
            subjects = subjects.OrderBy(_ => rand.Next()).ToList();

            int index = 0;
            for (int i = 0; i < request.NoOfWorkingDays; i++)
            {
                List<string> daySubjects = new();
                for (int j = 0; j < request.NoOfSubjectsPerDay; j++)
                {
                    if (index < subjects.Count)
                    {
                        daySubjects.Add(subjects[index]);
                        index++;
                    }
                }
                timetable.Add(daySubjects);
            }

            return Ok(timetable);
        }

    }
}
