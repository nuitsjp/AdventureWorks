using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using AutoMapper;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class AuthContext
    {
        private readonly ManagedEmployeeDao _managedEmployeeDao;

        internal ManagedEmployee Current { get; private set; }

        public AuthContext(ManagedEmployeeDao managedEmployeeDao)
        {
            _managedEmployeeDao = managedEmployeeDao;
        }

        internal bool Authenticate()
        {
            var name = ServiceSecurityContext.Current.WindowsIdentity.Name;
            var employee = _managedEmployeeDao.FindByLoginID(name);
            if (employee == null) return false;

            Current = Mapper.Map<ManagedEmployee>(employee);
            return true;
        }
    }
}
