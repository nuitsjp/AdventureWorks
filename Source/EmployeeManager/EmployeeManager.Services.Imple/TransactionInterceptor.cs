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
            for (var i = 1; ; i++)
            {
                try
                {
                    using (var transaction = _transactionContext.Open())
                    {
                        invocation.Proceed();
                        transaction.Complete();
                        break;
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    // デッドロックで、最大リトライ回数を超えていない場合は再実行する
                    // それ以外は例外をスローする
                    if (ex.Number != 1205 || i == DefaultMaxRetryCount) throw;
                }
            }
        }
    }
}
