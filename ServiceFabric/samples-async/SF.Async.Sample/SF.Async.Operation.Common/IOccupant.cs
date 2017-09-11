using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    public interface IOccupant<TReq, TRes>: Microsoft.ServiceFabric.Services.Remoting.IService
    {
        Task<TRes> GetAsyncResultAsync(TReq message);
    }
}
