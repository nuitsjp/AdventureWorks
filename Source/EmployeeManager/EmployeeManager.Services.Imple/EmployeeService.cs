using System.Collections.Generic;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using AutoMapper;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ManagedEmployeeDao _managedEmployeeDao;

        public EmployeeService(ManagedEmployeeDao managedEmployeeDao)
        {
            _managedEmployeeDao = managedEmployeeDao;
        }

        public virtual IList<ManagedEmployee> GetManagedEmployees()
        {
            var result = new List<ManagedEmployee>();
            foreach (var managedEmployee in _managedEmployeeDao.GetManagedEmployees())
            {
                result.Add(Mapper.Map<ManagedEmployee>(managedEmployee));
            }
            return result;
        }
    }
}