using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using Castle.DynamicProxy;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class ServiceInterceptor : IInterceptor
    {
        private readonly ITransactionContext _transactionContext;

        private readonly AuthContext _authContext;

        public ServiceInterceptor(ITransactionContext transactionContext, AuthContext authContext)
        {
            _transactionContext = transactionContext;
            _authContext = authContext;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var connection = _transactionContext.Open())
            {
                invocation.Proceed();
                connection.Complete();
            }
        }
    }
}
