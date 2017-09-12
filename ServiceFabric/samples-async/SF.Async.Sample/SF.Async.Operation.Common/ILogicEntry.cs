using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    public interface ILogicEntry
    {
        //MessageDelegate MessageDelegate { get; set; }

        Task SendAsync(IMessageContext MessageWrapper);
    }
}
