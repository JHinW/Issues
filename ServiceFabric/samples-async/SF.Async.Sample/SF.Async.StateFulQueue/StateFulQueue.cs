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
    internal sealed class StateFulQueue : StatefulService, IQueue<MessageWrapper>
    {

        private IReliableQueue<MessageWrapper> reliableQueue;

        private IReliableDictionary<string, TaskCompletionSource<MessageWrapper>> reliableDictionary;

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

            reliableQueue = await this.StateManager.GetOrAddAsync<IReliableQueue<MessageWrapper>>("queue");
            reliableDictionary = await this.StateManager.GetOrAddAsync<IReliableDictionary<string, TaskCompletionSource<MessageWrapper>>>("eventDictionary");


            var entry = new EntryBuilder()
                .UseComp(next => context => {
                    context.MessageRes = "weee";
                    context.SignalSource.SetResult(context);
                    return Task.CompletedTask;
                })
                .Build();

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                MessageWrapper context = null;

                using (var tx = this.StateManager.CreateTransaction())
                {
                    var result = await reliableQueue.TryDequeueAsync(tx);
                    context = result.HasValue ? result.Value : null; 
                    
                    // If an exception is thrown before calling CommitAsync, the transaction aborts, all changes are 
                    // discarded, and nothing is saved to the secondary replicas.
                    

                    if(context != null)
                    {
                        var signalPack = await reliableDictionary.TryGetValueAsync(tx, context.AsyncSignalRefKey);
                        context.SignalSource = new SignalSource(signalPack.Value);
                    }

                    await tx.CommitAsync();

                    ServiceEventSource.Current.ServiceMessage(this.Context, "Current Counter Value: {0}",
                        result.HasValue ? result.Value.ToString() : "Value does not exist.");
                    
                }

                if (context != null)
                {
                    try
                    {
                        await entry.SendAsync(context);
                    }
                    catch (Exception e)
                    {
                        context.HasException = true;
                        context.MessageRes = e.ToString();
                        context.SignalSource.SetResult(context);
                    }
                }



                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }

        public async Task<TaskCompletionSource<MessageWrapper>> EnqueueAsync(MessageWrapper messageWrapper)
        {                                                                           
            using (var tx = this.StateManager.CreateTransaction())
            {
                try
                {
                    var signal = new TaskCompletionSource<MessageWrapper>();
                    await this.reliableDictionary.AddAsync(tx, messageWrapper.AsyncSignalRefKey, signal);
                    await this.reliableQueue.EnqueueAsync(tx, messageWrapper);
                    await tx.CommitAsync();
                    return signal;

                }     catch(Exception e)
                {
                    throw e;
                }
                
            }
        }

        public async Task<MessageWrapper> DequeueAsync()
        {
            using (var tx = this.StateManager.CreateTransaction())
            {
                var result = await reliableQueue.TryDequeueAsync(tx);
                var context = result.HasValue ? result.Value : null;
                return context;
            }
        }

        public Task<MessageWrapper> PeekAsync()
        {
            return null;
        }
    }
}
