using System.Data.Entity;
using LM.Data.Mappings;
using LM.Data.Model;

namespace LM.Data.Context
{
    public class LmContext : DbContext
    {
        public LmContext() : base("LmContext") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
        public DbSet<MonthlyLeave> MonthlyLeaves { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new EmployeeLeaveConfiguration());
            modelBuilder.Configurations.Add(new MonthlyLeaveConfiguration());
            modelBuilder.Configurations.Add(new LeaveConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
