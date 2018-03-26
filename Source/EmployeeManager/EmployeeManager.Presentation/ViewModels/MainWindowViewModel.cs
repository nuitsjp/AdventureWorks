using System.Windows.Input;
using AdventureWorks.EmployeeManager.Presentation.Views;
using AdventureWorks.EmployeeManager.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

        private readonly IRegionManager _regionManager;

        public ICommand AuthenticateCommand => new DelegateCommand(Authenticate);

        public MainWindowViewModel(IAuthenticationService authenticationService, IRegionManager regionManager)
        {
            _authenticationService = authenticationService;
            _regionManager = regionManager;
        }

        private void Authenticate()
        {
            if (_authenticationService.Authenticate())
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
