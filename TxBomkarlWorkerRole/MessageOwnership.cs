using System;
using Rebus;

namespace TxBomkarlWorkerRole
{
    public class MessageOwnership : IDetermineMessageOwnership
    {
        public string GetEndpointFor(Type messageType)
        {
            return "i";
        }
    }
}