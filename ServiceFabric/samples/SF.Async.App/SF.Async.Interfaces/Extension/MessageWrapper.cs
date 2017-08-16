using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces
{
    public partial class MessageWrapper
    {
        /// <summary>
	    /// Convert the provided <paramref name="message"/> into a <see cref="MessageWrapper"/>
	    /// </summary>
	    /// <param name="message"></param>
	    /// <returns></returns> 
	    public static MessageWrapper CreateMessageWrapper(object message)
        {
            using (var stream = new MemoryStream())
            {
                var Serializer = new DataContractJsonSerializer(message.GetType());
                Serializer.WriteObject(stream, message);
                stream.Position = 0;
                using (StreamReader sr = new StreamReader(stream))
                {
                    var wrapper = new MessageWrapper
                    {
                        MessageType = message.GetType().FullName,
                        Payload = sr.ReadToEnd(),
                    };
                    return wrapper;
                }
            }

        }
    }
}
