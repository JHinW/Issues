using SF.Async.Operation.Common.Base;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{
    public interface IMessageEntry
    {
        //MessageDelegate MessageDelegate { get; set; }

        Task SendAsync(IMessageContext MessageWrapper);
    }
}
