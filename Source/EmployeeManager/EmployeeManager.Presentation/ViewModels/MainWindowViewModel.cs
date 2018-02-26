using System.Windows.Input;
using AdventureWorks.EmployeeManager.Presentation.Views;
using AdventureWorks.EmployeeManager.Usecases;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ILogin _login;

        private readonly IRegionManager _regionManager;

        public ICommand AuthenticateCommand => new DelegateCommand(Authenticate);

        public MainWindowViewModel(ILogin login, IRegionManager regionManager)
        {
            _login = login;
            _regionManager = regionManager;
        }

        private void Authenticate()
        {
            if (_login.Authenticate())
            {
                RequestNavigate<MenuViewModel>(_regionManager);
            }
            else
            {
                RequestNavigate<ErrorViewModel>(_regionManager);
            }
        }
    }
}
