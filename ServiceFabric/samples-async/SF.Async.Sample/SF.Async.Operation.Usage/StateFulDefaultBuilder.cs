using SF.Async.Operation.Common.Base;
using SF.Async.Operation.Common.Inheritant;
using System;
using System.Fabric;

namespace SF.Async.Operation.Usage
{
    using EntryMiddleware = Action<IEntryBuilder>;

    public class StateFulDefaultBuilder
    {
        private StatefulServiceContext _statefulServiceContext;

        private MessageLogger _messageLogger;

        private EntryMiddleware _entryMiddleware;

        public StateFulDefaultBuilder(StatefulServiceContext statefulServiceContext)
        {
            _statefulServiceContext = statefulServiceContext;
        }

        public StateFulDefaultBuilder ConfigureLogger(MessageLogger logger)
        {
            _messageLogger = logger;
            return this;
        }


        public StateFulDefaultBuilder ConfigureEntry(EntryMiddleware entryMiddleware)
        {

            _entryMiddleware = entryMiddleware;
            return this;
        }

        public Tservice Build<Tservice>()
        {
            if (_statefulServiceContext == null) throw new ArgumentNullException("No StatefulServiceContext setted");

            if (_messageLogger == null) throw new ArgumentNullException("No messageLogger setted");

            if (_entryMiddleware == null) throw new ArgumentNullException("No entryMiddleware setted");

            var entry = new EntryBuilder();

            _entryMiddleware(entry);



            return  (Tservice)Activator.CreateInstance(typeof(Tservice), _statefulServiceContext, new ServiceEvent(_messageLogger), entry.EntryBuild());
        }
    }
}
