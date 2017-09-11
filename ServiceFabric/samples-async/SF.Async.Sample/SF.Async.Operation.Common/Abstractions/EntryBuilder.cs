using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{
    using MessageDelegateComp = Func<MessageDelegate, MessageDelegate>;

    public class EntryBuilder: LogicEntryBuilderBase
    {
        private IList<MessageDelegateComp> _messageDelegateCompList = new List<MessageDelegateComp>();

        public EntryBuilder()
        {

        }

        public ILogicEntryBuilder UseComp(MessageDelegateComp comp)
        {
            _messageDelegateCompList.Add(comp);
            return this;
        }

        public override ILogicEntry Build()
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

            return base.Build();
        }

    }
}
