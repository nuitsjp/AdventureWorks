using System.Collections.Generic;
using Dapper.FastCrud;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public class MaritalStatusDao
    {
        private readonly ITransactionContext _transactionContext;

        public MaritalStatusDao(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public IEnumerable<MaritalStatu> GetMaritalStatuses() => _transactionContext.Connection.Find<MaritalStatu>();
    }
}