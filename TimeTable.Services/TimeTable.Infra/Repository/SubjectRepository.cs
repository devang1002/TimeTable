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
    public class SubjectRepository : ISubjectRepository//GenericRepository<Subject>, ISubjectRepository
    {
        private readonly TimeTableContext _timeTableContext;
        public SubjectRepository(TimeTableContext timeTableContext) //: base(timeTableContext)
        => (_timeTableContext) = (timeTableContext);
    }
}
