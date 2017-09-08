using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{
    public abstract class OccupantBase<T> : IOccupant<T>
    {
        private IQueue<T> queueService;

        public async Task<T> GetAsyncResultAsync(T message)
        {
            var result = await queueService.EnqueueAsync(message);
            return await result.Task;
        }
    }
}
