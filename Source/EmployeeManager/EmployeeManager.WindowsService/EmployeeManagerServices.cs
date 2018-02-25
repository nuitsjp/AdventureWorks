using System.ServiceModel;
using System.ServiceProcess;
using AdventureWorks.EmployeeManager.Services.Imple;
using SimpleInjector.Integration.Wcf;

namespace AdventureWorks.EmployeeManager.WindowsService
{
    public partial class EmployeeManagerServices : ServiceBase
    {
        private EmployeeServiceHost ServiceHost { get; set; }
        public EmployeeManagerServices()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceHost = new EmployeeServiceHost();
            ServiceHost.Open();
        }

        protected override void OnStop()
        {
            ServiceHost.Dispose();
            ServiceHost = null;
        }
    }
}
