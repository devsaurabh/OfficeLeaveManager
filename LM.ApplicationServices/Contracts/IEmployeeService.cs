using LM.ApplicationServices.ServiceModel;

namespace LM.ApplicationServices.Contracts
{
    public interface IEmployeeService
    {
        int AddEmployee(EmployeeSModel model);

        bool DeleteEmployee(int employeeId);
    }
}
