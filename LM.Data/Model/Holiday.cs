using System;

namespace LM.Data.Model
{
    public class Holiday : BaseEntity
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public WorkShift WorkShift { get; set; }
    }
}
