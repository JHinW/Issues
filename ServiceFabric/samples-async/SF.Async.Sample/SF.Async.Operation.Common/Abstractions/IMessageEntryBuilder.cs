using SF.Async.Operation.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{
    public interface IMessageEntryBuilder
    {
        IMessageEntryBuilder SpecifyBefore(BeforeMessageDelegate beforeMessageDelegate);

        IMessageEntryBuilder SpecifyAfter(AfterMessageDelegate afterMessageDelegate);

        IMessageEntryBuilder SpecifyDelegate(MessageDelegate messageDelegate);

        // ILogicEntryBuilder SpecifyContext(MessageProduceDelegate messageProduceDelegate);

        IMessageEntry MessageEntryBuild();
    }
}
