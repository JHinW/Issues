using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{
    public abstract class OccupantBase<TReq, TRes> : IOccupant<TReq, TRes>
    {
        private IQueue<MessageWrapper> _queueService;

        protected OccupantBase(IQueue<MessageWrapper> queueService)
        {
            _queueService = queueService;
        }

        public Task<TRes> GetResultAsync(TReq message)
        {
           return Task.Run(async () => {
                var result = await _queueService.EnqueueAsync(Req2Wrapper(message));
                var wrapper = await result.Task;
                return Wrapper2Res(wrapper);
            });
        }

        public virtual MessageWrapper Req2Wrapper(TReq input)
        {
            return default(MessageWrapper);
        }

        public virtual TRes Wrapper2Res(MessageWrapper input)
        {
            return default(TRes);
        }
    }
}
