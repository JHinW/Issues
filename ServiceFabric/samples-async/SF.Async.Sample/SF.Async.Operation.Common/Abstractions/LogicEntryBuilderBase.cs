using SF.Async.Operation.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{

    public abstract class LogicEntryBuilderBase : IMessageEntryBuilder
    {
        private AfterMessageDelegate _afterMessageDelegate;

        private BeforeMessageDelegate _beforeMessageDelegate;

        private MessageDelegate _messageDelegate;

        private SemaphoreSlim _metex = new SemaphoreSlim(10);

        public virtual IMessageEntry MessageEntryBuild()
        {
            var entry = new MessageEntryBase(async (context) => {
                try
                {
                    await _metex.WaitAsync();
                    _beforeMessageDelegate(context);
                    await _messageDelegate(context);

                }
                catch (Exception e)
                {
                }
                finally
                {
                    _afterMessageDelegate(context);
                    _metex.Release();
                }


            });
            return entry;
        }

        public virtual IMessageEntryBuilder SpecifyAfter(AfterMessageDelegate afterMessageDelegate)
        {
            _afterMessageDelegate = afterMessageDelegate;
            return this;
        }

        public virtual IMessageEntryBuilder SpecifyBefore(BeforeMessageDelegate beforeMessageDelegate)
        {
            _beforeMessageDelegate = beforeMessageDelegate;
            return this;
        }

        public IMessageEntryBuilder SpecifyDelegate(MessageDelegate messageDelegate)
        {
            _messageDelegate = messageDelegate;
            return this;
        }
    }
}
