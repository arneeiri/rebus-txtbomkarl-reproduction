using System.Net;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace TxBomkarlWorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private WindsorContainer _windsorContainer;
        
        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;
            InitializeContainer();
            return base.OnStart();
        }

        private void InitializeContainer()
        {
            _windsorContainer = new WindsorContainer();
            _windsorContainer.Install(FromAssembly.Containing<RebusInstaller>());
        }
    }
}
