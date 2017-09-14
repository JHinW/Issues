using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{

    using Immutable = ImmutableDictionary<string, IMessage>;

    public class Immutables: IData
    {
        private Immutable _immutable;

        public Immutables()
        {
            _immutable = Immutable.Empty;
        }

        public Immutables(Immutable immutable)
        {
            _immutable = immutable;
        }

        public Immutables Add(string index, IMessage message)
        {
            return new Immutables(_immutable.Add(index, message));
        }

    }
}
