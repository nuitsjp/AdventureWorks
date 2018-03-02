using System.ServiceModel;
using System.ServiceProcess;
using AdventureWorks.EmployeeManager.Services.Imple;
using SimpleInjector.Integration.Wcf;

namespace AdventureWorks.EmployeeManager.WindowsService
{
    public partial class EmployeeManagerServices : ServiceBase
    {
        private SystemManagerServiceHosts ServiceHosts { get; set; }
        public EmployeeManagerServices()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceHosts = new SystemManagerServiceHosts();
            ServiceHosts.Open();
        }

        protected override void OnStop()
        {
            ServiceHosts.Dispose();
            ServiceHosts = null;
        }
    }
}
