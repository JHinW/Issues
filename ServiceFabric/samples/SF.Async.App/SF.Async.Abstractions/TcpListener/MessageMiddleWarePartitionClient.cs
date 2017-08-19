using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Abstractions.TcpListener
{
    public class MessageMiddleWarePartitionClient<TService>: ServicePartitionClient<WcfCommunicationClient<TService>> where TService: class
    {
        private static readonly WcfCommunicationClientFactory<TService> _factory = new WcfCommunicationClientFactory<TService>(BindingFactory.CreateBinding());

        public static MessageMiddleWarePartitionClient<TService> Create(Object references)
        {
            return null;
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
