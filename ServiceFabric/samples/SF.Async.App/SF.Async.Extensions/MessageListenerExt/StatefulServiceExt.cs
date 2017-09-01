using Microsoft.ServiceFabric.Services.Communication.Runtime;
using SF.Async.Abstractions.MessageListener;
using SF.Async.Interfaces;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Query;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Extensions.MessageListenerExt
{
    public static class StatefulServiceExt
    {
        public static ICommunicationListener CreateReplicaMessageListener<Tservice>(
            this StatefulService statefulService,
            ServiceContext serviceContext,
            Tservice instance
            ) where Tservice : class, IAsync
        {
            return new MessageListner<Tservice>(instance, serviceContext);
        }

        public static ICommunicationListener CreateInstanceMessageListener<Tservice>(
            this StatelessService statelessService,
            ServiceContext serviceContext,
            Tservice instance
            ) where Tservice : class, IAsync
        {
            return new MessageListner<Tservice>(instance, serviceContext);
        }
    }
}
