using SF.Async.Operation.Common.Base;

namespace SF.Async.Operation.Common.Base
{
    public interface ISignalSource
    {
        void SetResult(IMessageContext messageWrapper);
    }
}
