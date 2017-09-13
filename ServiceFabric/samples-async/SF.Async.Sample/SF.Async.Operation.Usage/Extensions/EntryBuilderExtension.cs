using SF.Async.Operation.Common.Base;
using SF.Async.Operation.Common.Inheritant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Usage.Extensions
{
    using FuncLikeCompWithTwoParas = Func<IMessageContext, MessageDelegate, Task>;

    using FuncLikeCompWihtSinglePare = Func<IMessageContext, Task>;

    public static class EntryBuilderExtension
    {
        public static IEntryBuilder UseCompEx(this IEntryBuilder builder, FuncLikeCompWithTwoParas funcLikeCompWithTwoParas)
        {
            builder.UseComp(next => message => funcLikeCompWithTwoParas(message, next));
            return builder;
        }

        public static IEntryBuilder UseCompEx(this IEntryBuilder builder, FuncLikeCompWihtSinglePare funcLikeCompWihtSinglePare)
        {
            builder.UseComp(next => message => funcLikeCompWihtSinglePare(message));
            return builder;
        }

    }
}
