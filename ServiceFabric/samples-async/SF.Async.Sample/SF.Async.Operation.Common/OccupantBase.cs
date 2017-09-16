using SF.Async.Operation.Common.Base;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    public abstract class OccupantBase<TReq, TRes> : IOccupant<TReq, TRes>
    {
        private IQueue<IMessageContext> _queueService;

        protected OccupantBase(IQueue<IMessageContext> queueService)
        {
            _queueService = queueService;
        }

        public async Task<TRes> GetResultAsync(TReq message)
        {
            var result = await _queueService.EnqueueAsync(Req2Wrapper(message));
            return Wrapper2Res(result);
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
