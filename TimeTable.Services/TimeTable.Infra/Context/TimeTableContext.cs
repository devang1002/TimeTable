using Microsoft.EntityFrameworkCore;
using Skyttus.Core.Infra.Context;
using TimeTable.Entity.Manage;

namespace TimeTable.Infra.Context
{
    public class TimeTableContext : SkyttusBaseContext
    {
        public TimeTableContext(DbContextOptions<TimeTableContext> options) : base(options)
        {

        }    
        public DbSet<Subject> Subject { get; set; }
        public DbSet<TimeTableDetail> TimeTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
