using SF.Async.Operation.Common;
using SF.Async.Operation.Common.Base;
using System.Diagnostics.Tracing;

namespace SF.Async.Operation.Usage
{
    public class ServiceEvent: EventSource, IServiceEvent
    {
        private MessageLogger _messageLogger;

        public ServiceEvent(EventSource eventSource)
        {
            _messageLogger = log =>
            {
                this.WriteEvent(1, log);
            };
        }

        public ServiceEvent(MessageLogger messageLogger)
        {
            _messageLogger = messageLogger;
        }

        public void LogEvents(string log)
        {
            _messageLogger(log);
        }

          
    }
}
