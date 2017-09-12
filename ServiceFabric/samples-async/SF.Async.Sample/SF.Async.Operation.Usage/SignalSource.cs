using SF.Async.Operation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Usage
{
    public class SignalSource : ISignalSource
    {
        private TaskCompletionSource<IMessageContext> _source = null;

        public SignalSource(TaskCompletionSource<IMessageContext> source)
        {
            _source = source;
        }

        public void SetResult(IMessageContext messageWrapper)
        {
            _source?.SetResult(messageWrapper);
        }

    }
}
