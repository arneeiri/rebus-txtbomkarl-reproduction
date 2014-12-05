using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rebus;
using Rebus.AzureServiceBus;
using Rebus.Castle.Windsor;
using Rebus.Configuration;

namespace TxBomkarlWorkerRole
{
    public class RebusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            const string connectionString = "<your connection string>";
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IHandleMessages<>)).WithService.AllInterfaces());
            Configure.With(new WindsorContainerAdapter(container))
                .Transport(x => x.UseAzureServiceBus(connectionString, "i", "e"))
                .MessageOwnership(x => x.Use(new MessageOwnership()))
                .CreateBus().Start();
        }
    }
}