using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    public delegate Task MessageDelegate(IMessageContext context);

    public delegate void BeforeMessageDelegate(IMessageContext context);

    public delegate void AfterMessageDelegate(IMessageContext context);

    public delegate IMessageContext MessageProduceDelegate();
}
