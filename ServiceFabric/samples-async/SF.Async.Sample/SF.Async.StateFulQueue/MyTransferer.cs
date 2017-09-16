using SF.Async.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Usage
{
    public class MyTransferer: TransfererBase
    {
        public MyTransferer(IOperation<Core.Immutables> operation) : base(operation)
        {

        }
    }
}
