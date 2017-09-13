using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using SF.Async.Operation.Usage;
using System;
using System.Threading;

namespace WebApp
{

    // using OccupantService = OccupantBase<string, string>;

    public static class extension
    {

        public static IOccupantService GetStateFulService(this Controller ctrl, Uri serviceName)
        {
            IOccupantService queueService = null;

            while (queueService == null)
            {
                try
                {
                    queueService = ServiceProxy.Create<IOccupantService>(serviceName, new ServicePartitionKey(1));
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
