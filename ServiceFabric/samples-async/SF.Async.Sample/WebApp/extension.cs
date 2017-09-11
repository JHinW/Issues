using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using SF.Async.Operation.Common;
using SF.Async.Operation.Common.Abstractions;
using SF.Async.StateFul.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp
{

    using OccupantService = OccupantBase<string, string>;

    public static class extension
    {

        public static OccupantService GetStateFulService(this Controller ctrl, Uri serviceName)
        {
            OccupantService queueService = null;

            while (queueService == null)
            {
                try
                {
                    queueService = ServiceProxy.Create<OccupantService>(serviceName);
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
