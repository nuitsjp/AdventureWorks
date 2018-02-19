using System.Collections.Generic;
using System.Data;
using Dapper.FastCrud;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public class EmployeeDao
    {
        public IEnumerable<Employee> GetEmployees(IDbConnection connection)
        {
            return connection.Find<Employee>();
        }
    }
}