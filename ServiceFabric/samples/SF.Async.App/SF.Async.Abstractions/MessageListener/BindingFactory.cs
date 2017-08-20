using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Abstractions.MessageListener
{
    internal static class BindingFactory
    {
        public static Binding CreateBinding()
        {
            var binding = new NetTcpBinding(SecurityMode.None)
            {
                OpenTimeout = TimeSpan.FromSeconds(60),
                SendTimeout = TimeSpan.MaxValue,
                ReceiveTimeout = TimeSpan.MaxValue,
                CloseTimeout = TimeSpan.FromSeconds(60),
                MaxReceivedMessageSize = 1024 * 1024
            };

            binding.MaxBufferSize = (int)binding.MaxReceivedMessageSize;
            binding.MaxBufferPoolSize = Environment.ProcessorCount * binding.MaxReceivedMessageSize;

            return binding;
        }
    }
}
