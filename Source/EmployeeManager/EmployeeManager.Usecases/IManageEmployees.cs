using System.Collections.Generic;

namespace AdventureWorks.EmployeeManager.Usecases
{
    public interface IManageEmployees
    {
        IEnumerable<Gender> GetGenders();
        IEnumerable<MaritalStatus> GetMaritalStatuses();
        IEnumerable<ManagedEmployee> GetManagedEmployees();
        void ModifyManagedEmployees(IList<ManagedEmployee> updatedEmployees, IList<ManagedEmployee> newEmployees);
    }
}