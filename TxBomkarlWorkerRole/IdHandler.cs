using System.Linq;
using Rebus;
using TxBomkarlRepro.Messages;

namespace TxBomkarlWorkerRole
{
    public class IdHandler : IHandleMessages<IdMessage>
    {
        public void Handle(IdMessage message)
        {
            using (var context = new TxBomkarlDbContext())
            {
                //Crashes here.
                context.Things.Where(t => t.Id == message.Id).ToArray();
            }
        }
    }
}