using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Runtime;
using SF.Async.Usage;
using SF.Async.Usage.Extensions;

namespace SF.Async.StateFulQueue
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                // The ServiceManifest.XML file defines one or more service type names.
                // Registering a service maps a service type name to a .NET type.
                // When Service Fabric creates an instance of this service type,
                // an instance of the class is created in this host process.

                ServiceRuntime.RegisterServiceAsync(
                    "SF.Async.StateFulQueueType",
                    context => new StateFulDefaultUsageBuilder(context)
                    .ConfigureEntry(builder =>
                    {
                        builder.UseFollowerEx(message =>
                        {
                            message.BackResult(message.Immutables);
                            return Task.CompletedTask;
                        });
                    }).ConfigureLogger(logString =>
                    {
                        ServiceEventSource.Current.ServiceMessage(context, "Current Counter Value: {0}", logString);
                    })
                    .Build<StateFulQueue>()
                    ).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(StateFulQueue).Name);

                // Prevents this host process from terminating so services keep running.
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
