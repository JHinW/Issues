using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Runtime;
using SF.Async.Interfaces;
using System;
using System.Fabric;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;

namespace SF.Async.Abstractions.MessageListener
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageListner<TInterfaces> : WcfCommunicationListener<TInterfaces> where TInterfaces: class, IAsync
    {
        /// <summary>
        ///  The name of the endpoint configured in the ServiceManifest under the Endpoints section
        ///  that identifies the endpoint that the WCF ServiceHost should listen on.
        /// </summary>
        public const string EndpointResourceName = "WcfServiceEndpoint";

        /// <summary>
        ///  Creates a new Binding to use
        /// </summary>
        /// <returns></returns>
        public static Binding CreateBinding()
        {
            return BindingFactory.CreateBinding();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="serviceContext"></param>
        public MessageListner(TInterfaces instance, 
            ServiceContext serviceContext
            ):base(serviceContext, 
                instance,
                CreateBinding(),
                EndpointResourceName
                )
        {
        }
    }

}