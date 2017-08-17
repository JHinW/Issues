using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces.Organizer
{
    public interface IOrganizer
    {
        /// <summary>
        /// method for adding middleware services to services gropus
        /// </summary>
        /// <param name="middleware">service middleware</param>
        /// <returns></returns>
        IOrganizer Use(Func<MessageWrapperDelegate, MessageWrapperDelegate> middleware);
    }
}
