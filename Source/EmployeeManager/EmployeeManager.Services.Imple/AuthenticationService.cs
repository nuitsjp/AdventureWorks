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
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ManagedEmployeeDao _managedEmployeeDao;

        public AuthenticationService(ManagedEmployeeDao managedEmployeeDao)
        {
            _managedEmployeeDao = managedEmployeeDao;
        }

        public virtual ManagedEmployee Authenticate()
        {
            var name = ServiceSecurityContext.Current.WindowsIdentity.Name;
            return Mapper.Map<ManagedEmployee>(_managedEmployeeDao.FindByLoginID(name));
        }
    }
}
