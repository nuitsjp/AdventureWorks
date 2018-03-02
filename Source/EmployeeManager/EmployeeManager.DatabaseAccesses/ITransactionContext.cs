using System.Data;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public interface ITransactionContext
    {
        IDbConnection Connection { get; }

        ITransaction Open();
    }
}