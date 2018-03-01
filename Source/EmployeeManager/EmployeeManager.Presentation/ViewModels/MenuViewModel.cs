using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Regions;

namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public ICommand NavigateManagedEmployeeListCommand { get; }

        public MenuViewModel(IRegionManager regionManager)
        {
            NavigateManagedEmployeeListCommand = 
                new DelegateCommand(() => RequestNavigate<ManagedEmployeeListViewModel>(regionManager));
        }
    }
}
