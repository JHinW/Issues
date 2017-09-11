using SF.Async.Operation.Common;
using SF.Async.Operation.Common.Abstractions;
using SF.Async.Operation.Usage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.StateFul.Services
{
    public class OccupantImpl: SampleService
    {
        public OccupantImpl(IQueue<MessageWrapper> service) : base(service) { }

    }
}
