using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{
    public abstract class LogicEntryBuilderBase : ILogicEntryBuilder
    {
        private AfterMessageDelegate _afterMessageDelegate;

        private BeforeMessageDelegate _beforeMessageDelegate;

        private MessageDelegate _messageDelegate;


        private SemaphoreSlim _metex = new SemaphoreSlim(10);

        public virtual ILogicEntry Build()
        {
            var entry = new LogicEntryBase();
            entry.MessageDelegate = async (context) => {
                try
                {
                    await _metex.WaitAsync();
                    _beforeMessageDelegate(context);
                    await _messageDelegate(context);
                    
                }catch(Exception e)
                {
                }
                finally
                {
                    _afterMessageDelegate(context);
                    _metex.Release();
                }
                

            };
            return entry;
        }

        public virtual ILogicEntryBuilder SpecifyAfter(AfterMessageDelegate afterMessageDelegate)
        {
            _afterMessageDelegate = afterMessageDelegate;
            return this;
        }

        public virtual ILogicEntryBuilder SpecifyBefore(BeforeMessageDelegate beforeMessageDelegate)
        {
            _beforeMessageDelegate = beforeMessageDelegate;
            return this;
        }

        public ILogicEntryBuilder SpecifyDelegate(MessageDelegate messageDelegate)
        {
            _messageDelegate = messageDelegate;
            return this;
        }
    }
}
