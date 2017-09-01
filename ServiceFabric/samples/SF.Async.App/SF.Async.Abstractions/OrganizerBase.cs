using SF.Async.Interfaces.Organizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Async.Interfaces;

namespace SF.Async.Abstractions
{
    public abstract class OrganizerBase : IOrganizer
    {
        public virtual IEntryComponents EntryComponents { get; set; }
        public virtual ILinker Linker { get; set; }


        public IOrganizer Setting(Func<MessageWrapperDelegate, MessageWrapperDelegate>  use)
        {
            EntryComponents.Use(next =>
            {
                return messageContext =>
                {

                    return next(messageContext);
                };
            }
            );
            return this;
        }

        public virtual IOrganizer SetMessage(MessageWrapper message)
        {
            return this;
        }


        public virtual IOrganizer SetConnecting(MessageWrapper message)
        {
            return this;
        }
    }
}
