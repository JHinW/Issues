using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces
{
    [DataContract]
    public partial class MessageWrapper
    {
        /// <summary>
		/// CLR Type Full Name of serialized payload.
		/// </summary>
		[DataMember]
        public string MessageType { get; set; }

        /// <summary>
        /// Serialized object.
        /// </summary>
        [DataMember]
        public string Payload { get; set; }
    }
}
