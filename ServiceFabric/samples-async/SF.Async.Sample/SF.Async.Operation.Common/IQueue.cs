using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    public interface IQueue<T>
    {
        Task<TaskCompletionSource<T>> EnqueueAsync(T message);

        Task<TaskCompletionSource<T>> DequeueAsync();

        Task<TaskCompletionSource<T>> PeekAsync();
    }
}
