using System;
using System.Data;
using System.Transactions;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public class TransactionContext : ITransactionContext
    {
        private static Func<IDbConnection> _openConnection;

        private TransactionScope _transactionScope;
        public IDbConnection Connection { get; private set; }

        public static void SetOpenConnection(Func<IDbConnection> openConnection) => _openConnection = openConnection;

        public ITransaction Open()
        {
            _transactionScope = new TransactionScope();
            try
            {
                Connection = _openConnection();
                return new Transaction(_transactionScope.Complete, Close);
            }
            catch (Exception)
            {
                _transactionScope.Dispose();
                _transactionScope = null;
                throw;
            }
        }

        private void Close()
        {
            _transactionScope.Dispose();
            _transactionScope = null;
            Connection.Dispose();
            Connection = null;
        }

        class Transaction : ITransaction
        {
            private readonly Action _complete;
            private readonly Action _dispose;

            internal Transaction(Action complete, Action dispose)
            {
                _complete = complete;
                _dispose = dispose;
            }

            public void Complete() => _complete();
            public void Dispose() => _dispose();
        }
    }
}
