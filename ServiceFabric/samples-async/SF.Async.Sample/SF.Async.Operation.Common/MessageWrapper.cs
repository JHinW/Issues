using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    [DataContract]
    public class MessageWrapper
    {
        public string AsyncSignalRefKey { get; set; }

        [IgnoreDataMember]
        public TaskCompletionSource<MessageWrapper> Signal { get; set; }

        public Boolean HasException { get; set; } = false;

        public string MessageBody { get; set; }

        public string MessageRes { get; set; }
    }
}
