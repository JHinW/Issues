using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using SF.Async.Core;
using SF.Async.Operation.Usage;
using System;
using System.Threading;

namespace WebApp
{

    // using OccupantService = OccupantBase<string, string>;

    public static class Extension
    {

        public static ITransferer GetStateFulService(this Controller ctrl, Uri serviceName)
        {
            ITransferer queueService = null;

            while (queueService == null)
            {
                try
                {
                    queueService = ServiceProxy.Create<ITransferer>(serviceName, new ServicePartitionKey(1));
                }
                catch
                {
                    Thread.Sleep(200);
                }
            }

            return queueService;
        }
    }
}
