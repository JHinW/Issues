using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{
    public abstract class LogicEntryBase : ILogicEntry
    {
        public MessageDelegate _messageDelegate;
        public BeforeMesageDelegate _beforeMesageDelegate;
        public AfterMesageDelegate _afterMesageDelegate;

        public Task HostAsync()
        {
            throw new NotImplementedException();
        }

        public virtual LogicEntryBase Delegate(MessageDelegate messageDelegate)
        {
            _messageDelegate = messageDelegate;
            return this;
        }


        public virtual LogicEntryBase SpecifyBefore(BeforeMesageDelegate beforeMesageDelegate)
        {
            _beforeMesageDelegate = beforeMesageDelegate;
            return this;
        }

        public virtual LogicEntryBase SpecifyAfter(AfterMesageDelegate afterMesageDelegate)
        {
            _afterMesageDelegate = afterMesageDelegate;
            return this;
        }
    }
}
