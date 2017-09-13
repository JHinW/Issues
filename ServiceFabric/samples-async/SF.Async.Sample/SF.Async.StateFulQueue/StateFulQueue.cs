using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using SF.Async.Operation.Common;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Runtime;
using SF.Async.StateFul.Services;
using SF.Async.Operation.Common.Abstractions;
using SF.Async.Operation.Usage;

namespace SF.Async.StateFulQueue
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class StateFulQueue : StateFulDefaultBase
    {
        public StateFulQueue(StatefulServiceContext context, IServiceEvent eventsource, ILogicEntry entry)
            : base(context, eventsource, entry)
        {
        }

    }
}
