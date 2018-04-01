using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using Castle.DynamicProxy;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class TransactionInterceptor : IInterceptor
    {
        public const int DefaultMaxRetryCount = 5;

        public static int MaxRetryCount { get; set; } = DefaultMaxRetryCount;

        private readonly ITransactionContext _transactionContext;

        public TransactionInterceptor(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var transaction = _transactionContext.Open())
            {
                invocation.Proceed();
                transaction.Complete();
            }
        }
    }
}
