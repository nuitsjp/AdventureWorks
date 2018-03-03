using System.Collections.Generic;
using AdventureWorks.EmployeeManager.Services;

namespace AdventureWorks.EmployeeManager.Usecases
{
    public class ManageEmployees : IManageEmployees
    {
        private readonly IEmployeeService _employeeService;

        public ManageEmployees(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<ManagedEmployee> GetManagedEmployees()
        {
            return _employeeService.GetManagedEmployees();
        }
    }
}