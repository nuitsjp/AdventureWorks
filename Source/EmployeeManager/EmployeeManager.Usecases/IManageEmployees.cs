using System.Collections.Generic;

namespace AdventureWorks.EmployeeManager.Usecases
{
    public interface IManageEmployees
    {
        IEnumerable<ManagedEmployee> GetManagedEmployees();
    }
}