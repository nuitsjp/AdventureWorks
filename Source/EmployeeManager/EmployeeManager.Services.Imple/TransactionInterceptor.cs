using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AdventureWorks.EmployeeManager.Transaction;
using Castle.DynamicProxy;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class TransactionInterceptor : IInterceptor
    {
        private readonly ITransactionContext _transactionContext;

        public TransactionInterceptor(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var scope = new TransactionScope())
            using (var disposable = _transactionContext.Open())
            {
                invocation.Proceed();
                scope.Complete();
            }
        }
    }
}
