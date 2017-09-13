using SF.Async.Operation.Common;
using SF.Async.Operation.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Operation.Usage
{
    using EntryMiddleware = Func<EntryBuilder, EntryBuilder>;
    
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
            if (_statefulServiceContext == null) throw new ArgumentNullException("No StatefulServiceContext");

            if (_messageLogger == null) throw new ArgumentNullException("No messageLogger");

            if (_entryMiddleware == null) throw new ArgumentNullException("No entryMiddleware");

            var entry = _entryMiddleware(new EntryBuilder()).Build();

            return  (Tservice)Activator.CreateInstance(typeof(Tservice), _statefulServiceContext, _messageLogger, entry);
        }
    }
}
