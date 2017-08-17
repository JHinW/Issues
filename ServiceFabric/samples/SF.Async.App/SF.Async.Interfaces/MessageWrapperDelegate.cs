using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces
{
    /// <summary>
    /// a function that can process wapped messgaes
    /// </summary>
    /// <param name="context"> The <see cref="MessageWrapper"/> </param>
    /// <returns></returns>
    public delegate Task MessageWrapperDelegate(MessageWrapper context);
}
