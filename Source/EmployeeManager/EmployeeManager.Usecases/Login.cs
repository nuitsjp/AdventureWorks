using AdventureWorks.EmployeeManager.Services;

namespace AdventureWorks.EmployeeManager.Usecases
{
    public class Login : ILogin
    {
        private readonly IAuthenticationService _authenticationService;

        public Login(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public bool Authenticate()
        {
            return _authenticationService.Authenticate();
        }
    }
}
