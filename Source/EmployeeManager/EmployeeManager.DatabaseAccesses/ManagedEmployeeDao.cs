using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.EmployeeManager.Transaction;
using Dapper.FastCrud;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public class ManagedEmployeeDao
    {
        private readonly ITransactionContext _transactionContext;

        private IDbConnection Connection => _transactionContext.Connection;

        public ManagedEmployeeDao(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public virtual ManagedEmployee FindByLoginID(string loginID)
        {
            return Connection.Find<ManagedEmployee>(statement =>
                statement
                    .Where($"{nameof(ManagedEmployee.LoginID)} = '{loginID}'")
            ).SingleOrDefault();
        }
    }
}
