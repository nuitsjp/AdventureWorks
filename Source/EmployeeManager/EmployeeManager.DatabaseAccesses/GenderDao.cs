using System.Collections.Generic;
using System.Data;
using Dapper.FastCrud;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public class GenderDao
    {
        private readonly ITransactionContext _transactionContext;

        private IDbConnection Connection => _transactionContext.Connection;

        public GenderDao(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public IEnumerable<Gender> GetGenders() => Connection.Find<Gender>();
    }
}