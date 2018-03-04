using System;
using Dapper.FastCrud;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public class BusinessEntityDao
    {
        private readonly ITransactionContext _transactionContext;

        public BusinessEntityDao(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public virtual BusinessEntity Insert()
        {
            var businessEntity = new BusinessEntity {ModifiedDate = DateTime.Now};
            _transactionContext.Connection.Insert(businessEntity);
            return businessEntity;
        }
    }
}