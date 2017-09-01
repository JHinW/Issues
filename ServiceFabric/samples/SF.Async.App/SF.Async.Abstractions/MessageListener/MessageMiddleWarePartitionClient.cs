using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using SF.Async.Interfaces;
using System;
using System.Fabric;

namespace SF.Async.Abstractions.MessageListener
{
    public class MessageMiddleWarePartitionClient<TService>: ServicePartitionClient<WcfCommunicationClient<TService>> where TService: class
    {
        private static readonly WcfCommunicationClientFactory<TService> _factory = new WcfCommunicationClientFactory<TService>(BindingFactory.CreateBinding());

        public static MessageMiddleWarePartitionClient<TService> Create(ServiceReference reference)
        {
            MessageMiddleWarePartitionClient<TService> client;
            switch (reference.PartitionKind)
            {
                case ServicePartitionKind.Singleton:
                    client = new MessageMiddleWarePartitionClient<TService>(_factory, reference.ServiceUri);
                    break;
                case ServicePartitionKind.Int64Range:
                    if (reference.PartitionID == null)
                        throw new InvalidOperationException("subscriberReference is missing its partition id.");
                    client = new MessageMiddleWarePartitionClient<TService>(_factory, reference.ServiceUri, reference.PartitionID.Value);
                    break;
                case ServicePartitionKind.Named:
                    client = new MessageMiddleWarePartitionClient<TService>(_factory, reference.ServiceUri, reference.PartitionName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return client;
        }

        public TService CreateInstance()
        {
            return InvokeWithRetry(client => client.Channel);
        }

        private MessageMiddleWarePartitionClient(ICommunicationClientFactory<WcfCommunicationClient<TService>> factory, Uri serviceName)
			: base(factory, serviceName)
		{
        }

        private MessageMiddleWarePartitionClient(ICommunicationClientFactory<WcfCommunicationClient<TService>> factory, Uri serviceName, string partitionKey)
			: base(factory, serviceName, new ServicePartitionKey(partitionKey))
		{
        }

        private MessageMiddleWarePartitionClient(ICommunicationClientFactory<WcfCommunicationClient<TService>> factory, Uri serviceName, long partitionKey)
			: base(factory, serviceName, new ServicePartitionKey(partitionKey))
		{
        }
    }
}
