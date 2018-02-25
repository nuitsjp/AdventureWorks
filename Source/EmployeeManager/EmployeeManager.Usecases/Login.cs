using AdventureWorks.EmployeeManager.Services;

namespace AdventureWorks.EmployeeManager.Usecases
{
    public class Login : ILogin
    {
        private readonly IEmployeeService _employeeService;
        public ManagedEmployee Current { get; private set; }

        public Login(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public bool Authenticate()
        {
            Current = _employeeService.Authenticate();
            return Current != null;
        }
    }
}
