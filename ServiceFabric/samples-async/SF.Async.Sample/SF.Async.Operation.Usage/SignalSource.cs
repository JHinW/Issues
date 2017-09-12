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
        private TaskCompletionSource<MessageWrapper> _source = null;

        public SignalSource(TaskCompletionSource<MessageWrapper> source)
        {
            _source = source;
        }

        public void SetResult(MessageWrapper messageWrapper)
        {
            _source?.SetResult(messageWrapper);
        }

    }
}
