using System;
using System.Data;

namespace AdventureWorks.EmployeeManager.Transaction
{
    public interface ITransactionContext
    {
        IDbConnection Connection { get; }

        IDisposable Open();
    }
}