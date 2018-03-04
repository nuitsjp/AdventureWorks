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

        public virtual Employee FindById(int businessEntityID)
            => _transactionContext.Connection.Get(new Employee {BusinessEntityID = businessEntityID});

        public virtual void Update(Employee employee)
            => _transactionContext.Connection.Update(employee);

        public virtual void Insert(Employee employee)
            => _transactionContext.Connection.Insert(employee);
    }
}
