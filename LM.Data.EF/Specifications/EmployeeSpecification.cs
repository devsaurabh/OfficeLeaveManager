using LM.Data.EF.Contracts;
using LM.Data.Model;
using LM.Framework.Data.Entity;

namespace LM.Data.EF.Specifications
{
    public class EmployeeSpecification : QueryableSpecification<Employee>, IEmployeeSpecification
    {
        public IEmployeeSpecification WithEmployeeId(int empId)
        {
            Predicate = Predicate.And(emp => emp.Id == empId);
            return this;
        }
    }
}
