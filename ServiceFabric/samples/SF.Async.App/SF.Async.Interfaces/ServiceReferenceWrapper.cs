using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces
{
    [DataContract]
    public class ServiceReferenceWrapper
    {
        /// <summary>
        ///  get history of service that processed <see ref="MessageContext"/> 
        ///  note: include current service
        /// </summary>
        [DataMember]
        public ServiceReference[] History { get; }

        /// <summary>
        ///  represent service in processing 
        /// </summary>
        [DataMember]
        public ServiceReference Current { get; }
    }
}
