using AutoMapper;
using Skyttus.Core.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Infra.Repository.Interfaces;
using TimeTable.Models.Models;
using TimeTable.Services.Services.Interfaces;

namespace TimeTable.Services.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        => (_subjectRepository, _mapper) = (subjectRepository, mapper);

    }
}
