using SF.Async.Abstractions.TcpListener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Abstractions.Extension
{
    public class MessageMiddleWareExtension
    {
        public static TMessageMiddleWare GetMiddleWare<TMessageMiddleWare>(Object para) where TMessageMiddleWare: class
        {
            return MessageMiddleWarePartitionClient<TMessageMiddleWare>.Create(para).CreateInstance();
        }
    }
}
