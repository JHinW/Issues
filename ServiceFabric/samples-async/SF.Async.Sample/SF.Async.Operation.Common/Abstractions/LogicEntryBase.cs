﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SF.Async.Operation.Common.Abstractions
{
    public class LogicEntryBase : ILogicEntry
    {
        public MessageDelegate _messageDelegate;


        public LogicEntryBase(MessageDelegate messageDelegate)
        {
            _messageDelegate = messageDelegate;
        }

        public Task SendAsync(IMessageWrapper MessageWrapper)
        {
            return Task.Factory.StartNew(async () =>
            {
                if(_messageDelegate != null)
                {
                    await _messageDelegate(MessageWrapper);
                }    
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }
    }
}
