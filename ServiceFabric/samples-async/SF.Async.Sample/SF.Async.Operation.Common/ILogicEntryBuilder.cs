using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    public interface ILogicEntryBuilder
    {
        ILogicEntryBuilder SpecifyBefore(BeforeMessageDelegate beforeMessageDelegate);

        ILogicEntryBuilder SpecifyAfter(AfterMessageDelegate afterMessageDelegate);

        ILogicEntryBuilder SpecifyContext(MessageProduceDelegate messageProduceDelegate);

        ILogicEntry Build();
    }
}
