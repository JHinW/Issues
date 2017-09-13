using SF.Async.Operation.Common.Abstractions;
using SF.Async.Operation.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Inheritant
{
    using MessageDelegateComp = Func<MessageDelegate, MessageDelegate>;

    public class EntryBuilder: LogicEntryBuilderBase, IEntryBuilder
    {
        private IList<MessageDelegateComp> _messageDelegateCompList = new List<MessageDelegateComp>();

        public EntryBuilder()
        {
        }

        public IEntryBuilder UseComp(MessageDelegateComp messageDelegateComp)
        {
            _messageDelegateCompList.Add(messageDelegateComp);
            return this;
        }

        public IMessageEntry EntryBuild()
        {
            this.SpecifyAfter(context => { });
            this.SpecifyBefore(context => { });

            MessageDelegate app = context =>
            {
                return Task.CompletedTask;
            };

            foreach (var component in _messageDelegateCompList.Reverse())
            {
                app = component(app);
            }
            this.SpecifyDelegate(app);

            return base.MessageEntryBuild();
        }
    }
}
