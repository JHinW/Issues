using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    [DataContract(Name = "MessageContext")]
    [KnownType(typeof(IMessageContext))]
    public class MessageContext : IMessageContext
    {
        public string AsyncSignalRefKey { get; set; }

        [IgnoreDataMember]
        public ISignalSource SignalSource { get; set; }

        public Boolean HasException { get; set; } = false;

        public string MessageBody { get; set; }

        public string MessageRes { get; set; }
    }
}
