using System.Collections.Generic;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AuthContext _authContext;

        public EmployeeService(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public virtual ManagedEmployee Authenticate()
        {
            return _authContext.Current;
        }

        public virtual IEnumerable<ManagedEmployee> GetManagedEmployees()
        {
            throw new System.NotImplementedException();
        }
    }
}