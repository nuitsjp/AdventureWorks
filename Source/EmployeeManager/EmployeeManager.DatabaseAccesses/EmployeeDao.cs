using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FastCrud;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public class EmployeeDao
    {
        private readonly ITransactionContext _transactionContext;

        public EmployeeDao(ITransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public virtual Employee FindByLoginID(string loginID)
        {
            return _transactionContext.Connection.Find<Employee>(statement =>
                statement
                    .Where($"{nameof(Employee.LoginID)} = '{loginID}'")
            ).SingleOrDefault();
        }
    }
}
