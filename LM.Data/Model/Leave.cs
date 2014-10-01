using System;

namespace LM.Data.Model
{
    public class Leave : BaseEntity
    {
        public LeaveType LeaveType { get; set; }
        public Decimal Count { get; set; }
        public int ForYear { get; set; }
    }
}
