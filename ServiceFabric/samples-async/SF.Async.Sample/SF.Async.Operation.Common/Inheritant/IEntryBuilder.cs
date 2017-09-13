using SF.Async.Operation.Common.Abstractions;
using SF.Async.Operation.Common.Base;
using System;

namespace SF.Async.Operation.Common.Inheritant
{
    using MessageDelegateComp = Func<MessageDelegate, MessageDelegate>;

    public interface IEntryBuilder
    {
        IEntryBuilder UseComp(MessageDelegateComp messageDelegateComp);

        IMessageEntry EntryBuild();
    }
}
