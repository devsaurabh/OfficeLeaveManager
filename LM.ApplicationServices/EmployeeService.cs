using System.Collections.Generic;
using LM.ApplicationServices.Contracts;
using LM.ApplicationServices.ServiceModel;
using LM.Data.EF.Contracts;
using LM.Data.Model;
using LM.Framework.Data.Repository;

namespace LM.ApplicationServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repoEmployee;
        private readonly IUnitOfWork _unitOfWork;

        public bool HasErrors { get; set; }
        public List<string> Errors { get; set; }

        public EmployeeService(IRepository<Employee> repoEmployee, IUnitOfWork unitOfWork)
        {
            _repoEmployee = repoEmployee;
            _unitOfWork = unitOfWork;
        }

        public int AddEmployee(EmployeeSModel model)
        {
            if (model == null)
            {
                HasErrors = true;
                Errors.Add("Employee model must have values");
                return 0;
            }
            var employee = new Employee
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                EmployeeCode = model.EmployeeCode,
                WorkShift = model.WorkShift,
                EmployeeType = model.EmployeeType
            };
            _repoEmployee.Create(employee);
            _unitOfWork.SaveChanges();
            return employee.Id;
        }

        public bool DeleteEmployee(int employeeId)
        {
            var dbEntry = _repoEmployee.Read<IEmployeeSpecification>()
                .WithEmployeeId(employeeId)
                .ToResult().SingleOrDefault();

            if (dbEntry == null)
            {
                HasErrors = true;
                Errors.Add("Invalid employee");
                return false;
            }

            _repoEmployee.Delete(dbEntry);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
