using PropertyChanged;

namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MonitorPropertyUpdatedObject : IMonitorPropertyUpdated
    {
        public EditStatus EditStatus { get; private set; }

        public void OnUpdateProperty()
        {
            if (EditStatus != EditStatus.Created)
                EditStatus = EditStatus.Updated;
        }

        protected void SetEditStatus(EditStatus editStatus)
        {
            EditStatus = editStatus;
        }

    }
}