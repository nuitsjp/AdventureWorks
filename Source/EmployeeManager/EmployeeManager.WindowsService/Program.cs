using System.ServiceProcess;

namespace AdventureWorks.EmployeeManager.WindowsService
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new EmployeeManagerServices()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
