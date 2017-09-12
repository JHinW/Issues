using System;
using System.Runtime.Serialization;

namespace SF.Async.Operation.Common
{
    [DataContract(Name= "MessageWrapper")]
    [KnownType(typeof(MessageWrapper))]
    public class MessageWrapper
    {
        public IMessageContext MessageContext { get; set; }
    }
}
