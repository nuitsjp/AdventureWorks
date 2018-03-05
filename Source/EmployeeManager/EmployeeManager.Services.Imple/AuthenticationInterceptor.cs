using System.ServiceModel;
using System.ServiceModel.Security;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using Castle.DynamicProxy;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class AuthenticationInterceptor : IInterceptor
    {
        private readonly EmployeeDao _employeeDao;

        public AuthenticationInterceptor(EmployeeDao employeeDao)
        {
            _employeeDao = employeeDao;
        }

        public void Intercept(IInvocation invocation)
        {
            var name = ServiceSecurityContext.Current.WindowsIdentity.Name;
            if (_employeeDao.FindByLoginID(name) == null)
            {
                throw new SecurityAccessDeniedException();
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}