using SF.Async.Operation.Common;
using SF.Async.Operation.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Usage
{
    public class SampleService: OccupantBase<string, string>, ISampleService
    {
        public SampleService(IQueue<IMessageContext> service) : base(service) { }

        public Task<string> GetSampleAsyncResult(string message)
        {
            return base.GetResultAsync(message);
        }

        public override IMessageContext Req2Wrapper(string input)
        {
            var wrapper = new MessageContext
            {
                AsyncSignalRefKey = Guid.NewGuid().ToString(),
                MessageBody = input
            };

            return wrapper;
        }

        public override string Wrapper2Res(IMessageContext input)
        {
            return input.MessageRes;
        }
    }
}
