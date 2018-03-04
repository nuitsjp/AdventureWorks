using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using AdventureWorks.EmployeeManager.Usecases;
using AutoMapper;
using Prism.Regions;
using PropertyChanged;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ManagedEmployeeListViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IManageEmployees _manageEmployees;

        public IEnumerable<Gender> Genders { get; private set; }

        public IEnumerable<MaritalStatus> MaritalStatuses { get; private set; }

        public ObservableCollection<ManagedEmployeeViewModel> ManagedEmployees { get; } = new ObservableCollection<ManagedEmployeeViewModel>();

        public bool IsReadOnly { get; set; } = true;

        public ICommand InitializeCommand => new DelegateCommand(OnInitialize);

        public ICommand PopCommand { get; }

        public ReactiveCommand EditCommand { get; }

        public ReactiveCommand SaveCommand { get; }

        public ReactiveCommand AddToListCommand { get; }

        public ManagedEmployeeListViewModel(IManageEmployees manageEmployees, IRegionManager regionManager)
        {
            _manageEmployees = manageEmployees;
            _regionManager = regionManager;

            PopCommand = new DelegateCommand(() => Pop(_regionManager));

            EditCommand = this.ObserveProperty(x => x.IsReadOnly).ToReactiveCommand();
            EditCommand.Subscribe(() => IsReadOnly = false);

            SaveCommand = this.ObserveProperty(x => x.IsReadOnly).Select(x => !x).ToReactiveCommand();
            SaveCommand.Subscribe(OnSave);

            AddToListCommand = this.ObserveProperty(x => !x.IsReadOnly).Select(x => !x).ToReactiveCommand();
            AddToListCommand.Subscribe(OnAddToList);
        }

        private void OnInitialize()
        {
            Genders = _manageEmployees.GetGenders().OrderBy(x => x.Code);
            MaritalStatuses = _manageEmployees.GetMaritalStatuses().OrderBy(x => x.Code);

            var managedEmployees = _manageEmployees.GetManagedEmployees();
            foreach (var managedEmployee in managedEmployees)
            {
                ManagedEmployees.Add(new ManagedEmployeeViewModel(managedEmployee));
            }
        }

        private void OnSave()
        {
            var updatedEmployees = 
                ManagedEmployees
                    .Where(x => x.EditStatus == EditStatus.Updated)
                    .Select(x =>
                    {
                        x.Commit();
                        return x.ManagedEmployee;
                    })
                    .ToList();
            var newEmployees =
                ManagedEmployees
                    .Where(x => x.EditStatus == EditStatus.Created)
                    .Select(x =>
                    {
                        x.Commit();
                        return x.ManagedEmployee;
                    })
                    .ToList();
            _manageEmployees.ModifyManagedEmployees(updatedEmployees, newEmployees);
            IsReadOnly = true;
        }

        private void OnAddToList()
        {
            ManagedEmployees.Add(new ManagedEmployeeViewModel());
        }
    }
}
