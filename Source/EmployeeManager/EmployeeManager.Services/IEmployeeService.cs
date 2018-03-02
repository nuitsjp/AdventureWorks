using System.Collections.Generic;
using System.ServiceModel;

namespace AdventureWorks.EmployeeManager.Services
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        IEnumerable<ManagedEmployee> GetManagedEmployees();
    }
}