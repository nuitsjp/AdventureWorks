using AdventureWorks.EmployeeManager.Services;

namespace AdventureWorks.EmployeeManager.Usecases
{
    public class Login : ILogin
    {
        private readonly IAuthenticationService _authenticationService;
        public ManagedEmployee Current { get; private set; }

        public Login(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public bool Authenticate()
        {
            Current = _authenticationService.Authenticate();
            return Current != null;
        }
    }
}
