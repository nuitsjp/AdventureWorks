namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    public interface IMonitorPropertyUpdated
    {
        EditStatus EditStatus { get; }
        void OnUpdateProperty();
    }
}