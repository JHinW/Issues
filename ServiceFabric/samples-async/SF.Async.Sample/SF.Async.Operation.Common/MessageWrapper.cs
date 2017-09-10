using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    [DataContract]
    public class MessageWrapper: IMessageWrapper
    {
        public string AsyncSignalRefKey { get; set; }

        [IgnoreDataMember]
        public TaskCompletionSource<IMessageWrapper> Signal { get; set; }

        public Boolean HasException { get; set; } = false;

        public string MessageBody { get; set; }

        public string MessageRes { get; set; }
    }
}
