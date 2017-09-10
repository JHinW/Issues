using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    public delegate Task MessageDelegate(IMessageWrapper context);

    public delegate void BeforeMessageDelegate(IMessageWrapper context);

    public delegate void AfterMessageDelegate(IMessageWrapper context);

    public delegate IMessageWrapper MessageProduceDelegate();
}
