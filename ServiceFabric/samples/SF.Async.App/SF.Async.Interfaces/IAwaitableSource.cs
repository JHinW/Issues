using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces
{
    public interface IAwaitableSource<T>
        where T: class
    {
        Task<T> GetAwaitableSource();
    }
}
