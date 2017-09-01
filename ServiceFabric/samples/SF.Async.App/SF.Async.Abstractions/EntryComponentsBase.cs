using SF.Async.Interfaces;
using SF.Async.Interfaces.Organizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Abstractions
{
    public abstract class EntryComponentsBase : IEntryComponents
    {
        private readonly IList<Func<MessageWrapperDelegate, MessageWrapperDelegate>> _components = new List<Func<MessageWrapperDelegate, MessageWrapperDelegate>>();

        public abstract MessageWrapperDelegate BuildComponents();

        public virtual IEntryComponents Use(Func<MessageWrapperDelegate, MessageWrapperDelegate> middleware)
        {
            _components.Add(middleware);
            return this;
        }
    }
}
