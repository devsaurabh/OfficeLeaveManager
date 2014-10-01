using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LM.Data.Model;

namespace LM.Data.Mappings
{
    public class EmployeeLeaveConfiguration : EntityTypeConfiguration<EmployeeLeave>
    {
        public EmployeeLeaveConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("EmployeeLeaveId");
            HasRequired(e => e.Employee).WithMany().HasForeignKey(e => e.EmployeeId);
            HasRequired(e => e.MonthlyLeave).WithMany(l=> l.EmployeeLeaves).HasForeignKey(e => e.MonthlyLeaveId);
        }
    }
}