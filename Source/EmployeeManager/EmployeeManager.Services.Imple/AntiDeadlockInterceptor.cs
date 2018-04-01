using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class AntiDeadlockInterceptor : IInterceptor
    {
        public const int DefaultMaxRetryCount = 5;

        public static int MaxRetryCount { get; set; } = DefaultMaxRetryCount;

        public void Intercept(IInvocation invocation)
        {
            for (var i = 1; ; i++)
            {
                try
                {
                    invocation.Proceed();
                    break;
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
