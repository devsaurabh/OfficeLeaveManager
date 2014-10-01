using System;
using System.Collections.Generic;

namespace LM.Data.Model
{
    public class MonthlyLeave : BaseEntity
    {
        public DateTime GeneratedOn { get; set; }
        public int WorkingDays { get; set; }
        public List<EmployeeLeave> EmployeeLeaves { get; set; }
        public List<string> Remarks { get;set; }
    }
}