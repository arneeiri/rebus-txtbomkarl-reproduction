using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rebus;
using Rebus.AzureServiceBus;
using Rebus.Castle.Windsor;
using Rebus.Configuration;
using TxBomkarlRepro.Messages;

namespace TxBomkarlRepro.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var windsorContainer = new WindsorContainer();
            windsorContainer.Install(new RebusInstaller());

            var bus = windsorContainer.Resolve<IBus>();
            bus.Send(new IdMessage {Id = Guid.NewGuid()});

            Console.ReadLine();
        }
    }

    public class RebusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            const string connectionString = "<your connection string>";

            Configure.With(new WindsorContainerAdapter(container))
                .Transport(x => x.UseAzureServiceBusInOneWayClientMode(connectionString))
                .MessageOwnership(x => x.Use(new MessageOwnership()))
                .CreateBus().Start();
        }
    }

    public class MessageOwnership : IDetermineMessageOwnership
    {
        public string GetEndpointFor(Type messageType)
        {
            return "i";
        }
    }
}
