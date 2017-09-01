using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces
{
    /// <summary>
    /// new MessageContext for message treansfer.
    /// </summary>
    [DataContract]
    public abstract class MessageContext
    {
        /// <summary>
        ///  for reference history
        /// </summary>
        [DataMember]
        public abstract ServiceReferenceWrapper ServiceReferenceWrapper { get; }

        /// <summary>
        /// inputmessage entity(serialized already)
        /// </summary>
        [DataMember]
        public abstract MessageWrapper InputMessage { get; }

        /// <summary>
        /// outputmessage entity(serialized already)
        /// </summary>
        public abstract MessageWrapper OutputMessage { get; }

    }
}
