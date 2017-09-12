using System;
using System.Runtime.Serialization;

namespace SF.Async.Operation.Common
{
    [DataContract(Name= "MessageWrapper")]
    [KnownType(typeof(MessageWrapper))]
    public class MessageWrapper: IMessageWrapper
    {
        [DataMember]
        public string AsyncSignalRefKey { get; set; }

        [IgnoreDataMember]
        public ISignalSource SignalSource { get; set; }

        [DataMember]
        public Boolean HasException { get; set; } = false;

        [DataMember]
        public string MessageBody { get; set; }

        [DataMember]
        public string MessageRes { get; set; }
    }
}
