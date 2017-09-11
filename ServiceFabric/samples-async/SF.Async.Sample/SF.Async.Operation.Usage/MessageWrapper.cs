using SF.Async.Operation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Usage
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
