using System;

namespace LM.Data.Model
{
    public class EmployeeLeave : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int MonthlyLeaveId { get; set; }
        public MonthlyLeave MonthlyLeave { get; set; }
        public LeaveType Leave { get; set; }
        public DateTime LeaveDate { get; set; }
        public LeaveDuration LeaveDuration { get; set; }
    }
}