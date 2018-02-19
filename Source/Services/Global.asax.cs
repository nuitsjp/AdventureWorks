using System.Web.Http;

namespace AdventureWorks.EmployeeManager.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Register();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
