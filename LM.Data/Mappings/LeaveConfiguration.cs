using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LM.Data.Model;

namespace LM.Data.Mappings
{
    public class LeaveConfiguration : EntityTypeConfiguration<Leave>
    {
        public LeaveConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("LeaveId");
        }
    }
}