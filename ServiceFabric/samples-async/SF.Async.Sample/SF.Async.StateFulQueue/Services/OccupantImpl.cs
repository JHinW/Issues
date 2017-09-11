using SF.Async.Operation.Common;
using SF.Async.Operation.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.StateFul.Services
{
    public class OccupantImpl: OccupantBase<string, string>
    {
        public OccupantImpl(IQueue<IMessageWrapper> service) : base(service) { }

        public override IMessageWrapper Req2Wrapper(string input)
        {
            var wrapper = new MessageWrapper
            {
                AsyncSignalRefKey = Guid.NewGuid().ToString(),
                MessageBody = input
            };

            return wrapper;
        }

        public override string Wrapper2Res(IMessageWrapper input)
        {
            return input.MessageRes;
        }

    }
}
