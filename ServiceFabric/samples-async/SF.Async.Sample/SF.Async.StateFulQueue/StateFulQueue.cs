using SF.Async.Core;
using SF.Async.Operation.Common;
using SF.Async.Operation.Common.Abstractions;
using SF.Async.Operation.Usage;
using SF.Async.Usage;
using System.Fabric;

namespace SF.Async.StateFulQueue
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    public class StateFulQueue : StateFulDefaultUsage
    {
        public StateFulQueue(StatefulServiceContext context, Core.IServiceEvent eventsource, IFollowing entry)
            : base(context, eventsource, entry)
        {
        }

    }
}
