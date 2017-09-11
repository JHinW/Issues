using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{
    public abstract class OccupantBase<TReq, TRes> : IOccupant<TReq, TRes>
    {
        private IQueue<IMessageWrapper> _queueService;

        protected OccupantBase(IQueue<IMessageWrapper> queueService)
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

        public virtual IMessageWrapper Req2Wrapper(TReq input)
        {
            return default(IMessageWrapper);
        }

        public virtual TRes Wrapper2Res(IMessageWrapper input)
        {
            return default(TRes);
        }
    }
}
