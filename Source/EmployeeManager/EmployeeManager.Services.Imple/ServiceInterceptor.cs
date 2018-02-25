using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using AdventureWorks.EmployeeManager.Transaction;
using Castle.DynamicProxy;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class ServiceInterceptor : IInterceptor
    {
        private readonly ITransactionContext _transactionContext;

        private readonly ManagedEmployeeDao _managedEmployeeDao;

        private readonly AuthContext _authContext;

        public ServiceInterceptor(ITransactionContext transactionContext, ManagedEmployeeDao managedEmployeeDao, AuthContext authContext)
        {
            _transactionContext = transactionContext;
            _managedEmployeeDao = managedEmployeeDao;
            _authContext = authContext;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var scope = new TransactionScope())
            using (var connection = _transactionContext.Open())
            {
                var authenticate = _authContext.Authenticate();
                var attribute = invocation.Method.GetCustomAttribute<AuthenticationNotRequiredAttribute>();

                if (authenticate || attribute != null)
                {
                    invocation.Proceed();
                }
                else
                {
                    throw new InvalidOperationException();
                }

                scope.Complete();
            }
        }
    }
}
