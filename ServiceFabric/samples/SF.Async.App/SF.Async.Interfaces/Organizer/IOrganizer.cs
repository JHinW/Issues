using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces.Organizer
{
    public interface IOrganizer: IAsync
    {
        IEntryComponents EntryComponents { get; set; }

        ILinker Linker { get; set; }

        /// <summary>
        /// send message to other sf-services with this entry method
        /// </summary>
        /// <param name="message">content for sending</param>
        /// <returns></returns>
        IOrganizer SetMessage(MessageWrapper message);

        /// <summary>
        /// call connecting delegate to link outter services
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IOrganizer SetConnecting(MessageWrapper message);
    }
}
