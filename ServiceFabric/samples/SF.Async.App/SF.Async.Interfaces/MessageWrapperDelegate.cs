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
    /// <param name="context"> The <see cref="MessageContext"/> </param>
    /// <returns></returns>
    public delegate Task MessageWrapperDelegate(MessageContext context);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Tgeneric"></typeparam>
    /// <param name="context"></param>
    /// <returns></returns>
    public delegate Task<Tgeneric> MessageWrapperDelegate<Tgeneric>(MessageContext context) where Tgeneric: class, new();
}
