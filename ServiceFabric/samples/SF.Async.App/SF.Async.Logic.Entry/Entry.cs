using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using SF.Async.Logic.Interfaces;
using SF.Async.Interfaces;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SF.Async.Logic.Entry
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class Entry : StatefulService, IEntry
    {
        public Entry(StatefulServiceContext context)
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
            return new ServiceReplicaListener[0];
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

            var myDictionary = await this.StateManager.GetOrAddAsync<IReliableDictionary<string, long>>("myDictionary");

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var tx = this.StateManager.CreateTransaction())
                {
                    var result = await myDictionary.TryGetValueAsync(tx, "Counter");

                    ServiceEventSource.Current.ServiceMessage(this.Context, "Current Counter Value: {0}",
                        result.HasValue ? result.Value.ToString() : "Value does not exist.");

                    await myDictionary.AddOrUpdateAsync(tx, "Counter", 0, (key, value) => ++value);

                    // If an exception is thrown before calling CommitAsync, the transaction aborts, all changes are 
                    // discarded, and nothing is saved to the secondary replicas.
                    await tx.CommitAsync();
                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }

        Task<object> ILuisService.GetIntention(string text)
        {
            // message wrapper
            var wrapper = MessageWrapper.CreateMessageWrapper(text);

            throw new NotImplementedException();
        }

        Task<byte[]> IAudioService.Pcm2Wav(byte[] pcmBytes)
        {
            var wrapper = MessageWrapper.CreateMessageWrapper(pcmBytes);

            throw new NotImplementedException();
        }

        Task<object> ISpeechService.SendAudio(byte[] wavBytes, int length)
        {
            var wrapper = MessageWrapper.CreateMessageWrapper(wavBytes);
            throw new NotImplementedException();
        }

        Task<byte[]> IAudioService.Silk2Pcm(byte[] silkBytes)
        {
            var wrapper = MessageWrapper.CreateMessageWrapper(silkBytes);
            throw new NotImplementedException();
        }
    }
}
