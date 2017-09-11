﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common
{
    public interface IMessageWrapper
    {
        string AsyncSignalRefKey { get; set; }

        ISignalSource SignalSource { get; set; }

        Boolean HasException { get; set; }

        string MessageBody { get; set; }

        string MessageRes { get; set; }
    }
}
