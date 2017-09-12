using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    public delegate Task MessageDelegate(MessageWrapper context);

    public delegate void BeforeMessageDelegate(MessageWrapper context);

    public delegate void AfterMessageDelegate(MessageWrapper context);

    public delegate MessageWrapper MessageProduceDelegate();
}
