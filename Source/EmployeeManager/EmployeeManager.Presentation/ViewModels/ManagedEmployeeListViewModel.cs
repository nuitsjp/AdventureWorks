using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AdventureWorks.EmployeeManager.Usecases;

namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    public class ManagedEmployeeListViewModel : ViewModelBase
    {
        private readonly IManageEmployees _manageEmployees;
        public ObservableCollection<ManagedEmployee> ManagedEmployees { get; } = new ObservableCollection<ManagedEmployee>();
        public ICommand AuthenticateCommand => new DelegateCommand(LoadEmployees);

        public ManagedEmployeeListViewModel(IManageEmployees manageEmployees)
        {
            _manageEmployees = manageEmployees;
        }

        private void LoadEmployees()
        {
            var managedEmployees = _manageEmployees.GetManagedEmployees();
            foreach (var managedEmployee in managedEmployees)
            {
                ManagedEmployees.Add(managedEmployee);
            }
        }
    }
}
