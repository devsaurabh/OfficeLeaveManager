using LM.Data.Model;
using LM.Framework.Data.Repository;

namespace LM.Data.EF.Contracts
{
    public interface IEmployeeSpecification : ISpecification<Employee>
    {
        IEmployeeSpecification WithEmployeeId(int empId);
    }
}
