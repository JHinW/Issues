using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    public interface IOccupant<T>
    {
        Task<T> GetAsyncResultAsync(T message);
    }
}
