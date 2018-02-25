namespace AdventureWorks.EmployeeManager.Usecases
{
    public interface ILogin
    {
        ManagedEmployee Current { get; }
        bool Authenticate();
    }
}