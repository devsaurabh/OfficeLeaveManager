using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LM.Data.Model;

namespace LM.Data.Mappings
{
    public class MonthlyLeaveConfiguration : EntityTypeConfiguration<MonthlyLeave>
    {
        public MonthlyLeaveConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("MonthlyLeaveId");
        }
    }
}