using System;

namespace AdventureWorks.EmployeeManager.DatabaseAccesses
{
    public interface ITransaction : IDisposable
    {
        void Complete();
    }
}