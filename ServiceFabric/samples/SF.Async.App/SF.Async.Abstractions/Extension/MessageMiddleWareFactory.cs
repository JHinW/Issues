using SF.Async.Abstractions.MessageListener;
using SF.Async.Interfaces;

namespace SF.Async.Abstractions.Extension
{
    public class MessageMiddleWareFactory
    {
        public static TMessageMiddleWare GetMiddleWare<TMessageMiddleWare>(ServiceReference reference) where TMessageMiddleWare: class
        {
            return MessageMiddleWarePartitionClient<TMessageMiddleWare>.Create(reference).CreateInstance();
        }
    }
}
