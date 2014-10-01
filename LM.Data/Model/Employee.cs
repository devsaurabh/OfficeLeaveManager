using System;

namespace LM.Data.Model
{
    public class Employee : BaseEntity
    {
        public int EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public WorkShift WorkShift { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public bool IsDeleted { get; set; }
        public Decimal CompOffs { get; set; }
        public Decimal CarryForward { get; set; }
    }
}
