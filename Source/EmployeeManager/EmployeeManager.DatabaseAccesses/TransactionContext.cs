using System;
using System.Data;

namespace AdventureWorks.EmployeeManager.Transaction
{
    public class TransactionContext : ITransactionContext
    {
        private static Func<IDbConnection> _openConnection;
        public IDbConnection Connection { get; private set; }

        public static void SetOpenConnection(Func<IDbConnection> openConnection) => _openConnection = openConnection;

        public IDisposable Open()
        {
            Connection = _openConnection();
            return Connection;
        }
    }
}
