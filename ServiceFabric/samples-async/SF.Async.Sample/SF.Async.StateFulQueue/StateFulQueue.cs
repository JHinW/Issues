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

namespace SF.Async.StateFulQueue
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class StateFulQueue : StatefulService, IQueue<IMessageWrapper>
    {

        private IReliableQueue<IMessageWrapper> reliableQueue;

        private IReliableDictionary<string, TaskCompletionSource<IMessageWrapper>> reliableDictionary;

        public StateFulQueue(StatefulServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            yield return new ServiceReplicaListener(context => {

                return new FabricTransportServiceRemotingListener(context, new OccupantImpl(this));
            }, "StateFulQueueFabricTransportServiceRemotingListener");
        }

        /// <summary>
        /// This is the main entry point for your service replica.
        /// This method executes when this replica of your service becomes primary and has write status.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service replica.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following sample code with your own logic 
            //       or remove this RunAsync override if it's not needed in your service.

            reliableQueue = await this.StateManager.GetOrAddAsync<IReliableQueue<IMessageWrapper>>("queue");
            reliableDictionary = await this.StateManager.GetOrAddAsync<IReliableDictionary<string, TaskCompletionSource<IMessageWrapper>>>("eventDictionary");


            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                IMessageWrapper context = null;

                using (var tx = this.StateManager.CreateTransaction())
                {
                    var result = await reliableQueue.TryDequeueAsync(tx);
                    context = result.HasValue ? result.Value : null; 
                    
                    // If an exception is thrown before calling CommitAsync, the transaction aborts, all changes are 
                    // discarded, and nothing is saved to the secondary replicas.
                    await tx.CommitAsync();

                    if(context != null)
                    {
                        var signalPack = await reliableDictionary.TryGetValueAsync(tx, context.AsyncSignalRefKey);
                        context.Signal = signalPack.Value;
                    }

                    ServiceEventSource.Current.ServiceMessage(this.Context, "Current Counter Value: {0}",
                        result.HasValue ? result.Value.ToString() : "Value does not exist.");
                    
                }

                if (context != null)
                {


                    try
                    {
                        

                    }
                    catch (Exception e)
                    {
                        context.HasException = true;
                        context.MessageRes = e.ToString();
                        context.Signal.SetResult(context);
                    }
                }



                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }

        public async Task<TaskCompletionSource<IMessageWrapper>> EnqueueAsync(IMessageWrapper messageWrapper)
        {
            using (var tx = this.StateManager.CreateTransaction())
            {
                var signal = new TaskCompletionSource<IMessageWrapper>();
                await this.reliableDictionary.AddAsync(tx, messageWrapper.AsyncSignalRefKey, signal);
                await this.reliableQueue.EnqueueAsync(tx, messageWrapper);
                await tx.CommitAsync();
                return signal;
            }
        }

        public Task<TaskCompletionSource<IMessageWrapper>> DequeueAsync()
        {
            return null;
        }

        public Task<TaskCompletionSource<IMessageWrapper>> PeekAsync()
        {
            return null;
        }
    }
}
