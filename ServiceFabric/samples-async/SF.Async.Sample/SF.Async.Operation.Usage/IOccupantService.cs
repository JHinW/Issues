using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Usage
{
    public interface IOccupantService: Microsoft.ServiceFabric.Services.Remoting.IService
    {
        Task<string> GetSampleAsyncResult(string message);
    }
}
