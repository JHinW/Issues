using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{
    public abstract class OccupantBase<TReq, TRes> : IOccupant<TReq, TRes>
    {
        private IQueue<IMessageContext> _queueService;

        protected OccupantBase(IQueue<IMessageContext> queueService)
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

        public virtual IMessageContext Req2Wrapper(TReq input)
        {
            return default(IMessageContext);
        }

        public virtual TRes Wrapper2Res(IMessageContext input)
        {
            return default(TRes);
        }
    }
}
