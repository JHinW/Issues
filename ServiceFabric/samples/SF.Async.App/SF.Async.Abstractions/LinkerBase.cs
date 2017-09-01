using SF.Async.Interfaces.Organizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Async.Interfaces;

namespace SF.Async.Abstractions
{
    public abstract class LinkerBase : ILinker
    {    
        private readonly IList<Func<MessageWrapperDelegate, MessageWrapperDelegate>> _connectings = new List<Func<MessageWrapperDelegate, MessageWrapperDelegate>>();

        public abstract MessageWrapperDelegate BuildLinker();

        public virtual ILinker Connect(Func<MessageWrapperDelegate, MessageWrapperDelegate> middleware)
        {
            _connectings.Add(middleware);
            return this;
        }
    }
}
