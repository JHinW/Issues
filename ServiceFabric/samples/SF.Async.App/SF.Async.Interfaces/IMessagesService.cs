using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces
{
    public interface IMessageService<P, R>
        where P : class
        where R : class
    {
        Task<IAwaitableSource<R>> GetAwaitableTask(P message);
    }
}
