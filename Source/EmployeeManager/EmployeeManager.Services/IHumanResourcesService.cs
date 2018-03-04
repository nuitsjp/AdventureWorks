using System.Collections.Generic;
using System.ServiceModel;

namespace AdventureWorks.EmployeeManager.Services
{
    [ServiceContract]
    public interface IHumanResourcesService
    {
        [OperationContract]
        IList<ManagedEmployee> GetManagedEmployees();

        [OperationContract]
        IList<Gender> GetGenders();

        [OperationContract]
        IList<MaritalStatus> GetMaritalStatuses();

        [OperationContract]
        void ModifyManagedEmployees(IList<ManagedEmployee> updatedEmployees, IList<ManagedEmployee> newEmployees);
    }
}