using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTable.API.Controllers.Common;
using TimeTable.Models.Models;
using TimeTable.Services.Services.Interfaces;

namespace TimeTable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase//CrudController<Entity.Manage.Subject, Entity.Manage.Subject>
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService, ILogger<SubjectController> logger) //: base(logger, subjectService)
        => (_subjectService) = (subjectService);
    }
}
