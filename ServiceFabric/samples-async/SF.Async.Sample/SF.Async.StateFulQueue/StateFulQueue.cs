using SF.Async.Operation.Common;
using SF.Async.Operation.Common.Abstractions;
using SF.Async.Operation.Usage;
using System.Fabric;

namespace SF.Async.StateFulQueue
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    public class StateFulQueue : StateFulDefaultBase
    {
        public StateFulQueue(StatefulServiceContext context, IServiceEvent eventsource, IMessageEntry entry)
            : base(context, eventsource, entry)
        {
        }

    }
}
