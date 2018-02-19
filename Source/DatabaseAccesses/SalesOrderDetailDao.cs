using System.Collections.Generic;
using System.Data;
using Dapper.FastCrud;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public class SalesOrderDetailDao
    {
        public IEnumerable<SalesOrderDetail> GetAll(IDbConnection connection)
        {
            return connection.Find<SalesOrderDetail>();
        }
    }
}