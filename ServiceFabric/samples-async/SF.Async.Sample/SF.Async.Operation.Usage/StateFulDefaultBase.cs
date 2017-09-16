using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using SF.Async.Operation.Common;
using SF.Async.Operation.Common.Abstractions;
using SF.Async.Operation.Common.Base;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;

namespace SF.Async.Operation.Usage
{
    public abstract class StateFulDefaultBase: StatefulService, IQueue<IMessageContext>
    {

        private IReliableQueue<MessageWrapper> _reliableQueue;

        private IReliableDictionary<string, TaskCompletionSource<IMessageContext>> _reliableDictionary;

        private IMessageEntry _messageEntry;

        private IServiceEvent _serviceEvent;


        public StateFulDefaultBase(StatefulServiceContext context, IServiceEvent eventsource, IMessageEntry messageEntry)
            : base(context)
        {
            _serviceEvent = eventsource;
            _messageEntry = messageEntry;
        }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            yield return new ServiceReplicaListener(context =>
            {

                return new FabricTransportServiceRemotingListener(context, new StateFulDefaultOccupantService(this));
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

            _reliableQueue = await this.StateManager.GetOrAddAsync<IReliableQueue<MessageWrapper>>("queue");
            _reliableDictionary = await this.StateManager.GetOrAddAsync<IReliableDictionary<string, TaskCompletionSource<IMessageContext>>>("eventDictionary");

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                MessageWrapper messageWrapper = null;

                using (var tx = this.StateManager.CreateTransaction())
                {
                    var result = await _reliableQueue.TryDequeueAsync(tx);
                    messageWrapper = result.HasValue ? result.Value : null;

                    // If an exception is thrown before calling CommitAsync, the transaction aborts, all changes are 
                    // discarded, and nothing is saved to the secondary replicas.

                    if (messageWrapper != null)
                    {
                        var context = messageWrapper.MessageContext;
                        var signalPack = await _reliableDictionary.TryGetValueAsync(tx, context.AsyncSignalRefKey);
                        context.SignalSource = new SignalSource(signalPack.Value);
                    }

                    await tx.CommitAsync();

                    /*ServiceEventSource.Current.ServiceMessage(this.Context, "Current Counter Value: {0}",
                        result.HasValue ? result.Value.ToString() : "Value does not exist.");
                        */
                    _serviceEvent.LogEvents($"Current Counter Value: { (result.HasValue ? result.Value.ToString(): "") } Value does not exist.");



                }

                if (messageWrapper != null)
                {
                    var context = messageWrapper.MessageContext;
                    try
                    {
                        await _messageEntry.SendAsync(context);
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

        public async Task<IMessageContext> EnqueueAsync(IMessageContext messageWrapper)
        {
            using (var tx = this.StateManager.CreateTransaction())
            {
                try
                {
                    var signal = new TaskCompletionSource<IMessageContext>();
                    await _reliableDictionary.AddAsync(tx, messageWrapper.AsyncSignalRefKey, signal);
                    await _reliableQueue.EnqueueAsync(tx,
                        new MessageWrapper
                        {
                            MessageContext = messageWrapper
                        });
                    await tx.CommitAsync();
                    var ret = await signal.Task;
                    return ret;

                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }

        public async Task<IMessageContext> DequeueAsync()
        {
            using (var tx = this.StateManager.CreateTransaction())
            {
                var result = await _reliableQueue.TryDequeueAsync(tx);
                var context = result.HasValue ? result.Value : null;
                return context.MessageContext;
            }
        }

        public Task<IMessageContext> PeekAsync()
        {
            return null;
        }
    }
}
