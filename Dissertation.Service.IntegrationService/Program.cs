using Common.Logging;
using Dissertation.Service.IntegrationService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Service.IntegrationService
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
#if DEBUG
            IntegrationService service = new IntegrationService();
            service.OnDebug();
            //System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new IntegrationService()
            };
            ServiceBase.Run(ServicesToRun);
#endif

        }
    }
}
