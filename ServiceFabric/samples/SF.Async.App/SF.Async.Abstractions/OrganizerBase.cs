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
        private readonly IList<Func<MessageWrapperDelegate, MessageWrapperDelegate>> _components = new List<Func<MessageWrapperDelegate, MessageWrapperDelegate>>();

        private readonly IList<Func<MessageWrapperDelegate, MessageWrapperDelegate>> _connectings = new List<Func<MessageWrapperDelegate, MessageWrapperDelegate>>();

        public virtual IOrganizer Use(Func<MessageWrapperDelegate, MessageWrapperDelegate> middleware)
        {
            _components.Add(middleware);
            return this;
        }

        public virtual IOrganizer Connect(Func<MessageWrapperDelegate, MessageWrapperDelegate> middleware)
        {
            _connectings.Add(middleware);
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

        public MessageWrapperDelegate BuildComponents()
        {
            MessageWrapperDelegate app = message =>
            {
                return Task.FromResult(message);
            };

            foreach (var component in _components.Reverse())
            {
                app = component(app);
            }

            return app;

        }

        public MessageWrapperDelegate BuildConnecttings()
        {
            MessageWrapperDelegate app = message =>
            {
                return Task.FromResult(message);
            };

            foreach (var connecting in _connectings.Reverse())
            {
                app = connecting(app);
            }

            return app;
        }
    }
}
