using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
