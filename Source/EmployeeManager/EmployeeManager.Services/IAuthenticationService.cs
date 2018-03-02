using System.ServiceModel;

namespace AdventureWorks.EmployeeManager.Services
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        ManagedEmployee Authenticate();
    }
}